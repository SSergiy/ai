using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class KundeNummerTyp : NummerTyp
    {
        public KundeNummerTyp() { }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues KundeNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public KundeNummerTyp(Int32 nummer) : base(nummer) { }

        public override String ToString()
        {
            return "Kundenummer: " + nummer;
        }
    }
}
