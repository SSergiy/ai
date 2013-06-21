using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KundeVerwaltungKomponente;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Nachrichten;
using System.Reflection;
using ProduktVerwaltungKomponente;
using System.Net;
using System.Threading;

namespace HES_Instanz
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";

            if (args.Length >= 1)
            {
                ip = args[0];
            }

            HESInstanz i = new HESInstanz(ip);
            i.start();
        }
    }
}
