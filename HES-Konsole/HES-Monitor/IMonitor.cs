using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HES_Monitor
{
    public interface IMonitor
    {
        void start();
        void startLocalInstance();
        void startRemoteInstance(string host);
        IDictionary<string, DateTime> getRunningInstances();
        int queueSize();
        void Dispose();
    }
}
