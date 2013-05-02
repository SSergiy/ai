using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Anwendungskern {

    namespace SchluesselverwaltungsKomponente
    {
        public class SchluesselZaehler
            {
                public virtual Int32 id { get; private set; }
                public virtual String name { get; set; }
                public virtual Int32 wert { get; set; }

                public SchluesselZaehler()
                {
                }

                public SchluesselZaehler(String name, Int32 wert)
                {
                    this.name = name;
                    this.wert = wert;
                }
            }

        public class SchluesselZaehlerMap : ClassMap<SchluesselZaehler>
            {
                public SchluesselZaehlerMap()
                {
                    Id(x => x.id);
                    Map(x => x.name).Unique();
                    Map(x => x.wert);
                }
            }
    }
}
