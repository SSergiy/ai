using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GUI
{
    public partial class Form1 : Form
    {
        private ConnectionFactory connectionfactory =  new ConnectionFactory();
        public bool durable = true;
        public    bool exclusive = false;
            public bool autoDelete = false;

public             string serverAddress = "localhost";
       public      string queuename = "test"; 

        public Form1()
        {
            InitializeComponent();
           

            connectionfactory.HostName = serverAddress;

            

        }

        private void Senden_Click(object sender, EventArgs e)
        {
            send();
        }

        private void send() {             
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
                    Console.WriteLine("Message Send to RabbitMQ: " + message);
                }
            }}

        private void receive()
        {
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    var a = channel.QueueDeclare(queuename, durable, exclusive, autoDelete, null);
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queuename, true, consumer);
                    System.Console.WriteLine("Len: " + a.MessageCount);
                    BasicDeliverEventArgs ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                    byte[] body = ea.Body;
                    string message = System.Text.Encoding.UTF8.GetString(body);
                    System.Console.WriteLine("Message Receive from RabbitMQ: " + message);
                    System.Console.WriteLine("Len: " + a.MessageCount);
                    Console.ReadKey();

                }
            }
        }

        private void Empfangen_Click(object sender, EventArgs e)
        {
            receive();
        }

    }
}
