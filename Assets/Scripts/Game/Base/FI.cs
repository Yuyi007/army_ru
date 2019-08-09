using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Timers;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography;
using LuaInterface;
using ICSharpCode.SharpZipLib.Zip;
using LBoot;
using SLua;

public class FI
{
    private static string configPath = null;

    public static string ManifestPath
    {
        get
        {
            return FI.PersistPath + manifestFile;
        }
    }

    private static string manifestFile = "bundles.bin";

    public static string ManifestFile
    {
        get
        {
            return manifestFile;
        }
    }

    public static string BuildPath
    {
        get
        {
			Debug.Log ("Application.dataPath:"+Application.dataPath);
            return Path.GetFullPath(Application.dataPath + "/../AssetBundles/" + FI.TargetPlatform + "/");
        }
    }

    public static string ConfigPath
    {
        get
        {
            if (configPath == null)
                return Path.GetFullPath(Application.dataPath + "/../../rs/game-config/");
            else
                return configPath;
        }
        set
        {
            configPath = value;
        }
    }

    public static string PersistRoot
    {
        get
        {
            return Application.persistentDataPath + "/";
        }
    }

    public static string RawRoot
    {
        get
        {
            return Application.streamingAssetsPath + "/";
        }
    }

    public static string RawPath
    {
        get
        {
            return FI.RawRoot + "bundles/";
        }
    }

    public static string PersistPath
    {
        get
        {
            return FI.PersistRoot + "bundles/";
        }
    }

    public static string IOS_PROJECT_BUNDLE_PATH = "proj.ios/Data/Raw/bundles/";
    public static string ANDROID_PROJECT_BUNDLE_PATH = "proj.android/race/src/main/assets/bundles/";

    public static string AssetBundleExtension
    {
        get
        {
            return ".ab";
        }
    }

    public static string ProjectBundlePath
    {
        get
        {
            if (TargetPlatform == "ios")
            {
                return IOS_PROJECT_BUNDLE_PATH;
            }
            else
            {
                return ANDROID_PROJECT_BUNDLE_PATH;
            }
        }
    }

    private static string targetPlatform = "";

    public static string TargetPlatform
    {
        get
        {
            if (targetPlatform == "")
            {
                string target = "ios";

#if UNITY_STANDALONE_OSX
                target = "osx";
#elif UNITY_IPHONE
                target = "ios";
#elif UNITY_ANDROID
                target = "android";
#endif
                return target;
            }
            else
            {
                return targetPlatform;
            }
        }
        set
        {
            targetPlatform = value;
        }
    }

    public static void Log(string msg)
    {
        LogUtil.Debug(msg);
    }

    public static void PackFiles(string filename, string directory)
    {
        try
        {
            FastZip fz = new FastZip();
            fz.CreateEmptyDirectories = true;
            fz.CreateZip(filename, directory, true, "");
            fz = null;
        }
        catch (Exception e)
        {
            LogUtil.Error(e.ToString());
        }
    }

    public static bool UnpackFiles(string file, string dir)
    {
        try
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            ZipInputStream s = new ZipInputStream(File.OpenRead(file));

            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {

                string directoryName = Path.GetDirectoryName(theEntry.Name);
                string fileName = Path.GetFileName(theEntry.Name);

                if (directoryName != String.Empty)
                    Directory.CreateDirectory(dir + directoryName);

                if (fileName != String.Empty)
                {
                    FileStream streamWriter = File.Create(dir + theEntry.Name);

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }

                    streamWriter.Close();
                }
            }
            s.Close();
            return true;
        }
        catch (Exception e)
        {
            LogUtil.Debug(e.ToString());
            return false;
        }
    }

    public static void copyToProject()
    {
        string srcPath = FI.BuildPath;
		Debug.Log (srcPath);
        string targetPath = FI.ProjectBundlePath;

        if (!Directory.Exists(targetPath))
            Directory.CreateDirectory(targetPath);

        List<FileInfo> files = new List<FileInfo>();
        getSubFiles(srcPath, files, 1);


        for (int i = 0; files != null && i < files.Count; i++)
        {
            string subPath = files[i].FullName.Substring(srcPath.Length);
            if (files[i].FullName.EndsWith(FI.TargetPlatform))
                continue;
            if (files[i].FullName.EndsWith(".svn"))
                continue;
            string targetFullFilePath = targetPath + subPath;

			Debug.Log (targetFullFilePath);
			Debug.Log (files [i].FullName);
            string path = Path.GetDirectoryName(targetFullFilePath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            byte[] fileBytes = File.ReadAllBytes(files[i].FullName);
            File.WriteAllBytes(targetFullFilePath, fileBytes);
        }
    }

    protected static void getSubFiles(string path, List<FileInfo> fileList, int type)
    {
        if (type == 1)
        { // directory
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] subFolders = dir.GetDirectories();
            FileInfo[] subFiles = dir.GetFiles();
            for (int i = 0; subFolders != null && i < subFolders.Length; i++)
            {
                getSubFiles(subFolders[i].FullName, fileList, 1);
            }

            for (int i = 0; subFiles != null && i < subFiles.Length; i++)
            {
                getSubFiles(subFiles[i].FullName, fileList, 2);
            }
        }
        else if (type == 2)
        { // file
            FileInfo file = new FileInfo(path);
            if (!file.Extension.Equals(".meta"))
            {
                fileList.Add(file);
            }
        }
    }
}