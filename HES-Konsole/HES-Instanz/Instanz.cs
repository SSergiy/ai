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

namespace HES_Instanz
{
    class Instanz : RabbitClient
    {
        public Instanz()
            : base("in", "Client1", "localhost", "127.0.0.1")
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
        }

        void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Shutting down...");

            Dispose();

            System.Threading.Thread.Sleep(750);
        }

        protected bool stop = false;

        public void start()
        {
            Timer heartbeat = new Timer(Heartbeat, 5, 0, 1000);

            Console.WriteLine("Starte HES Instanz");
            Console.WriteLine("Verbinde zur Queue");

            insertDummyContent();

            while (!stop)
            {
                try
                {
                    byte[] body = Receive();

                    string message = System.Text.Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);

                    Message m = Message.getMessage(message);
                    Console.WriteLine("Verarbeite Nachricht - Fassade: " + m.fassade + " Methode: " + m.methode + " Client: " + m.client + " Parameter: " + m.parameter);

                    string return_message = MethodeAusführen(m).ToString();

                    SendMessage(encoder.GetBytes(return_message));
                }
                catch (Exception)
                {
                    break;
                }

            }

            Dispose();
        }


        object MethodeAusführen(Message m)
        {
            object result = null;

            string pfad_zur_assembly = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + m.dll;
            Assembly assembly_der_komponente = System.Reflection.Assembly.LoadFile(pfad_zur_assembly);
            string voller_type = m.ns + "." + m.fassade;
            Type type_der_komponente = assembly_der_komponente.GetType(voller_type);

            if (type_der_komponente == null)
            {
                Console.WriteLine("Fassade: " + m.fassade + " nicht gefunden");
            }
            else
            {
                object instanz_der_komponente = Activator.CreateInstance(type_der_komponente);
                MethodInfo Methode = type_der_komponente.GetMethod(m.methode);

                if (m.parameter.Count() > 0)
                {

                    object[] p = m.parameter.ToArray<object>();
                    result = Methode.Invoke(instanz_der_komponente, p);
                }
                else
                {
                    result = Methode.Invoke(instanz_der_komponente, null);
                }

                // Falls Ergebnis Null, leeren String setzten.
                if (result == null)
                {
                    result = "Die Anfrage lieferte kein Ergebnis";
                }
            }

            return result;
        }


        private void Heartbeat(Object state)
        {
            SendUdpPacket("client" + clientId);
        }

        private void SendUdpPacket(string message)
        {
            System.Net.Sockets.UdpClient sock = new System.Net.Sockets.UdpClient();
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(HostIp), 15000);
            byte[] data = Encoding.ASCII.GetBytes(message);
            sock.Send(data, data.Length, iep);
            sock.Close();
        }


        private void insertDummyContent()
        {
            // Damit auch was da ist nech ...
            var kundenverwaltungsfassade = new KundeVerwaltungFassade();
            kundenverwaltungsfassade.ErstelleKunde(new KundeNummerTyp(1), "Peter", new AdresseTyp("Musterstraße", "2", "12345", "Hamburg", "Deutschland"));
        }
    }
}
