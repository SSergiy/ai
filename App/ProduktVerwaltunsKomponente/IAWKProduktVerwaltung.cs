using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        interface IAWKProduktVerwaltung
        {
            Produkt HoleProdukt(ProduktNummerTyp produktnummer);
            bool PrüfeProduktLagerbestand(IDictionary<ProduktNummerTyp, int> produktliste);
            void MeldeProduktAuslagerung(IDictionary<ProduktNummerTyp, int> produktliste, int auftragsnummer);
        }
    }
}