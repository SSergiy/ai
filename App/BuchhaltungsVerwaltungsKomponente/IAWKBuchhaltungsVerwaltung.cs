using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace BuchhaltungsVerwaltungsKomponente
    {
        interface IAWKBuchhaltungsVerwaltung
        {
            IRechnung ErstelleRechnung(AuftragNummerTyp auftrag);
            //void VerschickeRechnung(RechnungNummerTyp rechnung);
        }
    }
}