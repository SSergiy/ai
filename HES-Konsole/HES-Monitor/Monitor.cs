using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Collections;


namespace HES_Monitor
{
    class Monitor
    {
        IDictionary<string, DateTime> runningInstances = new Dictionary<string, DateTime>();
        int timeoutMillis = 3000;

        public void start()
        {
            // Heartbeat-Listener
            Thread heartbeatReceiver = new Thread(new ThreadStart(HeartbeatReceiver));
            heartbeatReceiver.Start();

            // nicht mehr laufende Instanzen entfernen
            Thread instancesCleaner = new Thread(new ThreadStart(InstancesCleaner));
            instancesCleaner.Start();

            // RabbitMQ + MySQL starten
            if (!Helper.portOpen("localhost", 3306))
            {
                startVagrant();
            }

            // Lokal
            startLocal(@"D:\malte\documents\visual studio 2010\Projects\HeartbeatTest\HeartbeatTest\bin\Debug\HeartbeatTest.exe", "client1");

            // Remote
            startRemoteProgram("192.168.0.120", "client2");


        }

        void InstancesCleaner()
        {
            IDictionary<string, DateTime> tmp = new Dictionary<string, DateTime>();

            foreach (string client in runningInstances.Keys)
            {
                if (DateTime.Now.Subtract(runningInstances[client]).TotalMilliseconds < timeoutMillis)
                {
                    tmp.Add(client, runningInstances[client]);
                }
            }
            runningInstances = tmp;
        }


        void HeartbeatReceiver()
        {
            System.Net.Sockets.UdpClient server = new System.Net.Sockets.UdpClient(15000);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] data = new byte[1024];
                data = server.Receive(ref sender);
                string stringData = Encoding.ASCII.GetString(data, 0, data.Length);

                runningInstances.Add("" + sender.Address, DateTime.Now);

                //Console.WriteLine("Response from " + sender.Address + Environment.NewLine + "Message: " + stringData);
            }
        }

        void startVagrant()
        {
            List<string> c = new List<string>();
            c.Add("cd ../../../..");
            c.Add("cd Server");
            c.Add("vagrant up");
            Helper.runCommands(c);
        }

        void startRemoteProgram(string ip, string clientName)
        {
            List<string> c = new List<string>();
            c.Add("cd ../../../..");
            c.Add("cd Tools");
            c.Add(@"PsExec \\" + ip + @" -d -u Administrator -p admin C:\Debug\HeartbeatTest.exe " + clientName + " " + Helper.LocalIPAddress());
            Helper.runCommands(c);
        }

        static void startLocal(string path, string clientName)
        {
            List<string> c = new List<string>();
            c.Add(@"""" + path + @""" " + clientName + " " + Helper.LocalIPAddress());
            Helper.runCommands(c);
        }
    }
}
