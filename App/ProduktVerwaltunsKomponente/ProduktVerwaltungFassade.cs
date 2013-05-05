using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
       public class ProduktVerwaltungFassade:IAWKProduktVerwaltung
        {
            private static readonly ProduktVerwalter produktverwalter = new ProduktVerwalter();

            public Produkt HoleProdukt(ProduktNummerTyp produktnummer) 
            {
                return produktverwalter.HoleProdukt(produktnummer);
            }
        }
    }
}