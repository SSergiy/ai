using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        public class ProduktNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            public ProduktNummerTyp()
            {
            }

            /// <summary>
            /// Basisconstructor, erzeugt ein neues ProduktNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public ProduktNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Produktnummer: " + nummer;
            }
        }
    }
}