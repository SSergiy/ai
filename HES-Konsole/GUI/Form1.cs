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
using MessagingAdapter;

namespace GUI
{
    public partial class Form1 : Form
    {
        IMessagingAdapter messagingAdapter;


        public Form1()
        {
            messagingAdapter = new RabbitClient("Client1", "in", "localhost", "127.0.0.1");
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
                messagingAdapter.SendMessage(encoder.GetBytes(message));
            }
        }

        private void send(string dll, string ns, string klasse, string methode, string client, int anzahl) 
        {

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            string message = new Nachrichten.Message(dll, ns, klasse, methode, client).getMessage();
            for (int i = 0; i < anzahl; i++)
            {
                messagingAdapter.SendMessage(encoder.GetBytes(message));
            }
        }

        private void receive(string clientname)
        {
            byte[] body = messagingAdapter.ReceiveMessage();
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
            messagingAdapter.Dispose();
        }

        private void buttonErstelleTransportauftrag_Click(object sender, EventArgs e)
        {
            string dll = "TransportdienstleisterVerwaltungKomponente.dll";
            string ns = "TransportdienstleisterVerwaltungKomponente";
            string klasse = "TransportdienleisterVerwaltungFassade";
            string methode = "ErstelleLieferungRemote";
            string client = clientTextBox.Text.Trim();
            List<string> parameter = new List<string>();
            parameter.Add(textBoxLieferungNummer.Text);
            parameter.Add(textBoxAuftragnummer.Text);
            parameter.Add(dateTimePickerAusgang.Value.ToBinary().ToString());
            parameter.Add(checkBox1.Checked.ToString());
            parameter.Add(dateTimePickerLieferdatum.Value.ToBinary().ToString());
            parameter.Add("DHL");           
            send(dll, ns, klasse, methode, client, 1, parameter);
        }

        private void buttonHoleAlleTransportaufträge_Click(object sender, EventArgs e)
        {
            string dll = "TransportdienstleisterVerwaltungKomponente.dll";
            string ns = "TransportdienstleisterVerwaltungKomponente";
            string klasse = "TransportdienleisterVerwaltungFassade";
            string methode = "HoleAlleLieferungen";
            string client = clientTextBox.Text.Trim();
            send(dll, ns, klasse, methode, client, 1);
        }
    }
}
