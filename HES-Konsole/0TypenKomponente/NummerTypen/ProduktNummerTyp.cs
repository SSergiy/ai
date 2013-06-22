using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public class ProduktNummerTyp : NummerTyp
    {
        public ProduktNummerTyp()
        {
        }

        /// <summary>
        /// Basisconstructor, erzeugt ein neues ProduktNummerTyp Objekt.
        /// </summary>
        /// <param name="nummer"></param>
        public ProduktNummerTyp(Int32 nummer)
            : base(nummer)
        {
        }

        public override String ToString()
        {
            return "Produktnummer: " + nummer;
        }
    }
}
