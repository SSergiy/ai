using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace BuchhaltungsVerwaltungsKomponente
    {
        class RechnungNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            /// <summary>
            /// Nullable Constructor für NHibernate
            /// </summary>
            public RechnungNummerTyp() { }

            /// <summary>
            /// Basisconstructor, erzeugt ein neues RechnungNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public RechnungNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Rechnungnummer" + nummer;
            }
        }
    }
}
