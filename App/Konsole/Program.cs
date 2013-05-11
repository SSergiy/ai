using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.ProduktVerwaltunsKomponente;

namespace Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pvf = new ProduktVerwaltungFassade();
            IDictionary<ProduktNummerTyp, int> i = new Dictionary<ProduktNummerTyp, int>();

            i.Add(new ProduktNummerTyp(1), 96);
            i.Add(new ProduktNummerTyp(2), 48);
            i.Add(new ProduktNummerTyp(3), 24);
            i.Add(new ProduktNummerTyp(4), 12);
            i.Add(new ProduktNummerTyp(5), 6);
            i.Add(new ProduktNummerTyp(6), 3);

            Console.WriteLine(true == pvf.PrüfeProduktLagerbestand(i));
        }
    }
}
