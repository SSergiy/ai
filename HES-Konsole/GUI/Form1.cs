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
using _0TypenKomponente;

namespace GUI
{
    public partial class Form1 : Form
    {
        Client rabbit_client = new Client();

        public Form1()
        {
            InitializeComponent();
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
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            string message = new Nachrichten.Message(dll, ns, klasse, methode, client, p).getMessage();
            for (int i = 0; i < anzahl; i++)
            {
                rabbit_client.SendMessage(encoder.GetBytes(message));
            }
        }

        private void receive(string clientname)
        {
            byte[] body = rabbit_client.Receive();
            string message = System.Text.Encoding.UTF8.GetString(body);
            MessageBox.Show(message);
        }

        private void Empfangen_Click(object sender, EventArgs e)
        {
            string clientname = clientTextBox.Text;
            receive(clientname);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rabbit_client.Dispose();
        }
    }
}
