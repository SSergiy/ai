using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class LieferungNummerTyp : NummerTyp
    {
        /// <summary>
        /// Nullable Constructor für NHibernate
        /// </summary>
        public LieferungNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues LieferungNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public LieferungNummerTyp(Int32 nummer) : base(nummer) { }

        public override String ToString()
        {
            return "LieferungNummerTyp:" + nummer;
        }
    }
}
