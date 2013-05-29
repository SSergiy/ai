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

namespace HES_Instanz
{
    class Program
    {

        static bool durable = true;
        static bool exclusive = false;
        static bool autoDelete = false;

        static string serverAddress = "localhost";
        static string queuename = "test";
        static int timeoutMillis = 1000;

        // Sender
        static ConnectionFactory connectionfactory = new ConnectionFactory();


        static void Main(string[] args)
        {
            connectionfactory.HostName = serverAddress;

            insertDummyContent();

            // Receive
            connectionfactory = new ConnectionFactory();
            connectionfactory.HostName = serverAddress;
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
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

                        System.Console.WriteLine("Message Receive from RabbitMQ: " + obj);
                        System.Console.WriteLine("Len: " + a.MessageCount);
                    }

                    System.Console.WriteLine("Alles abgearbeitet!");
                    Console.ReadKey();

                }
            }

            KundeVerwaltungFassade f = new KundeVerwaltungFassade();
            // , String name, AdresseTyp adresse)
            KundeNummerTyp nummer = new KundeNummerTyp(1);
            AdresseTyp adresse = new AdresseTyp("1", "2", "3", "4", "5");
            IKunde k = f.ErstelleKunde(nummer, "name", adresse);
            IKunde k_neu = f.HoleKunde(nummer);
            Console.WriteLine(k.name);
            Console.WriteLine(k_neu.name);
            Console.ReadKey();
        }

        static void insertDummyContent()
        {
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    // Die Queue wird erzeugt falls sie noch nicht existiert.
                    var a = channel.QueueDeclare(queuename, durable, exclusive, autoDelete, null);
                    for (int i = 0; i < 10; i++)
                    {
                        System.Console.WriteLine("Len: " + a.MessageCount);
                        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                        string message = "TestRabbitMQin.NET " + i;
                        channel.BasicPublish("", queuename, null, encoder.GetBytes(message));
                        Console.WriteLine("Message Send to RabbitMQ: " + message);
                    }

                }
            }
        }

    }
}
