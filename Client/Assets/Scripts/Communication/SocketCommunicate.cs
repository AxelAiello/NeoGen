﻿using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;


namespace AssemblyCSharp
{
    public class SocketCommunicate : Comunicate
    {
		TcpClient client;
		NetworkStream stream;
		private static String IP_MAC = "127.0.0.1";
		private String IP;
		private static Int32 PORT = 8888;
        // if the player doesn't want to connect to the server and play locally
        bool isLocal = false;

        // Create a TCP/IP  socket.
        public SocketCommunicate()
        {
        }

        public string AskServer(string type, List<string> options)
        {
			try
			{
				string toSend = "Hello!";

				IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(IP_MAC), PORT);

				Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				clientSocket.Connect(serverAddress);

				// Sending
				int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
				byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
				byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
				clientSocket.Send(toSendLenBytes);
				clientSocket.Send(toSendBytes);

				// Receiving
				byte[] rcvLenBytes = new byte[4];
				clientSocket.Receive(rcvLenBytes);
				int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
				byte[] rcvBytes = new byte[rcvLen];
				clientSocket.Receive(rcvBytes);
				String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

				Console.WriteLine("Client received: " + rcv);

				clientSocket.Close();
                return "Well Done";
            }
			catch (ArgumentNullException e)
			{
				return "ArgumentNullException: " + e;
			}
			catch (SocketException e)
			{
				return "SocketException: " + e;
			}
			

			
        }
		
    }
}

