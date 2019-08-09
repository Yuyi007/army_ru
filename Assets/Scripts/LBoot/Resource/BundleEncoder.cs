//
// BundleEncoder.cs
//
// Author:
//       Duwenjie duwenjie
//

//

// #define PROFILE_FILE

/////////////////////////////////////////////
// LOAD_FROM_FILE is now properly tested.
// You can mix standard asset bundles with custom encypted asset bundles,
// LOAD_FROM_FILE will distinguish them with headers, and read standard asset bundles
// with LoadFromFile(), and read custom encrypted bundles with LoadFromMemory()
#define LOAD_FROM_FILE

/////////////////////////////////////////////
// MULTI_ENCODING
// When enabled, multiple encodings are supported to encode and decode bundle files
//#define MULTI_ENCODING

using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using SLua;
using System.Threading;
using System.Collections;
using LuaInterface;

namespace LBoot
{
    /// <summary>
    /// BundleEncoder packs assetbundles to a flexible format with encryption
    /// </summary>
    [CustomLuaClassAttribute]
    public class BundleEncoder
    {
        public enum Encoding
        {
            Unity,
            Plain,
            Rc4,
            AES_256_CBC,
            Chacha20,
            Unknown
        };

        // This can be called multiple times
        // So in case we change the encryption key, we can reinit this in lua
        public static void Init(byte[] key, byte[] iv)
        {
           // selfTest();
        }

        public static Encoding GetEncodingOfFile(string filepath)
        {
#if MULTI_ENCODING
            LogUtil.Debug("GetEncodingOfFile: MULTI_ENCODING enabled");
            const long headerSize = 2;
            long bytesRead = 0;
            byte [] data = FileUtils.GetDataFromFile(filepath, 0, headerSize, out bytesRead);
            if (bytesRead == headerSize)
            {
                return GetEncodingOfData(data);
            }
            return Encoding.Unknown;
#else
            return Encoding.Unity;
#endif // MULTI_ENCODING
        }

        public static Encoding GetEncodingOfData(byte[] data)
        {
            // headers:
            // [0x55 0x6e] unity standard bundle headers
            // [0x00 0x00] for non-encrypt
            // [0x00 0x01] for rc4 encryption
            // [0x00 0x02] for aes_256_cbc encryption
            // [0x00 0x03] for chacha20 encryption
            if (data.Length < 2)
            {
                LogUtil.Error("GetEncodingOfData data length is " + data.Length);
                return Encoding.Unknown;
            }

            LogUtil.Trace("GetEncodingOfData 1: " + data[0] + " 2: " + data[1]);

            if (data[0] == 0x55 && data[1] == 0x6e)
            {
                return Encoding.Unity;
            }
            if (data[0] == 0x00 && data[1] == 0x00)
            {
                return Encoding.Plain;
            }
            else if (data[0] == 0x00 && data[1] == 0x01)
            {
                return Encoding.Rc4;
            }
            else if (data[0] == 0x00 && data[1] == 0x02)
            {
                return Encoding.AES_256_CBC;
            }
            else if (data[0] == 0x00 && data[1] == 0x03)
            {
                return Encoding.Chacha20;
            }
            else
            {
                return Encoding.Unknown;
            }
        }

        // To be used in editor only
        public static void EncodeOverwriteBundleFile(string filepath)
        {
            byte [] data = File.ReadAllBytes(filepath);
            Encoding enc = GetEncodingOfData(data);
            if (enc != Encoding.Unity && enc != Encoding.Unknown)
            {
                throw new Exception("file " + filepath + " is probably already encoded");
            }

            // append a header
            var fs = File.OpenWrite(filepath);
            EncodeStream(fs, data, Encoding.AES_256_CBC);
            fs.Close();
        }

        public static void EncodeStream(Stream s, byte[] data, Encoding enc)
        {
#if MULTI_ENCODING
            if (enc == Encoding.Unity)
            {
                s.Write(data, 0, data.Length);
            }
            else if (enc == Encoding.Plain)
            {
                s.WriteByte(0x00);
                s.WriteByte(0x00);
                s.Write(data, 0, data.Length);
            }
            else if (enc == Encoding.Rc4)
            {
                // encrypt with rc4
                LuaDLL.arc4_encrypt_easy(data, 0, data.Length,
                    LBootApp.BUNDLE_IV, LBootApp.BUNDLE_IV.Length);

                s.WriteByte(0x00);
                s.WriteByte(0x01);
                s.Write(data, 0, data.Length);
            }
            else if (enc == Encoding.AES_256_CBC)
            {
                // encrypt with AES
                byte[] temp = new byte[LBootApp.BUNDLE_IV.Length];
                Array.Copy(LBootApp.BUNDLE_IV, temp, LBootApp.BUNDLE_IV.Length);

                byte[] encrypted = data;
                if (data.Length % 16 > 0)
                {
                    encrypted = new byte[data.Length + 16 - data.Length % 16];
                }
                LuaDLL.aes_256_cbc_encrypt_easy(encrypted, data, 0, data.Length,
                    LBootApp.BUNDLE_KEY, LBootApp.BUNDLE_KEY.Length,
                    temp, temp.Length);

                s.WriteByte(0x00);
                s.WriteByte(0x02);
                s.Write(encrypted, 0, encrypted.Length);
            }
            else if (enc == Encoding.Chacha20)
            {
                // encrypt with Chacha20
                byte[] encrypted = new byte[data.Length + 16];
                int res = LuaDLL.crypto_secretbox_easy(encrypted, data, data.Length,
                              LBootApp.BUNDLE_NONCE, LBootApp.BUNDLE_KEY);

                if (res != 0)
                {
                    throw new Exception("BundleEncoder Chacha20 encode return: " + res);
                }

                s.WriteByte(0x00);
                s.WriteByte(0x03);
                s.Write(encrypted, 0, encrypted.Length);
            }
            else
            {
                throw new Exception("BundleEncoder: encode stream with unknown encoding: " + enc);
            }
#else
            s.Write(data, 0, data.Length);
#endif // MULTI_ENCODING
        }

        public static byte [] DecodeBundleFile(string path)
        {
            byte[] data = FileUtils.GetDataFromFile(path);
            if (data == null)
            {
                throw new Exception("DecodeBundleFile: cannot read file at " + path);
            }
            else
            {
                return DecodeData(data, 0, data.Length);
            }
        }

        public static byte [] DecodeBundle(byte[] data)
        {
            return DecodeData(data, 0, data.Length);
        }

        public static byte [] DecodeData(byte[] data, int offset, long size)
        {
#if MULTI_ENCODING
            Encoding enc = GetEncodingOfData(data);
            // LogUtil.TraceFormat("data {0} {1} {2} {3} {4} {5}", data[0], data[1], data[2], data[3], data[4], data[5]);

            if (enc == Encoding.Unity)
            {
                return data;
            }

            if (size < 2)
            {
                throw new Exception("BundleEncoder DecodeData invalid size " + size);
            }

            // FIXME
            // Using returned (unsigned char *) as byte [] crashes
            // Currently have to copy data for all
            byte[] buf = new byte[size - 2];
            Array.Copy(data, offset + 2, buf, 0, size - 2);

            if (enc == Encoding.Plain)
            {
                return buf;
            }
            else if (enc == Encoding.Rc4)
            {
                LuaDLL.arc4_decrypt_easy(buf, 0, buf.Length,
                    LBootApp.BUNDLE_IV, LBootApp.BUNDLE_IV.Length);
                return buf;
            }
            else if (enc == Encoding.AES_256_CBC)
            {
                byte[] temp = new byte[LBootApp.BUNDLE_IV.Length];
                Array.Copy(LBootApp.BUNDLE_IV, temp, LBootApp.BUNDLE_IV.Length);

                LuaDLL.aes_256_cbc_decrypt_easy(buf, buf, 0, buf.Length,
                    LBootApp.BUNDLE_KEY, LBootApp.BUNDLE_KEY.Length,
                    temp, temp.Length);
                return buf;
            }
            else if (enc == Encoding.Chacha20)
            {
                byte[] outbuf = new byte[buf.Length - 16];
                int res = LuaDLL.crypto_secretbox_open_easy(outbuf, buf, buf.Length,
                              LBootApp.BUNDLE_NONCE, LBootApp.BUNDLE_KEY);
                if (res != 0)
                {
                    throw new Exception("BundleEncoder Chacha20 decode return: " + res);
                }
                return outbuf;
            }
            else
            {
                LogUtil.WarnFormat("invalid encoding of bundle data: {0} {1} (probably not encoded)",
                    data[0], data[1]);
                return data; // try to read as is
            }
#else
            return data;
#endif // MULTI_ENCODING
        }

        /* ========================== Load From Memory ========================== */

        public static AssetBundle CreateBundleFromMemory(byte[] data)
        {
#if PROFILE_FILE
            Profiler.BeginSample("BundleEncoder.CreateBundleFromMemory");
#endif
            byte[] bundleData = DecodeBundle(data);
            AssetBundle bundle = AssetBundle.LoadFromMemory(bundleData);
#if PROFILE_FILE
            Profiler.EndSample();
#endif
            return bundle;
        }

        public static AssetBundleCreateRequest CreateBundleFromMemoryAsync(byte[] data)
        {
#if PROFILE_FILE
            Profiler.BeginSample("BundleEncoder.CreateBundleFromFileAsync");
#endif
            byte[] bundleData = DecodeBundle(data);
            AssetBundleCreateRequest req = AssetBundle.LoadFromMemoryAsync(bundleData);
#if PROFILE_FILE
            Profiler.EndSample();
#endif
            return req;
        }

        /* ========================== Load From File ========================== */

        public static AssetBundle CreateBundleFromFile(string path)
        {
#if PROFILE_FILE
            Profiler.BeginSample("BundleEncoder.CreateBundleFromFile");
#endif
            AssetBundle bundle = null;

#if LOAD_FROM_FILE
            try
            {
                Encoding enc = GetEncodingOfFile(path);
                LogUtil.Trace("CreateBundleFromFile: " + path + " enc=" + enc);
                if (enc == Encoding.Unity)
                {
                    string fullpath = FileUtils.PrepareBundleFile(path);
                    bundle = AssetBundle.LoadFromFile(fullpath);
#if PROFILE_FILE
                    Profiler.EndSample();
#endif
                    return bundle;
                }
                LogUtil.Trace("CreateBundleFromFile: fallback to LoadFromMemory for this encoding");
            }
            catch (Exception e)
            {
                // just fallback to LoadFromMemory
                LogUtil.Error("CreateBundleFromFile: fallback to LoadFromMemory because of Error " + e);
            }
#endif // LOAD_FROM_FILE

            byte[] data = DecodeBundleFile(path);
            bundle = AssetBundle.LoadFromMemory(data);
#if PROFILE_FILE
            Profiler.EndSample();
#endif
            return bundle;
        }

        public static AssetBundleCreateRequest CreateBundleFromFileAsync(string path)
        {
#if PROFILE_FILE
            Profiler.BeginSample("BundleEncoder.CreateBundleFromFileAsync");
#endif
            AssetBundleCreateRequest req = null;

#if LOAD_FROM_FILE
            try
            {
                Encoding enc = GetEncodingOfFile(path);
                LogUtil.Trace("CreateBundleFromFileAsync: " + path + " enc=" + enc);
                if (enc == Encoding.Unity)
                {
                    string fullpath = FileUtils.PrepareBundleFile(path);
                    req = AssetBundle.LoadFromFileAsync(fullpath);
#if PROFILE_FILE
                    Profiler.EndSample();
#endif
                    return req;
                }
            }
            catch (Exception e)
            {
                // just fallback to LoadFromMemoryAsync
                LogUtil.Error("CreateBundleFromFileAsync: fallback to LoadFromMemoryAsync because of Error " + e);
            }
#endif // LOAD_FROM_FILE

            byte[] data = DecodeBundleFile(path);
            req = AssetBundle.LoadFromMemoryAsync(data);
#if PROFILE_FILE
            Profiler.EndSample();
#endif
            return req;
        }

        /* ========================== Load From WWW ========================== */

        // NOTE: this can not load custom encrypted asset bundles
        public static AssetBundle CreateBundleFromWWW(string uri, int version, uint crc = 0)
        {
            uri = fixWWWUri(uri);

            LogUtil.Trace("BundleEncoder: LoadFromCacheOrDownload (sync) " + uri);
            var www = WWW.LoadFromCacheOrDownload(uri, version, crc);

            // busy wait
            while (! www.isDone)
            {
                // LogUtil.Debug("BundleEncoder: LoadFromCacheOrDownload (sync) busy waiting...");
                if (www.error != null && www.error != "")
                {
                    LogUtil.Error("BundleEncoder: CreateBundleFromWWW not done and failed: " + www.error);
                    return null;
                }
            };

            // LogUtil.Debug("BundleEncoder: LoadFromCacheOrDownload (sync) done.");

            if(www.error == null || www.error == "")
            {
                return www.assetBundle;
            }
            else
            {
                LogUtil.Error("BundleEncoder: CreateBundleFromWWW failed: " + www.error);
                return null;
            }
        }

        // NOTE: this can not load custom encrypted asset bundles
        public static WWW CreateBundleFromWWWAsync(string uri, int version, uint crc = 0)
        {
            uri = fixWWWUri(uri);

            LogUtil.Trace("BundleEncoder: LoadFromCacheOrDownload " + uri);
            return WWW.LoadFromCacheOrDownload(uri, version, crc);
        }

        private static string fixWWWUri(string uri)
        {
            if (! uri.StartsWith("http"))
            {
                uri = "file://" + FileUtils.PrepareBundleFile(uri);
            }

            return uri;
        }

        /* ====================================================== */

        private static void selfTest()
        {
            byte[][] testData = new byte[4][];
            testData[0] = new byte[]
            {
                0xDE, 0xAD, 0xBE, // EF
            };
            testData[1] = new byte[]
            {
                0x00, 0x01, 0xA2, 0xB3, 0xC4, 0xD5, 0xE6, 0xF7,
            };
            testData[2] = new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15,
            };
            testData[3] = new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0xF7, 0xF8, 0xF9, 0xFA, 0xFB, 0xFC, 0xFD, 0xFE, 0xFF,
                0xFF,
            };

            foreach (Encoding enc in Enum.GetValues(typeof(Encoding)))
            {
                if (enc == Encoding.Unity || enc == Encoding.Unknown)
                    continue;

                var testLength = testData.Length;
                for (int j = 0; j < testLength; j++)
                {
                    byte[] data = testData[j];
                    var dataLength = data.Length;
                    byte[] temp = new byte[dataLength];
                    Array.Copy(data, temp, dataLength);
                    MemoryStream ms = new MemoryStream();
                    EncodeStream(ms, temp, enc);
                    byte[] decrypted = DecodeData(ms.GetBuffer(), 0, ms.Length);
                    ms.Close();

                    for (int i = 0; i < dataLength; i++)
                    {
                        if (data[i] != decrypted[i])
                        {
                            throw new Exception("BundlerEncoder selfTest: fail at " + enc + " data " + j + " index " + i);
                        }
                    }

                    LogUtil.Debug("BundleEncoder selfTest: success with " + enc + " data " + j);
                }
            }
        }
    }
}

