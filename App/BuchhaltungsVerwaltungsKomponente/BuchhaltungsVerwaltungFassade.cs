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
            private static readonly BuchhaltungsVerwalter buchhaltungsVerwalter = new BuchhaltungsVerwalter();

            public IRechnung ErstelleRechnung(IAuftrag auftrag)
            {
                return buchhaltungsVerwalter.ErstelleRechnung(auftrag);
            }

            public void VerschickeRechnung(IRechnung rechnung)
            {
                buchhaltungsVerwalter.VerschickeRechnung(rechnung);
            }
        }
    }
}
