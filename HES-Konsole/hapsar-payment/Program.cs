using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingAdapter;

namespace hapsar_payment
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessagingAdapter m = new RabbitClient("Bank", "in", "localhost", "127.0.0.1");
            UTF8Encoding encoder = new System.Text.UTF8Encoding();

            var Dll = "BuchhaltungVerwaltungKomponente.dll";
            var Namespace = "BuchhaltungVerwaltungKomponente";
            var Klasse = "BuchhaltungVerwaltungFassade";
            var Methode = "VerbucheZahlungRemote";
            var Client = "Bank";
            var Parameter = new List<string>();
            Parameter.Add("1");
            Parameter.Add("100.0");
            string message = new Nachrichten.Message(Dll, Namespace, Klasse, Methode, Client, Parameter).getMessage();
            m.SendMessage(encoder.GetBytes(message));
            m.Dispose();
        }
    }
}
