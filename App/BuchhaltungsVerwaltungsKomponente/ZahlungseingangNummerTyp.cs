using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace BuchhaltungsVerwaltungsKomponente
    {
        class ZahlungseingangNummerTyp
        {
            public virtual Int32 nummer { get; private set; }

            /// <summary>
            /// Nullable Constructor für NHibernate
            /// </summary>
            public ZahlungseingangNummerTyp() { }

            /// <summary>
            /// Basisconstructor, erzeugt ein neues ZahlungseingangNummerTyp Objekt.
            /// </summary>
            /// <param name="nummer"></param>
            public ZahlungseingangNummerTyp(Int32 nummer)
            {
                this.nummer = nummer;
            }

            public override String ToString()
            {
                return "Zahlungseingangnummer:" + nummer;
            }
        }
    }
}