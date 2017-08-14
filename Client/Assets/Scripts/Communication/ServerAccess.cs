using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AssemblyCSharp
{
    public class ServerAccess
    {

		private static ServerAccess instance;

		private Socket client;
        private IPEndPoint serverAddress;
        Sender sender;
        Thread senderThread;
		Listener listener;
		Thread listenerThread;
        List<string> toSend;
        List<string> recieved;
		private Object sendLock = new object();
		private Object readLock = new object();

		private void IniciateConnection(){
            client.Connect(serverAddress);
        }

        public void StopConnection(){
            sender.stopSender();
            listener.stopListener();
            client.Close();
            instance = null;
        }
    
		private ServerAccess(string IP_ADD= "127.0.0.1", int Port=8888) //10.212.98.196   //"127.0.0.1"
		{
            recieved = new List<string>();
            toSend = new List<string>();
			serverAddress = new IPEndPoint(IPAddress.Parse(IP_ADD), Port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(serverAddress);
            sender = new Sender(this);
            listener = new Listener(this);

            senderThread = new Thread(sender.runSender);
            listenerThread = new Thread(listener.runListener);
            senderThread.Start();
            listenerThread.Start();
        }

        public Socket Client
        {
            get
            {
                return client;
            }
        }

        public void Recived(string data)
        {
            lock(readLock){
                recieved.Add(data);
            }
        }



		public string Sended()
		{
            string data = "";
            lock (sendLock)
			{
                if (toSend.Count>0){
                    data = toSend[0];
                    toSend.RemoveAt(0);
                }
			}
            return data;
		}

        public string Reciever()
        {
            string data = "";
            lock(readLock){
                if (recieved.Count > 0)
                {
                    data = recieved[0];
                    recieved.RemoveAt(0);
                }
            }
            return data;
        }

		public void Sender(String send)
		{
            lock(sendLock){
                toSend.Add(send);
            }
		}

		public static ServerAccess Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ServerAccess();
				}
				return instance;
			}
		}

    }
}
