using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace HES_Monitor
{
    class Helper
    {
        public static bool portOpen(string host, int port)
        {
            if (!Enumerable.Range(1, 65535).Contains(port)) throw new ArgumentException();

            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(host, port);
                tcpClient.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void runCommands(List<string> commands)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            //info.WindowStyle = ProcessWindowStyle.Hidden;
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    foreach (string command in commands)
                    {
                        sw.WriteLine(command);
                    }
                    sw.WriteLine("exit");
                }
            }
        }

        public static IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }


}
