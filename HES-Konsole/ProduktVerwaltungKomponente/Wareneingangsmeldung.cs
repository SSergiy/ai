using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;
using _0TypenKomponente;

namespace ProduktVerwaltungKomponente
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
            Map(x => x.Datum);
            Map(x => x.Lieferschein);
        }
    }
}
