using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace KundenVerwaltungsKomponente
    {
        public class KundeNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            public KundeNummerTyp()
            {
            }

            /// <summary>
            /// Basisconstructor, erzeugt ein neues KundeNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public KundeNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Kundenummer: " + nummer;
            }
        }
    }
}
