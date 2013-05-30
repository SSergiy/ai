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
using Nachrichten;


namespace GUI
{
    public partial class Form1 : Form
    {
        private ConnectionFactory connectionfactory = new ConnectionFactory();
        public bool durable = true;
        public bool exclusive = false;
        public bool autoDelete = false;

        public string serverAddress = "localhost";
        public string server_queue_name = "in";

        public Form1()
        {
            InitializeComponent();
            connectionfactory.HostName = serverAddress;
        }

        private void Senden_Click(object sender, EventArgs e)
        {
            string Kompoennte = KomponenteTextBox.Text;
            string Methode = MethodeTextBox.Text;
            string ClientName = clientname.Text;
            int anzahl = 1;
            try
            { anzahl = int.Parse(AnzahlAufrufeTextBox.Text); }
            catch (Exception) { }

            send(Kompoennte, Methode, ClientName, anzahl);
        }

        private void send(string komponente, string methode, string clientname, int anzahl)
        {
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(server_queue_name, durable, exclusive, autoDelete, null);
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    string message = new Nachrichten.Message(komponente, methode, clientname).getMessage();



                    for (int i = 0; i < anzahl; i++)
                    {
                        channel.BasicPublish("", server_queue_name, null, encoder.GetBytes(message));
                    }
                }
            }
        }

        private void receive(string clientname)
        {
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    var a = channel.QueueDeclare(clientname, durable, exclusive, autoDelete, null);
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(server_queue_name, true, consumer);
                    System.Console.WriteLine("Len: " + a.MessageCount);
                    BasicDeliverEventArgs ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                    byte[] body = ea.Body;
                    string message = System.Text.Encoding.UTF8.GetString(body);
                    MessageBox.Show(message);
                    //System.Console.WriteLine("Message Receive from RabbitMQ: " + message);
                    //System.Console.WriteLine("Len: " + a.MessageCount);

                }
            }
        }

        private void Empfangen_Click(object sender, EventArgs e)
        {
            string clientname = clientTextBox.Text;
            receive(clientname);
        }

    }
}
