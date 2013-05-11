using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transportdienstleiter_Komponente
{
    public class TransportdienstleisterAdapter
    {
        public static int ErstelleTransportauftrag(DateTime ausgangsdatum, DateTime lieferdatum, Anwendungskern.NullTypenKomponente.TransportdienstleisterTyp transportdienstleister)
        {
            return new Random().Next();
        }
    }
}
