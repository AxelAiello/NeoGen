using System;
namespace AssemblyCSharp
{
    public class Sender
    {

        private volatile bool _shouldStop = false;
        private ServerAccess serverAccess;

        public Sender(ServerAccess serverAccess)
        {
            this._shouldStop = false;
            this.serverAccess = serverAccess;
        }

        public void runSender(){
            
			while (!_shouldStop)
			{
                
                string toSend = serverAccess.Sended();
                if (toSend != "")
                {
                    int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
                    byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
                    byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
                    serverAccess.Client.Send(toSendLenBytes);
                    serverAccess.Client.Send(toSendBytes);
                }
				Console.WriteLine("worker thread: working...");
			}
        }

        public void stopSender(){
            _shouldStop = true;
        }


    }
}
