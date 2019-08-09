using UnityEngine;
using System;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

public class VerifyCenter {
    private static Queue<string> recv_queue = new Queue<string>(); 
    private static Queue<string> send_queue = new Queue<string>(); 

    private static Socket ClientSocket = null;
    private static Thread sockthread;
    private static Thread sendthread;
    private static IPEndPoint iep;
    private static bool terminated = false;

    private static string addr;
    private static int port;

    ///////////////////////////////////////////////////////////////////////////

    public static void Start(string _addr, int _port)
    {
    	Debug.Log("VerifyCenter begin");

        addr = _addr;
        port = _port;

        terminated = false;

        InitConnect();
    }
	
    public static void Teminate()
    {
        terminated = true;
        if (ClientSocket != null)
            ClientSocket.Close();
            
        sockthread.Abort();
        sendthread.Abort();
    }

    public static void pushMessage(string clientSendValue)
    {
        /*if (ClientSocket != null && ClientSocket.Connected)
        {
            socketSend(clientSendValue);
        }
        else
        {*/
            lock(send_queue)
            {
                send_queue.Enqueue(clientSendValue);
            }

            //Debug.Log("verify server not connected！");
        //}
    }

    public static string popMessage()
    {
        string msg = "";
        lock(recv_queue)
        {
            if (recv_queue.Count > 0)
            {
                msg = recv_queue.Dequeue();
            }            
        }
        return msg;
    }

    ///////////////////////////////////////////////////////////////////////////
    
    private static void InitConnect()
    {
        string ip = addr;
        IPAddress ipa = IPAddress.Parse(ip);
        iep = new IPEndPoint(ipa, port);
  
        lock(recv_queue)
        {
            while(recv_queue.Count > 0)
            {
                recv_queue.Dequeue();
            }      
        }
        lock(send_queue)
        {
            while(send_queue.Count > 0)
            {
                send_queue.Dequeue();
            } 
        }
                  
        sockthread = new Thread(new ThreadStart(doSocket));
        sockthread.IsBackground = true;    
        sockthread.Start();

        sendthread = new Thread(new ThreadStart(sendBuff));
        sendthread.IsBackground = true;    
        sendthread.Start();
    }

    private static void sendBuff()
    {
        while (terminated == false)
        {
            if (ClientSocket != null && ClientSocket.Connected)
            {
                string msg = "";

                lock(send_queue)
                {
                    if (send_queue.Count > 0)
                    {
                        msg = send_queue.Dequeue();
                    }
                }
                if (msg != "")
                {
                    socketSend(msg);
                }
                else if(terminated == false)
                {
                    Thread.Sleep(500);  
                }
            }
            else
            {
                Thread.Sleep(500);  
            }
        }
    }
  
    private static void doSocket()
    {
        byte[] tmp_buffer = null;
        int tmp_len = 0;
        bool reconnect = true;

        while (terminated == false)
        {
            while (reconnect == true && terminated == false)
            {
                try
                {  
                    Debug.Log("connectting verify server...");
                    ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ClientSocket.Connect(iep);

                    Debug.Log("verify connected ok!");
                    reconnect = false;
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);

                    reconnect = true;
                    Thread.Sleep(1000);  
                }
            }

            if (terminated == true) break;

            try
            {
                byte[] bytes = new byte[4096];
                int i = ClientSocket.Receive(bytes);
                Debug.Log("verify Client Receive Data:" + i + "byte");
                if(i <= 0)
                {
                    reconnect = true;
                    Closed();

                    Thread.Sleep(1000);  
                    continue;
                }

                //Copy data to main buffer
                byte[] main_buffer = null;
                int main_pos = 0;

                if (tmp_buffer != null && tmp_len > 0)
                {
                    main_pos = tmp_len+i;                    
                    Array.Copy(bytes, 0, tmp_buffer, tmp_len, i);
                    main_buffer = tmp_buffer;
                }
                else
                {
                    main_pos = i;
                    main_buffer = new byte[main_pos];

                    Array.Copy(bytes, 0, main_buffer, 0, i);
                }

                if(main_pos >= 2)
                {
                    int index = 0;
                    int headLengthIndex = index + 2;
                    byte[] head;

                    //Split package
                    while(true)
                    {
                        //head is 2 bytes
                        head = new byte[2];
                        headLengthIndex = index + 2;
                        //get pkg head
                        Array.Copy(main_buffer, index, head, 1, 1);
                        Array.Copy(main_buffer, index+1, head, 0, 1);
                        //get body len from pkg head
                        short length = BitConverter.ToInt16(head,0);
                        //Debug.Log("pkg" + index + " head len:" + length);

                        if(length > 0 && headLengthIndex+length <= main_pos) 
                        {
                            byte[] data = new byte[length];
                            //copy body data
                            Array.Copy(main_buffer, headLengthIndex, data, 0, length);

                            string strev = System.Text.Encoding.Default.GetString(data);
                            lock(recv_queue)
                            {
                                recv_queue.Enqueue(strev);
                            }                            

                            //position to next head
                            index  =  headLengthIndex + length; 
                            if (index+2 >= main_pos)
                            {
                                break;
                            }
                        }else
                        {
                            break;
                        }
                    }

                    //move main buffer read pos
                    if (index > 0)
                    {
                        tmp_buffer = new byte[8192];
                        tmp_len = main_pos-index;

                        Array.Copy(main_buffer, index, tmp_buffer, 0, tmp_len);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("Failed to clientSocket error." + e);
            }
        }
    }

    private static void Closed()
    {
        ClientSocket.Shutdown(SocketShutdown.Both);
        ClientSocket.Close();
        Debug.Log ("verify Socket closed");
    }

    private static void socketSend(string clientSendValue)
    {
        byte[] SendMessage = new byte[4096];
  
        SendMessage = Encoding.ASCII.GetBytes(clientSendValue);

        int n = SendMessage.Length;
        byte[] s = new byte[2];
        s[0] = (byte)(n >> 8 & 0xff);
        s[1] = (byte)(n & 0xff);

        int i = ClientSocket.Send(s);
        if (i <=0){
            Closed();
            return;
        }
        i = ClientSocket.Send(SendMessage);
        if (i <=0){
            Closed();
            return;
        }
        Debug.Log("verify send data " + clientSendValue);
    }
}
