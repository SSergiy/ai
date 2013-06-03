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
        readonly static bool durable = true;
        readonly static bool exclusive = false;
        readonly static bool autoDelete = false;
        readonly static string serverAddress = "localhost";
        readonly static string server_queue_name = "in";
        readonly static int timeoutMillis = 1000;
        readonly static string remote_string = "Remote";
        readonly static int clientId = new Random().Next();

        readonly static DateTime startTime = DateTime.Now;
        static bool shutdown = false;

        static string ip;

        private static void Heartbeat(Object state)
        {
            SendUdpPacket("client" + clientId);
        }

        private static void SendUdpPacket(string message)
        {
            System.Net.Sockets.UdpClient sock = new System.Net.Sockets.UdpClient();
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), 15000);
            byte[] data = Encoding.ASCII.GetBytes(message);
            sock.Send(data, data.Length, iep);
            sock.Close();
        }

        private static void shutdownHES()
        {
            System.Environment.Exit(0);
        }

        // Sender
        static ConnectionFactory connectionfactory = new ConnectionFactory();


        static void Main(string[] args)
        {
            Timer heartbeat = new Timer(Heartbeat, 5, 0, 1000);

            if (args.Length > 0)
            {
                ip = args[0];
            }
            else
            {
                ip = "127.0.0.1";
            }

            connectionfactory.HostName = serverAddress;
            Console.WriteLine("Starte HES Instanz");
            KundeVerwaltungFassade f = new KundeVerwaltungFassade();
            // und weitere


            Console.WriteLine("HES gestartet");
            Console.WriteLine("Verbinde zur Queue");
            // Receive from in queue
            connectionfactory = new ConnectionFactory();
            connectionfactory.HostName = serverAddress;
            insertDummyContent();
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    Console.WriteLine("Verbindung zur Queue hergestellt");
                    while (true)
                    {
                        if (shutdown) shutdownHES();
                        var a = channel.QueueDeclare(server_queue_name, durable, exclusive, autoDelete, null);
                        Console.WriteLine("Es befinden sich: " + a.MessageCount.ToString() + " Nachrichten in der " + a.QueueName.ToString() + " Queue");
                        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                        QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(server_queue_name, true, consumer);
                        BasicDeliverEventArgs ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        byte[] body = ea.Body;
                        // Erzeuge aus dem byte[] eine Message instanz um dann die Richtige Komponente ansprechen zu können.
                        string message = System.Text.Encoding.UTF8.GetString(body);
                        Console.WriteLine(message);

                        try
                        {
                            Message m = Message.getMessage(message);
                            Console.WriteLine("Verarbeite Nachricht - Fassade: " + m.fassade + " Methode: " + m.methode + " Client: " + m.client + " Parameter: " + m.parameter);
                            // Anfang von Magic
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
                                // Erzeuge Instanz der Fassade
                                try
                                {
                                    object instanz_der_komponente = Activator.CreateInstance(type_der_komponente);
                                    try
                                    {
                                        // Hat diese Instanz die benötigte Methode ?
                                        MethodInfo Methode = type_der_komponente.GetMethod(m.methode);
                                        try
                                        {

                                            object result = null;

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

                                            // Sende Ergebnis zurück.
                                            try
                                            {
                                                var respond_queue = channel.QueueDeclare(m.client, durable, exclusive, autoDelete, null);
                                                string return_message = result.ToString();
                                                for (int i = 0; i < 10; i++)
                                                {
                                                    channel.BasicPublish("", m.client, null, encoder.GetBytes(return_message));
                                                }

                                                Console.WriteLine("Antwort mit: " + return_message + " an Client: " + m.client + " gesendet.");
                                                Console.WriteLine("Einträge in Client queue: " + respond_queue.MessageCount);
                                                Console.WriteLine("Name der Queue: " + respond_queue.QueueName);
                                            }
                                            catch (Exception e) { Console.WriteLine("Antwort konnte nicht zurück gesendet werden." + e.Message + "\n" + e.InnerException); }
                                        }
                                        catch (Exception e) { Console.WriteLine("Methode lieferte eine Exception." + e.Message + "\n" + e.InnerException); }
                                    }
                                    catch (Exception e) { Console.WriteLine("Methode der Fassade konnte nicht gefunden werden." + e.Message + "\n" + e.InnerException); }
                                }
                                catch (Exception e) { Console.WriteLine("Instanz der Fassdade konnte nicht erstellt werden" + e.Message + "\n" + e.InnerException); }
                            }
                        }
                        catch (Exception e) { Console.WriteLine("Typ der Komponente Konnte nicht ermittelt werden " + e.Message + "\n" + e.InnerException); }
                        Console.WriteLine("Abgearbeitet!");
                    }

                }
            }

        }



        static void insertDummyContent()
        {
            // Damit auch was da ist nech ...
            var kundenverwaltungsfassade = new KundeVerwaltungFassade();
            kundenverwaltungsfassade.ErstelleKunde(new KundeNummerTyp(1), "Peter", new AdresseTyp("Musterstraße", "2", "12345", "Hamburg", "Deutschland"));
        }

    }
}
