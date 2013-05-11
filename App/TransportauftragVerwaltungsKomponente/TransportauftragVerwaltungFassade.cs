using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace TransportauftragVerwaltungsKomponente
    {
        class TransportauftragVerwaltungFassade : IAWKTransportauftragVerwaltung
        {
            private static readonly TransportauftragVerwalter transportauftragverwalter = new TransportauftragVerwalter();

            public TransportauftragNummerTyp ErstelleTransportauftrag(DateTime ausgangsdatum, DateTime lieferdatum, TransportdienstleisterTyp transportdienstleister)
            {
                return transportauftragverwalter.ErstelleTransportauftrag(ausgangsdatum, lieferdatum, transportdienstleister);
            }
        }
    }
}