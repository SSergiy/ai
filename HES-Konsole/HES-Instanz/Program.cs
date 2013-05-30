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

        static bool durable = true;
        static bool exclusive = false;
        static bool autoDelete = false;

        static string serverAddress = "localhost";
        static string queuename = "in";
        static int timeoutMillis = 1000;

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

                    // Main Loop
                    while (Console.ReadKey().KeyChar != 'q')
                    {
                        var a = channel.QueueDeclare(queuename, durable, exclusive, autoDelete, null);

                        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                        QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(queuename, true, consumer);
                        bool br = false;
                        while (!br)
                        {
                            System.Console.WriteLine("Len: " + a.MessageCount);
                            object obj;
                            if (!consumer.Queue.Dequeue(timeoutMillis, out obj))
                            {
                                br = true;
                            }


                            // Erzeuge aus dem object eine Message instanz um dann die Richtige Komponente ansprechen zu können.
                            string message = (string)obj;
                            Console.WriteLine(message);

                            try
                            {
                                Message m = Message.getMessage(message);

                                // Anfang von Magic
                                Type Komponente = Type.GetType(m.fassade);
                                if (Komponente == null)
                                {
                                    Console.WriteLine("Fassade: " + m.fassade + " nicht gefunden");
                                }
                                else
                                {
                                    // Erzeuge Instanz der Fassade
                                    try
                                    {
                                        object KomponentenFassade = Activator.CreateInstance(Komponente);
                                        try
                                        {
                                            // Hat diese Instanz die benötigte Methode ?
                                            MethodInfo Methode = Komponente.GetMethod(m.method);
                                            try
                                            {
                                                // Und wenn ich jetzt noch die Methode ausführen kann, war alles Prima !
                                                // Referenzen müssen vorhanden sein !
                                                object result = Methode.Invoke(KomponentenFassade, null);

                                                // Sende Ergebnis zurück.
                                                try
                                                {
                                                    var send_queue = channel.QueueDeclare(m.client_name, durable, exclusive, autoDelete, null);
                                                    string return_message = result.ToString();
                                                    channel.BasicPublish("", m.client_name, null, encoder.GetBytes(message));
                                                    Console.WriteLine("Antwort mit: " + return_message + " an Client: " + m.client_name + " gesendet. Alles gut gegangen !");
                                                }
                                                catch (Exception) { Console.WriteLine("Antwort konnte nicht zurück gesendet werden."); }
                                            }
                                            catch (Exception) { Console.WriteLine("Methode lieferte eine Exception."); }
                                        }
                                        catch (Exception) { Console.WriteLine("Methode der Fassade konnte nicht gefunden werden."); }
                                    }
                                    catch (Exception) { Console.WriteLine("Instanz der Fassdade konnte nicht erstellt werden"); }
                                }
                            }
                            catch (Exception) { Console.WriteLine("Nachricht ist nicht im Nachrichten Format"); }
                        }
                    }
                    Console.WriteLine("Alles abgearbeitet!");
                    Console.ReadKey();

                }
            }
        }



        static void insertDummyContent() 
        {
            // Damit auch was da ist nech ...
            var kundenverwaltungsfassade = new KundeVerwaltungFassade();
            kundenverwaltungsfassade.ErstelleKunde(new KundeNummerTyp(1),"Peter",new AdresseTyp("Musterstraße","2","12345","Hamburg","Deutschland"));
            
        }

    }
}
