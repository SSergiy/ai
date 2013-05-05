using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        interface IAWKProduktVerwaltung
        {
            Produkt HoleProdukt(ProduktNummerTyp produktnummer); 
        }
    }
}