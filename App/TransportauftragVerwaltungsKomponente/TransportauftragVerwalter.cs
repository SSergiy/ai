using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transportdienstleiter_Komponente;

namespace Anwendungskern
{
    namespace TransportauftragVerwaltungsKomponente
    {
        class TransportauftragVerwalter
        {
            internal TransportauftragNummerTyp ErstelleTransportauftrag(DateTime ausgangsdatum, DateTime lieferdatum, NullTypenKomponente.TransportdienstleisterTyp transportdienstleister)
            {
                return new TransportauftragNummerTyp(TransportdienstleisterAdapter.ErstelleTransportauftrag(ausgangsdatum, lieferdatum, transportdienstleister));
            }
        }
    }
}