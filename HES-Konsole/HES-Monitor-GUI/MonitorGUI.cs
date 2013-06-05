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
using System.Net;

namespace HES_Monitor_GUI
{
    public partial class MonitorGUI : Form
    {
        Process monitor;

        public MonitorGUI()
        {
            InitializeComponent();
        }

        IMonitor remoteObject;
        TcpChannel tcpChannel;
        bool connected = false;

        private void MonitorGUI_Load(object sender, EventArgs e)
        {

        }

        void refreshRunningInstances()
        {
            runningInstances.Items.Clear();

            var ri = remoteObject.getRunningInstances();

            queueSizeVal.Text = remoteObject.queueSize().ToString();

            foreach (string client in ri.Keys)
            {
                runningInstances.Items.Add(client + " : " + ri[client]);
            }
        }

        void startMonitor()
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.WindowStyle = ProcessWindowStyle.Normal;
            p.FileName = "HES-Monitor.exe";
            monitor = new Process();
            monitor.StartInfo = p;
            monitor.Start();
        }

        private void newLocalInstance_Click(object sender, EventArgs e)
        {
            if (!connected) return;
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

        private void MonitorGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChannelServices.UnregisterChannel(tcpChannel);
            //monitor.Kill();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            connected = true;
            tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, false);

            Type requiredType = typeof(IMonitor);
            remoteObject = (IMonitor)Activator.GetObject(requiredType, "tcp://" + hostname.Text + ":9998/HES-Monitor");

            startMonitor();
            refreshGUI.Start();
        }

        private void newRemoteInstance_Click(object sender, EventArgs e)
        {
            if (!connected) return;
            remoteObject.startRemoteInstance(clientName.Text);
        }
    }
}
