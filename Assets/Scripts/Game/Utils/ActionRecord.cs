using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using SLua;


namespace Game
{
    [CustomLuaClassAttribute]
    public class ActionRecord
    {
        private string userDataPath = null;
        private string fileName = null;
        private string filePath = null;
        private FileStream fsWrite = null;
        private FileStream fsRead = null;

        public static ActionRecord arWrite = null;
        public static ActionRecord arRead = null;
        public static int keepCount = 20;
        public static string pid = "";

        public int actionOffset = 0;
        public int readOffset = 0;
        public int readCount = 0;
        public int readIndex = 0;

        public Thread writeThread = null;
        public AutoResetEvent exitEvent = null;
        public int waitTime = 20;
        public object locker = new object();
        public List<Byte[]> actions = new List<byte[]>();
        public bool combatFinish = false;

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public string UserDataPath
        {
            get
            {
                if (userDataPath == null)
                {
                    userDataPath = Application.persistentDataPath + "/userdata/replays/"+pid+"/";
                    Directory.CreateDirectory(userDataPath);
                }
                return userDataPath;
            }
            set
            {
                userDataPath = value;
            }
        }

        public ActionRecord(string name)
        {
            fileName = name;
            filePath = UserDataPath + fileName;
        }


        public bool WriteActions()
        {
            lock (locker)
            {
                if (actions.Count == 0)
                    return true;

                while (actions.Count > 0)
                {
                    Byte[] data = actions[0];
                    if (!arWrite.writeAction(data))
                        return false;
                    actions.RemoveAt(0);
                }
            }
            return true;
        }

        public void WriteProc()
        {
            arWrite.openAppend();

            while (true)
            {
                if (!WriteActions())
                    break;

                if (exitEvent.WaitOne(waitTime))
                {
                    arWrite.writeFinishFlag();
                    arWrite.closeWrite();
                    break;
                }
            }

        }
        //////////////////////////////////
        public static void pushAction(Byte[] data)
        {
            if (arWrite == null) return;

            lock (arWrite.locker)
            {
                arWrite.actions.Add(data);
            }
        }

        public static void stopRecord(bool isFinish)
        {
            if (arWrite == null)
                return;

            arWrite.combatFinish = isFinish;

            arWrite.exitEvent.Set();
            arWrite.writeThread.Join();
            arWrite = null;
        }


        public static bool isCombatFinish()
        {
            if (arRead == null)
                return false;

            return arRead.readFinishFlag();
        }

        public static void setPid(string _pid)
        {
            pid = _pid;
        }

        public static void startRecord(string clientVer, string fileName, long timestamp, string roomInfo)
        {
            if (arWrite != null)
                return;

            bool fileExist = false;
            arWrite = new ActionRecord(fileName);
            arWrite.openWrite(out fileExist);
            if (!fileExist)
            {
                arWrite.writeHead(clientVer, timestamp, roomInfo);
            }
            arWrite.closeWrite();

            arWrite.writeThread = new Thread(arWrite.WriteProc);
            arWrite.exitEvent = new AutoResetEvent(false);

            arWrite.actions.Clear();
            arWrite.writeThread.Start();
        }

        public static void removeRecord(string fileName)
        {
            ActionRecord tmp = new ActionRecord(fileName);
            tmp.delete();
        }

        public static bool startRead(string fileName)
        {
            stopRead();
            arRead = new ActionRecord(fileName);
            return arRead.openRead();
        }

        public static void stopRead()
        {
            if (arRead != null)
                arRead.closeRead();
            arRead = null;
        }

        public static void getHead(out string clientVer, out long timestamp, out string roomInfo, out bool isFinish)
        {
            timestamp = 0;
            roomInfo = "";
            clientVer = "";
            isFinish = false;
            if (arRead != null)
            {
                arRead.readHead(out clientVer, out timestamp, out roomInfo, out isFinish);
            }
        }

        public static void getFrameCount(out int count)
        {
            count = 0;
            if (arRead != null)
            {
                count = arRead.readActionCount();
            }
        }

        public static void popAction(out Byte[] data)
        {
            data = null;

            if (arRead.readOffset == 0)
            {
                arRead.readCount = arRead.readActionCount();
            }

            if (arRead.readIndex >= arRead.readCount)
                return;

            if (arRead.readCount == 0)
                return;
            
            int read = 0;
            arRead.readAction(out data, arRead.readOffset, out read);
            arRead.readOffset += read;
            arRead.readIndex++;
        }


        public static string bytesToString(Byte[] data)
        {
            string ret = "";
            int lenChar = sizeof(char);
            int lenData = data.GetLength(0);
            for (int i = 0; i < lenData; i += lenChar)
            {
                char c = System.BitConverter.ToChar(data, i);
                ret += c;
            }
            return ret;

        }

        public static void setKeepReplayCount(int count)
        {
            keepCount = count;
        }


        public static string[] getAllReplays()
        {
            string replayDir = Application.persistentDataPath + "/userdata/replays/" + pid + "/";
            if (!File.Exists(replayDir))
            {
                Directory.CreateDirectory(replayDir);
            }
            string[] paths = Directory.GetFiles(replayDir);
            int count = paths.Length;
            string[] files = new string[count];
            for (int i = 0; i < count; ++i)
            {
                string[] ds = paths[i].Split('/');
                int len = ds.Length;
                files[i] = ds[len - 1];
            }

            Array.Sort(files);
            Array.Reverse(files);

            //keep latest 20 records
            if (files.Length > keepCount)
            {
                string[] ret = new string[keepCount];
                for (int i = 0; i < keepCount; ++i)
                {
                    ret[i] = files[i];
                }
                return ret;
            }

            return files;
        }

        /////////////////////////////
        public bool delete()
        {
            if (fileName == null)
                return false;

            try
            {
                if(File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return true;
            }catch(Exception ex)
            {
                Debug.LogError(ex.Message + "[delete]");
                return false;
            }
        }

        public bool openWrite(out bool exist)
        {
            exist = false;
            if (fileName == null)
                return false;

            try
            {
                Debug.Log(filePath);
                if (File.Exists(filePath))
                {
                    exist = true;
                    fsWrite = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                }
                else
                {
                    exist = false;
                    fsWrite = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message + "[openWrite]");
                return false;
            }

            return fsWrite != null;
        }

        public bool openAppend()
        {
            if (fileName == null)
                return false;
            try
            {
                fsWrite = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message + "[openAppend]");
            }

            return fsWrite != null;
        }

        public void closeWrite()
        {
            lock (locker)
            {
                if (fsWrite != null)
                    fsWrite.Close();
            }
        }

        public bool openRead()
        {
            if (fileName == null)
                return false;

            try
            {
                if (!File.Exists(filePath))
                    return false;
                
                fsRead = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message + "[openRead]");
            }

            return fsRead != null;
        }

        public void closeRead()
        {
            if (fsRead != null)
                fsRead.Close();
        }

        public void calcActionOffset()
        {
            if (actionOffset != 0)
                return;

            if (fsRead != null)
            {
                fsRead.Seek(0, SeekOrigin.Begin);
                Byte[] blc = new byte[4];
                fsRead.Read(blc, 0, 4);
                int sic = System.BitConverter.ToInt32(blc, 0);

                fsRead.Seek(4 + sic + 8, SeekOrigin.Begin);
                Byte[] blr = new byte[4];
                fsRead.Read(blr, 0, 4);
                int sir = System.BitConverter.ToInt32(blr, 0);

                actionOffset = 4 + sic + 8 + 4 + sir + 1;
            }

            if(fsWrite != null)
            {
                fsWrite.Seek(0, SeekOrigin.Begin);
                Byte[] blc = new byte[4];
                fsWrite.Read(blc, 0, 4);
                int sic = System.BitConverter.ToInt32(blc, 0);

                fsWrite.Seek(4 + sic + 8, SeekOrigin.Begin);
                Byte[] blr = new byte[4];
                fsWrite.Read(blr, 0, 4);
                int sir = System.BitConverter.ToInt32(blr, 0);

                actionOffset = 4 + sic + 8 + 4 + sir + 1;
            }
        }

        public bool readHead(out string clientVer, out long timestamp, out string roomInfo, out bool isFinish)
        {
            timestamp = 0;
            roomInfo = "";
            clientVer = "";
            isFinish = false;

            if (fileName == null)
            {
                return false;
            }

            try
            {
                fsRead.Seek(0, SeekOrigin.Begin);
                //read client version count
                Byte[] blc = new byte[4];
                fsRead.Read(blc, 0, 4);
                int sic = System.BitConverter.ToInt32(blc, 0);

                //read client version
                Byte[] brc = new byte[sic];
                fsRead.Read(brc, 0, sic);
                int lenChar = sizeof(char);
                for (int i = 0; i < brc.GetLength(0); i += lenChar)
                {
                    char c = System.BitConverter.ToChar(brc, i);
                    clientVer += c;
                }

                //read timestamp
                Byte[] bt = new Byte[8];
                fsRead.Read(bt, 0, 8);
                timestamp = System.BitConverter.ToInt64(bt, 0);

                //read room information count
                Byte[] bl = new byte[4];
                fsRead.Read(bl, 0, 4);
                int sir = System.BitConverter.ToInt32(bl, 0);
                 
                //read room information
                Byte[] br = new byte[sir];
                fsRead.Read(br, 0, sir);
                for (int i = 0; i < br.GetLength(0); i+=lenChar)
                {
                    char c = System.BitConverter.ToChar(br, i);
                    roomInfo += c;
                }

                //read is finished combat
                int nFi = fsRead.ReadByte();
                isFinish = (nFi == 1);

                //assign action data offset
                actionOffset = 4 + sic + 8 + 4 + sir + 1;

                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message + "[readHead]");
                if (fsRead != null)
                    fsRead.Close();
                return false;
            }
        }

        /// <summary>
        /// head data structure
        /// |         4   |      x     |      8     |         4       |      x     |     1   |       4     |    
        /// |version count|   version  | start time | room info count | room info  |  finish | action count| 
        /// |                            actionOffset                              |
        /// </summary>
        public bool writeHead(string clientVer, long timestamp, string roomInfo)
        {
            if (fsWrite == null)
                return false;

            try
            {
                fsWrite.Seek(0, SeekOrigin.Begin);

                //write client version 
                char[] ccv = clientVer.ToCharArray();
                int lenCCV = ccv.GetLength(0);
                int sic = 0;
                for (int i = 0; i < lenCCV; ++i)
                {
                    char c = ccv[i];
                    Byte[] _bc = System.BitConverter.GetBytes(c);
                    sic += _bc.GetLength(0);
                }

                Byte[] bc = new Byte[sic];
                int cur = 0;
                for (int i = 0; i < lenCCV; ++i)
                {
                    char c = ccv[i];
                    Byte[] _bc = System.BitConverter.GetBytes(c);
                    _bc.CopyTo(bc, cur);
                    cur += _bc.GetLength(0);
                }

                //write length of client version
                Byte[] blc = System.BitConverter.GetBytes(sic);
                fsWrite.Write(blc, 0, 4);

                //write client version
                fsWrite.Write(bc, 0, sic);


                //write timestamp
                Byte[] bt = System.BitConverter.GetBytes(timestamp);
                fsWrite.Write(bt, 0, bt.GetLength(0));


                char[] cri = roomInfo.ToCharArray();
                int len = cri.GetLength(0);
                int sir = 0;
                for (int i = 0; i < len; ++i)
                {
                    char c = cri[i];
                    Byte[] _bc = System.BitConverter.GetBytes(c);
                    sir += _bc.GetLength(0);
                }

                Byte[] br = new Byte[sir];
                cur = 0;
                for (int i = 0; i < len; ++i)
                {
                    char c = cri[i];
                    Byte[] _bc = System.BitConverter.GetBytes(c);
                    _bc.CopyTo(br, cur);
                    cur += _bc.GetLength(0);
                }

                //write length of room information
                Byte[] bl = System.BitConverter.GetBytes(sir);
                fsWrite.Write(bl, 0, 4);

                //write room information
                fsWrite.Write(br, 0, sir);

                //defaule combat finish flag is false(0)
                fsWrite.WriteByte(0);

                //mark action data start offset
                actionOffset = 4 + sic + 8 + 4 + sir + 1;

                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message + "[writeHead]");
                if (fsWrite != null)
                    fsWrite.Close();
                return false;
            }
        }

        public bool writeFinishFlag()
        {
            if (fsWrite == null)
                return false;

            calcActionOffset();
            int offset = actionOffset - 1;
            fsWrite.Seek(offset, SeekOrigin.Begin);
            Byte bFinish = 0;
            if (combatFinish)
                bFinish = 1;
            fsWrite.WriteByte(bFinish);

            return true;
        }

        public bool readFinishFlag()
        {
            if (fsRead == null)
                return false;

            calcActionOffset();
            int offset = actionOffset - 1;
            fsRead.Seek(offset, SeekOrigin.Begin);
            int isFinish = fsRead.ReadByte();

            return isFinish == 1;
        }

        public int readActionCount()
        {
            if (fileName == null)
                return 0;

            try
            {
                calcActionOffset();
                fsRead.Seek(actionOffset , SeekOrigin.Begin);
                byte[] bl = new Byte[4];
                fsRead.Read(bl, 0, 4);

                return System.BitConverter.ToInt32(bl, 0);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message + "[readActionCount]");
                if (fsRead != null)
                    fsRead.Close();
                return 0;
            }
        }

        public bool readAction(out Byte[] data, int offset, out int outlen)
        {
            data = null;
            outlen = 0;
            
            if (fileName == null)
                return false;

            try
            {
                calcActionOffset();

                offset += actionOffset + 4;
                fsRead.Seek(offset, SeekOrigin.Begin);

                //read length of aciton data 
                Byte[] bl = new Byte[4];
                fsRead.Read(bl, 0, 4);
                int len = System.BitConverter.ToInt32(bl, 0);

                //read action data
                fsRead.Seek(offset + 4, SeekOrigin.Begin);
                data = new Byte[len];
                fsRead.Read(data, 0, len);

                outlen = 4 + len;
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message + "[readAction]");
                if(fsRead != null)
                    fsRead.Close();
                return false;
            }
        }

        public bool writeAction(Byte [] data)
        {
            if (fsWrite == null)
                return false;

            if (data == null)
                return true;

            try
            {   
                calcActionOffset();

                //modify action data count
                fsWrite.Seek(actionOffset, SeekOrigin.Begin);

                Byte[] bl = new byte[4];
                fsWrite.Read(bl, 0, 4);

                int len = System.BitConverter.ToInt32(bl, 0);
                len ++;

                fsWrite.Seek(actionOffset, SeekOrigin.Begin);
                bl = System.BitConverter.GetBytes(len);
                fsWrite.Write(bl, 0, bl.GetLength(0));

                //append action with data's length ahead
                fsWrite.Seek(0, SeekOrigin.End);
                int dataLen = data.GetLength(0);
                bl = System.BitConverter.GetBytes(dataLen);
                len = bl.GetLength(0);

                fsWrite.Write(bl, 0, len);

                fsWrite.Write(data, 0, dataLen);
                return true;
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.Message+"[writeAction]");
                if (fsWrite != null)
                    fsWrite.Close();
                
                return false;
            }
        }

    }
}
