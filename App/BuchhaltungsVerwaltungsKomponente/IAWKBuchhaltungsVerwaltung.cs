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
            IRechnung ErstelleRechnung(IAuftrag auftrag);
            void VerschickeRechnung(IRechnung rechnung);
        }
    }
}