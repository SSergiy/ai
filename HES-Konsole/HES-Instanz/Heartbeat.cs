using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace HES_Instanz
{
    class Heartbeat : IDisposable
    {
        string HostIp;
        int ClientId;

        public Heartbeat(int clientId, string hostIp)
        {
            HostIp = hostIp;
            ClientId = clientId;
        }

        Timer heartbeatTimer;

        public void start()
        {
            heartbeatTimer = new Timer(HeartbeatSender, 5, 0, 1000);
        }


        private void HeartbeatSender(Object state)
        {
            SendUdpPacket("client" + ClientId);
        }

        private void SendUdpPacket(string message)
        {
            System.Net.Sockets.UdpClient sock = new System.Net.Sockets.UdpClient();
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(HostIp), 15000);
            byte[] data = Encoding.ASCII.GetBytes(message);
            sock.Send(data, data.Length, iep);
            sock.Close();
        }

        public void Dispose()
        {
            heartbeatTimer.Dispose();
        }
    }
}
