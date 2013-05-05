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

            public Angebot ErstelleAngebot(IDictionary<ProduktVerwaltunsKomponente.ProduktNummerTyp, int> produkte, DateTime gültigAb, DateTime gültigBis)
            {
                return verwalter.ErstelleAngebot(produkte, gültigAb, gültigBis);
            }

            public Auftrag ErstelleAuftrag(DateTime beauftragsAm, AngebotNummerTyp angebotnummer, KundenVerwaltungsKomponente.KundeNummerTyp kundennummer)
            {
                return verwalter.ErstelleAuftrag(beauftragsAm, angebotnummer, kundennummer);
            }
        }





    }
}
