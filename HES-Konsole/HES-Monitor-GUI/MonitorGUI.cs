using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HES_Monitor;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Diagnostics;

namespace HES_Monitor_GUI
{
    public partial class MonitorGUI : Form
    {

        Thread t;
        Process monitor;

        public MonitorGUI()
        {
            InitializeComponent();
        }

        IMonitor remoteObject;

        private void MonitorGUI_Load(object sender, EventArgs e)
        {
            startMonitor();

            refreshGUI.Start();

            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, false);

            Type requiredType = typeof(IMonitor);

            remoteObject = (IMonitor)Activator.GetObject(requiredType, "tcp://localhost:9998/HES-Monitor");

            try
            {
                t = new Thread(() => remoteObject.start());
                t.Start();
            }
            catch (Exception)
            {

            }
        }

        void refreshRunningInstances()
        {
            runningInstances.Items.Clear();

            var ri = remoteObject.getRunningInstances();

            label1.Text = remoteObject.queueSize().ToString();

            foreach (string client in ri.Keys)
            {
                runningInstances.Items.Add(client + " : " + ri[client]);
            }
        }

        void startMonitor()
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.WindowStyle = ProcessWindowStyle.Hidden;
            p.FileName = "HES-Monitor.exe";
            monitor = new Process();
            monitor.StartInfo = p;
            monitor.Start();
        }

        private void MonitorGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
            monitor.Kill();
        }

        private void newLocalInstance_Click(object sender, EventArgs e)
        {
            remoteObject.startLocalInstance();
        }

        private void refreshGUI_Tick(object sender, EventArgs e)
        {
            refreshRunningInstances();
        }

        private void autoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRefresh.Checked)
                refreshGUI.Start();
            else
                refreshGUI.Stop();
        }
    }
}
