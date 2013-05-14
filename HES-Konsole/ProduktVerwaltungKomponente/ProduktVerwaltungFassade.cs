using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;

namespace ProduktVerwaltungKomponente
{
    public class ProduktVerwaltungFassade
    {
        private static readonly ProduktVerwaltung produktverwalter = new ProduktVerwaltung();

        public List<IProdukt> HoleAlleProdukte()
        {
            return produktverwalter.HoleAlleProdukte();
        }

        public IProdukt HoleProdukt(ProduktNummerTyp produktnummer)
        {
            return produktverwalter.HoleProdukt(produktnummer);
        }

        public bool PrüfeProduktLagerbestand(IDictionary<ProduktNummerTyp, int> produktliste)
        {
            return produktverwalter.PrüfeProduktLagerbestand(produktliste);
        }

        public void MeldeProduktAuslagerung(IDictionary<ProduktNummerTyp, int> produktliste, int auftragsnummer)
        {
            produktverwalter.MeldeProduktAuslagerung(produktliste, auftragsnummer);
        }
    }
}
