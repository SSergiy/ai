using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQTest
{
    public class Program
    {


        public static void Main(string[] args)
        {
            bool durable = true;
            bool exclusive = false;
            bool autoDelete = false;

            string serverAddress = "localhost";
            string queuename = "test";

            // Sender
            ConnectionFactory connectionfactory = new ConnectionFactory();
            connectionfactory.HostName = serverAddress;
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    // Die Queue wird erzeugt falls sie noch nicht existiert.
                    var a = channel.QueueDeclare(queuename, durable, exclusive, autoDelete, null);
                    System.Console.WriteLine("Len: " + a.MessageCount);
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    string message = "TestRabbitMQin.NET";
                    channel.BasicPublish("", queuename, null, encoder.GetBytes(message));
                    Console.WriteLine("Message Send to RabbitMQ: "+ message);
                }
            }

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
                    System.Console.WriteLine("Len: " + a.MessageCount);
                    BasicDeliverEventArgs ea =(BasicDeliverEventArgs)consumer.Queue.Dequeue();

                    byte[] body = ea.Body;
                    string message = System.Text.Encoding.UTF8.GetString(body);
                    System.Console.WriteLine("Message Receive from RabbitMQ: "+ message);
                    System.Console.WriteLine("Len: " + a.MessageCount);
                    Console.ReadKey();
                    
                }
            }


        }
    }
}
