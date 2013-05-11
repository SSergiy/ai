using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace BuchhaltungsVerwaltungsKomponente
    {
        public class BuchhaltungsVerwaltungFassade:IAWKBuchhaltungsVerwaltung
        {
            public IRechnung ErstelleRechnung(AuftragNummerTyp auftrag)
            {
                throw new NotImplementedException();
            }

            public void VerschickeRechnung(RechnungNummerTyp rechnung)
            {
                throw new NotImplementedException();
            }
        }
    }
}
