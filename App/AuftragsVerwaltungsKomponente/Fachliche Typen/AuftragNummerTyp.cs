using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        class AuftragNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            /// <summary>
            /// Nullable Constructor für NHibernate
            /// </summary>
            public AuftragNummerTyp() { }

            /// <summary>
            /// Basisconstructor, erzeugt ein neues AuftragNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public AuftragNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Auftragnummer:" + nummer;
            }
        }
    }
}