using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace Transportdienstleiter_Komponente
{
    public class TransportdienstleisterAdapter
    {
        public static int ErstelleTransportauftrag(DateTime ausgangsdatum, DateTime lieferdatum, TransportdienstleisterTyp transportdienstleister)
        {
            return new Random().Next();
        }
    }
}
