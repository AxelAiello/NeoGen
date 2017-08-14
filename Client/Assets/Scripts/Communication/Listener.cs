﻿using System;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
namespace AssemblyCSharp
{
    public class Listener
    {
		private volatile bool _shouldStop;
        private ServerAccess serverAccess;
        public BinaryReader networkStream;

        public Listener( ServerAccess serverAccess)
        {
            this._shouldStop = false;
            this.serverAccess = serverAccess;
            this.networkStream = new BinaryReader(new NetworkStream(serverAccess.Client));
        }

		public void runListener()
		{
			while (!_shouldStop)
			{
            //    Debug.Log("thererererrerererererer");
                byte []rcvLenBytes = new byte[4];
                rcvLenBytes = networkStream.ReadBytes(4);
                Debug.Log("post there " + System.BitConverter.ToInt32(rcvLenBytes, 0) + " aze");

                byte[] rcvText = new byte[System.BitConverter.ToInt32(rcvLenBytes, 0)];
                rcvText = networkStream.ReadBytes(System.BitConverter.ToInt32(rcvLenBytes, 0));
				Debug.Log("post second " + System.Text.Encoding.ASCII.GetString(rcvText) + " aze");

                serverAccess.Recived(System.Text.Encoding.ASCII.GetString(rcvText));
                Debug.Log(rcvText);
			}
		}

		public void stopListener()
		{
			_shouldStop = true;
		}

    }
}
