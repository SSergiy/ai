using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class AuftragNummerTyp : NummerTyp
    {
        /// <summary>
        /// Nullable Constructor für NHibernate
        /// </summary>
        public AuftragNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues AuftragNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public AuftragNummerTyp(Int32 nummer) : base(nummer) { }

        public override String ToString()
        {
            return "Auftragnummer:" + nummer;
        }
    }
}
