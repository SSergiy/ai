using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace NullTypenKomponente
    {
        class LieferantNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            public LieferantNummerTyp()
            {
            }

            /// <summary>
            /// Basisconstructor, erzeugt ein neues LieferantNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public LieferantNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Lieferantnummer: " + nummer;
            }
        }
    }
}