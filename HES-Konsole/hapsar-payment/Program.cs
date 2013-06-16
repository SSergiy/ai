using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingAdapter;

namespace hapsar_payment
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessagingAdapter m = new RabbitClient("in", "Bank", "localhost", "127.0.0.1");



            m.Dispose();
        }
    }
}
