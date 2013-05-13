using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace ProduktVerwaltungsKomponente
    {
        public class Wareneingangsmeldung : IWareneingangsmeldung
        {
            public virtual int Id { get; protected set; }
            public virtual DateTime Datum { get; protected set; }
            public virtual LieferscheinTyp Lieferschein { get; protected set; }
        }

        public class WareneingangsmeldungMap : ClassMap<IWareneingangsmeldung>
        {
            public WareneingangsmeldungMap()
            {
                Id(x => x.Id);
                Id(x => x.Datum);
                Id(x => x.Lieferschein);
            }
        }
    }
}