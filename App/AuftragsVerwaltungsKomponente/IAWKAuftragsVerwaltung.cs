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
            AngebotTyp ErstelleAngebot(IDictionary<ProduktNummerTyp,int> produkte, DateTime gültigAb, DateTime gültigBis);
            AuftragTyp ErstelleAuftrag(DateTime beauftragsAm, AngebotNummerTyp angebotnummer, KundeNummerTyp kundennummer);

        }
    }
}