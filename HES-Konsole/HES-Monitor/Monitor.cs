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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RabbitMQ.Client;
using System.Web.Script.Serialization;
using _0TypenKomponente;

namespace HES_Monitor
{
    public class Monitor : MarshalByRefObject, IMonitor
    {
        static IDictionary<string, DateTime> runningInstances = new Dictionary<string, DateTime>();
        int timeoutMillis = 3000;

        public EventHandler Changed;

        public int queueSize()
        {
            var w = new WebClient();
            w.Credentials = new NetworkCredential("guest", "guest", "");

            var json = w.DownloadString("http://localhost:15672/api/queues");

            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

            dynamic obj = serializer.Deserialize(json, typeof(object));

            for (int i = 0; i < obj.Length; i++)
            {
                if (obj[i].name == "in")
                {
                    return obj[i].messages;
                }
            }
            return 0;
        }

        public IDictionary<string, DateTime> getRunningInstances()
        {
            return runningInstances;
        }

        public void start()
        {
            this.Changed += new EventHandler(printRunningInstances);

            // Heartbeat-Listener
            Thread heartbeatReceiver = new Thread(HeartbeatReceiver);
            heartbeatReceiver.Start();

            // nicht mehr laufende Instanzen entfernen
            Timer instancesCleaner = new Timer(InstancesCleaner, 5, 0, timeoutMillis);

            // RabbitMQ + MySQL starten
            //if (!Helper.portOpen("localhost", 3306))
            //{
            //    startVagrant();
            //}

            // Lokal
            //startLocal(@"D:\malte\documents\visual studio 2010\Projects\HeartbeatTest\HeartbeatTest\bin\Debug\HeartbeatTest.exe", "client1");
            //startLocal(@"D:\malte\documents\visual studio 2010\Projects\HeartbeatTest\HeartbeatTest\bin\Debug\HeartbeatTest.exe", "client2");


            //Process.Start("HES-Instanz.exe client2");

            // Remote
            //startRemoteProgram("192.168.0.120", "client2");
            heartbeatReceiver.Join();
        }

        public void startLocalInstance()
        {
            Process.Start("HES-Instanz.exe");
        }

        void printRunningInstances(object sender, EventArgs e)
        {
            Console.Clear();

            Console.WriteLine("Running: " + runningInstances.Count);
            Console.WriteLine("QueueSize: " + queueSize());
            foreach (string client in runningInstances.Keys)
            {
                Console.WriteLine(client + " : " + runningInstances[client]);
            }
        }

        void InstancesCleaner(Object state)
        {
            IDictionary<string, DateTime> tmp = new Dictionary<string, DateTime>();
            bool changed = false;

            foreach (string client in runningInstances.Keys)
            {
                tmp.Add(client, runningInstances[client]);
            }

            foreach (string client in tmp.Keys)
            {
                if (DateTime.Now.Subtract(tmp[client]).TotalMilliseconds > timeoutMillis)
                {
                    changed = true;
                    runningInstances.Remove(client);
                }
            }

            if (changed)
            {
                if (this.Changed != null)
                    this.Changed(this, EventArgs.Empty);
            }
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

                var key = stringData + "@" + sender.Address;

                if (runningInstances.ContainsKey(key))
                {
                    runningInstances[key] = DateTime.Now;
                }
                else
                {
                    runningInstances.Add(key, DateTime.Now);
                }
                if (this.Changed != null)
                    this.Changed(this, EventArgs.Empty);


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

        void startLocal(string path, string clientName)
        {
            List<string> c = new List<string>();
            c.Add(@"""" + path + @""" " + clientName + " " + Helper.LocalIPAddress());
            Helper.runCommandsAsThread(c);
        }
    }
}
