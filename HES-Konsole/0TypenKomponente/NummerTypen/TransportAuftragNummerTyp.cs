using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class TransportAuftragNummerTyp : NummerTyp
    {
        /// <summary>
        /// Nullable Constructor für NHibernate
        /// </summary>
        public TransportAuftragNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues TransportAuftragNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public TransportAuftragNummerTyp(Int32 nummer)
            : base(nummer)
        {
        }

        public override String ToString()
        {
            return "TransportAuftragNummerTyp" + nummer;
        }
    }
}
