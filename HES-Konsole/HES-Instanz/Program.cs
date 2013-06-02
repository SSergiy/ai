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

        // Sender
        static ConnectionFactory connectionfactory = new ConnectionFactory();


        static void Main(string[] args)
        {
            connectionfactory.HostName = serverAddress;

            insertDummyContent();

            Console.WriteLine("Starte HES Instanz");
            KundeVerwaltungFassade f = new KundeVerwaltungFassade();
            // und weitere


            Console.WriteLine("HES gestartet");
            Console.WriteLine("Verbinde zur Queue");
            // Receive from in queue
            connectionfactory = new ConnectionFactory();
            connectionfactory.HostName = serverAddress;
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    Console.WriteLine("Verbindung zur Queue hergestellt");
                    while(true) {
                    var a = channel.QueueDeclare(server_queue_name, durable, exclusive, autoDelete, null);
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(server_queue_name, true, consumer);

                        
                    BasicDeliverEventArgs ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                    //System.Console.WriteLine("Len: " + a.MessageCount);
                    byte[] body = ea.Body;
                    // Erzeuge aus dem byte[] eine Message instanz um dann die Richtige Komponente ansprechen zu können.
                    string message = System.Text.Encoding.UTF8.GetString(body);


                    Console.WriteLine(message);

                    try
                    {
                        Message m = Message.getMessage(message);
                        Console.WriteLine("Verarbeite Nachricht - Fassade: " + m.fassade + " Methode: " + m.methode + " Client: " + m.client + " Parameter: " + m.parameter);
                        // Anfang von Magic
                        string pfad_zur_assembly = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\"+m.dll;
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

                                        // Sende Ergebnis zurück.
                                        try
                                        {
                                            var respond_queue = channel.QueueDeclare(m.client, durable, exclusive, autoDelete, null);
                                            string return_message = result.ToString();
                                            channel.BasicPublish("", m.client, null, encoder.GetBytes(return_message));
                                            Console.WriteLine("Antwort mit: " + return_message + " an Client: " + m.client + " gesendet.");
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
                
                } }
        }



        static void insertDummyContent()
        {
            // Damit auch was da ist nech ...
            var kundenverwaltungsfassade = new KundeVerwaltungFassade();

            kundenverwaltungsfassade.ErstelleKunde(new KundeNummerTyp(1), "Peter", new AdresseTyp("Musterstraße", "2", "12345", "Hamburg", "Deutschland"));
            //using (IConnection connection = connectionfactory.CreateConnection())
            //{
            //    using (IModel channel = connection.CreateModel())
            //    {
            //        channel.QueueDeclare("in", durable, exclusive, autoDelete, null);
            //        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            //        string message = new Nachrichten.Message("KundeVerwaltungFassade", "HoleKunde", "Client1").getMessage();
            //        channel.BasicPublish("", "in", null, encoder.GetBytes(message));
            //    }
            //}

        }

    }
}
