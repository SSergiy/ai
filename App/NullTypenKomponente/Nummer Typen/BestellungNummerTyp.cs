using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace ProduktVerwaltungsKomponente
    {
        class BestellungNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            public BestellungNummerTyp()
            {
            }

            /// <summary>
            /// Basisconstructor, erzeugt ein neues BestellungNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public BestellungNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Bestellungnummer: " + nummer;
            }
        }
    }
}