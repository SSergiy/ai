using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class AngebotNummerTyp
    {
        public virtual Int32 nummer { get; private set; }

        /// <summary>
        /// Nullable Constructor für NHibernate
        /// </summary>
        public AngebotNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues AngebotNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public AngebotNummerTyp(Int32 nummer)
        {
            this.nummer = nummer;
        }

        public override String ToString()
        {
            return "Angebotgnummer:" + nummer;
        }
    }
}
