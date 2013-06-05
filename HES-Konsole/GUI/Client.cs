using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente;

namespace GUI
{
    class Client : RabbitClient
    {
        public Client()
            : base("Client1", "in", "localhost", "127.0.0.1")
        {

        }
    }
}
