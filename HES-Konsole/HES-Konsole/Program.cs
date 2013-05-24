using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KundeVerwaltungKomponente;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente;
using _0TypenKomponente.TransportInterfaces;

namespace HES_Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            KundeVerwaltungFassade f = new KundeVerwaltungFassade();
            // , String name, AdresseTyp adresse)
            KundeNummerTyp nummer = new KundeNummerTyp(1);
            AdresseTyp adresse = new AdresseTyp("1","2","3","4","5");
            IKunde k = f.ErstelleKunde(nummer, "name", adresse);
            IKunde k_neu = f.HoleKunde(nummer);
            Console.WriteLine(k.name);
            Console.WriteLine(k_neu.name);
            Console.ReadKey();
        }
    }
}
