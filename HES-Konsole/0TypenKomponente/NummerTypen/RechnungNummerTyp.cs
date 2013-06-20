using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class RechnungNummerTyp : NummerTyp
    {
        /// <summary>
        /// Nullable Constructor für NHibernate
        /// </summary>
        public RechnungNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues RechnungNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public RechnungNummerTyp(Int32 nummer)
            : base(nummer)
        {
        }

        public override String ToString()
        {
            return "Rechnungnummer" + nummer;
        }
    }
}
