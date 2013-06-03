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
        IDictionary<string, DateTime> getRunningInstances();
        uint queueSize();
    }
}
