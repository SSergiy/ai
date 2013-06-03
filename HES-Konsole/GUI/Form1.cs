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
            string dll = TextBoxdll.Text.Trim();
            string ns = TextBoxNameSpace.Text.Trim();
            string klasse = TextBoxKlasse.Text.Trim();
            string methode = TextBoxMethode.Text.Trim();
            string client = clientTextBox.Text.Trim();
            string parameter = TextBoxParameter.Text.Trim();
            List<string> p = new List<string>();
            if (parameter != string.Empty)
            {
                p = parameter.Split(',').ToList<string>();
            }
            int anzahl = 1;
            try
            { anzahl = int.Parse(TextBoxAufrufe.Text.Trim()); }
            catch (Exception) { }

            send(dll, ns, klasse, methode, client, anzahl, p);
        }

        private void send(string dll, string ns, string klasse, string methode, string client, int anzahl, List<string> p)
        {
            using (IConnection connection = connectionfactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    var a = channel.QueueDeclare(server_queue_name, durable, exclusive, autoDelete, null);
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    string message = new Nachrichten.Message(dll, ns, klasse, methode, client, p).getMessage();



                    for (int i = 0; i < anzahl; i++)
                    {
                        //MessageBox.Show("Gesendete Nachricht: " + message+ "\n" + server_queue_name);
                        channel.BasicPublish("", server_queue_name, null, encoder.GetBytes(message));
                        Console.WriteLine("Messages after send: " + a.MessageCount);
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
                    Console.WriteLine("Es befinden sich: " + a.MessageCount.ToString() + " Nachrichten in der " + a.QueueName.ToString() + " Queue");
                    if (a.MessageCount > 0)
                    {
                        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                        QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(clientname, true, consumer);

                        // Blockierend
                        BasicDeliverEventArgs ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        byte[] body = ea.Body;
                        string message = System.Text.Encoding.UTF8.GetString(body);
                        MessageBox.Show(message);

                        // Nicht-Blockierend

                        //object result = consumer.Queue.DequeueNoWait(null);
                        //string message = "";
                        //if (result != null)
                        //{
                        //    BasicDeliverEventArgs ea = (BasicDeliverEventArgs)result;
                        //    byte[] body = ea.Body;
                        //    message = System.Text.Encoding.UTF8.GetString(body);

                        //}
                        //else { message = "Queue hat keine Einträge"; }
                        //MessageBox.Show(message);
                    }
                    else {
                        MessageBox.Show("gibt keine");
                    }
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
