using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class LieferungNummerTyp
    {
         public virtual Int32 nummer { get; private set; }

        /// <summary>
        /// Nullable Constructor für NHibernate
        /// </summary>
        public LieferungNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues LieferungNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public LieferungNummerTyp(Int32 nummer)
        {
            this.nummer = nummer;
        }

        public override String ToString()
        {
            return "LieferungNummerTyp:" + nummer;
        }
    }
}
