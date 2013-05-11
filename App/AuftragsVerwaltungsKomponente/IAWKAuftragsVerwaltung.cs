using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.ProduktVerwaltunsKomponente;
using Anwendungskern.NullTypenKomponente;
using Anwendungskern.KundenVerwaltungsKomponente;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        interface IAWKAuftragsVerwaltung
        {
            IAngebot ErstelleAngebot(IDictionary<ProduktNummerTyp,int> produkte, DateTime gültigAb, DateTime gültigBis);
            IAuftrag ErstelleAuftrag(DateTime beauftragsAm, AngebotNummerTyp angebotnummer, KundeNummerTyp kundennummer);
            IRechnung ErstelleRechnung(AuftragNummerTyp auftrag);
            void VerschickeRechnung(RechnungNummerTyp rechnung);
        }
    }
}