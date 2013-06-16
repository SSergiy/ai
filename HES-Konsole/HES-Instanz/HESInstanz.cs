using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KundeVerwaltungKomponente;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente;
using System.Threading;
using System.Net;
using Nachrichten;
using System.Reflection;
using MessagingAdapter;

namespace HES_Instanz
{
    class HESInstanz
    {
        IMessagingAdapter messagingAdapter;
        Heartbeat heartbeat;
        int clientId = new Random().Next();
        string HostIp;

        public HESInstanz(string ip)
        {
            HostIp = ip;
            heartbeat = new Heartbeat(clientId, HostIp);
            messagingAdapter = new MessagingAdapter.RabbitClient("in", "Client1", HostIp, HostIp);

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
        }

        void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Shutting down...");

            //Dispose();
            stop = true;

            System.Threading.Thread.Sleep(750);
        }

        protected bool stop = false;
        
        public void start()
        {
            Console.WriteLine("Starte HES Instanz");
            Console.WriteLine("Verbinde zur Queue");

            insertDummyContent();

            while (!stop)
            {
                try
                {
                    byte[] body = messagingAdapter.ReceiveMessage();

                    string message = System.Text.Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);

                    Message m = Message.getMessage(message);
                    Console.WriteLine("Verarbeite Nachricht - Fassade: " + m.fassade + " Methode: " + m.methode + " Client: " + m.client + " Parameter: " + m.parameter);

                    string return_message = MethodInvoker.Process(m).ToString();

                    messagingAdapter.SendMessage(messagingAdapter.Encoder().GetBytes(return_message));
                }
                catch (Exception)
                {
                    break;
                }

            }
            
            Dispose();
        }

        public void Dispose()
        {
            messagingAdapter.Dispose();
            heartbeat.Dispose();
        }

        private void insertDummyContent()
        {
            // Damit auch was da ist nech ...
            var kundenverwaltungsfassade = new KundeVerwaltungFassade();
            kundenverwaltungsfassade.ErstelleKunde(new KundeNummerTyp(1), "Peter", new AdresseTyp("Musterstraße", "2", "12345", "Hamburg", "Deutschland"));
        }
    }
}
