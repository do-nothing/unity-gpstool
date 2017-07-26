using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using LitJson;
using System.Threading;

namespace Microwise.Guide.NetConn
{
    public class UdpMessenger : Messenger
    {
        private static UdpMessenger instance;
        private Socket server;
        private IPEndPoint ipEndPoint;
        private ProcessMessage processMessage;
        private Thread receiveThread;

        private UdpMessenger(){
        
        }

        public static UdpMessenger getInstance(string ip, int port)
        {
            if (instance != null)
                return instance;
            instance = new UdpMessenger();
            instance.ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            instance.server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint point = new IPEndPoint(IPAddress.Any, 6667);
            instance.server.Bind(point);

            instance.startReceiver();
            //instance.startHeartbeat();

            return instance;
        }

        public void destroy()
        {
            instance = null;
            receiveThread.Abort();
            server.Close();
        }

        public void sendMessage(JsonData json)
        {
            json["timestamp"] = GetTimeStamp();
            string str = json.ToJson();
            byte[] data = Encoding.UTF8.GetBytes(str);
            server.SendTo(data, data.Length, SocketFlags.None, ipEndPoint);

            if (json["strategy"].ToString() != "heatbeat" && json["contentBean"]["command"].ToString() != "processGuideInfo")
            {
                Debug.Log(str);
            }
        }

        public void addMessageListener(ProcessMessage processMessage)
        {
            this.processMessage = processMessage;
        }

        private void startReceiver()
        {
            receiveThread = new Thread(new ThreadStart(receiver));
            receiveThread.Start();
        }

        private void startHeartbeat()
        {
            new Thread(new ThreadStart(heartbeat)).Start();
        }

        private void heartbeat()
        {
            string str = "{\"id\":\"guide machine\",\"target\":\"server\",\"logType\":\"nolog\",\"strategy\":\"guide_heartbeat\",\"quality\":0,\"timestamp\":1494825498577," +
                "\"contentBean\":{}}";
            JsonData json = JsonMapper.ToObject(str);
            
            while (instance != null)
            {
                sendMessage(json);
                Thread.Sleep(5000);
            }
        }

        private void receiver()
        {
            while (instance != null)
            {
                byte[] data = new byte[548];
                EndPoint ep = new IPEndPoint(IPAddress.Any, 0); ;
                
                int intReceiveLength = server.ReceiveFrom(data, ref ep);
                string strReceiveStr = Encoding.UTF8.GetString(data, 0, intReceiveLength);
                //Debug.Log(strReceiveStr);
                JsonData json = JsonMapper.ToObject(strReceiveStr);
                processMessage(json);
            }
        }

        private static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * 1000).ToString();
        }
    }
}
