using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class TransportAuftragNummerTyp
    {
                public virtual Int32 nummer { get; private set; }

        /// <summary>
        /// Nullable Constructor für NHibernate
        /// </summary>
        public TransportAuftragNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues TransportAuftragNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public TransportAuftragNummerTyp(Int32 nummer)
        {
            this.nummer = nummer;
        }

        public override String ToString()
        {
            return "TransportAuftragNummerTyp" + nummer;
        }
    }
}
