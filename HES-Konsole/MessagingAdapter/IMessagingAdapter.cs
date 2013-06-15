using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingAdapter
{
    public interface IMessagingAdapter : IDisposable
    {
        byte[] ReceiveMessage();
        void SendMessage(byte[] message);
        UTF8Encoding Encoder();
        new void Dispose();
    }
}
