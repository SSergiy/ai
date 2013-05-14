using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.NummerTypen;

namespace _0TypenKomponente.TransportInterfaces
{
        public interface IKunde
        {
            Int32 id { get; }
            KundeNummerTyp nummer { get; }
            String name { get; }
            AdresseTyp adresse { get; }
        }
}
