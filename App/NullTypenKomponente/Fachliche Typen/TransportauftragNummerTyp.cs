using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace NullTypenKomponente
    {
        public class TransportauftragNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            public TransportauftragNummerTyp(){}

            /// <summary>
            /// Basisconstructor, erzeugt ein neues TransportauftragNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public TransportauftragNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Transportauftragnummer: " + nummer;
            }
        }
    }
}