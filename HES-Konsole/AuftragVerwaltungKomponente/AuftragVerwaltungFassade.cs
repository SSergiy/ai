using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;

namespace AuftragVerwaltungKomponente
{
    public class AuftragVerwaltungFassade
    {
        private static readonly AuftragVerwaltung verwalter = new AuftragVerwaltung();

        public IAngebot ErstelleAngebot(IDictionary<ProduktNummerTyp, int> produkte, DateTime gültigAb, DateTime gültigBis)
        {
            return verwalter.ErstelleAngebot(produkte, gültigAb, gültigBis);
        }

        public IAuftrag ErstelleAuftrag(DateTime beauftragtAm, AngebotNummerTyp angebotnummer, KundeNummerTyp kundennummer)
        {
            return verwalter.ErstelleAuftrag(beauftragtAm, angebotnummer, kundennummer);
        }

        public IAuftrag HoleAuftrag(AuftragNummerTyp auftrag)
        {
            return verwalter.HoleAuftrag(auftrag);
        }
    }
}
