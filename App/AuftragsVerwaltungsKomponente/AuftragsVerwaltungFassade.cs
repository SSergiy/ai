using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        // Die Fassade müsste die Entitäten noch in TransportTypen umwandeln, worauf wir hier allerdings verzichten.
        public class AuftragsVerwaltungFassade:IAWKAuftragsVerwaltung
        {
            private static readonly AuftragsVerwalter verwalter = new AuftragsVerwalter();

            public IAngebot ErstelleAngebot(IDictionary<ProduktNummerTyp, int> produkte, DateTime gültigAb, DateTime gültigBis)
            {
                return verwalter.ErstelleAngebot(produkte, gültigAb, gültigBis);
            }

            public IAuftrag ErstelleAuftrag(DateTime beauftragsAm, AngebotNummerTyp angebotnummer, KundeNummerTyp kundennummer)
            {
                return verwalter.ErstelleAuftrag(beauftragsAm, angebotnummer, kundennummer);
            }

            public IAuftrag HoleAuftrag(AuftragNummerTyp auftrag)
            {
                return verwalter.HoleAuftrag(auftrag);
            }
        }
    }
}
