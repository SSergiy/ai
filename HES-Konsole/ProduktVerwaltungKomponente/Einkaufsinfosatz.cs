using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace ProduktVerwaltungKomponente
{
    public class Einkaufsinfosatz : IEinkaufsinfosatz
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime GültigAb { get; protected set; }
        public virtual DateTime GültigBis { get; protected set; }
        public virtual double Planlieferzeit { get; protected set; }
        public virtual int Normalmenge { get; protected set; }
        public virtual double Preis { get; protected set; }

        public Einkaufsinfosatz() { }
    }

    public class EinkaufsinfosatzhMap : ClassMap<Einkaufsinfosatz>
    {
        public EinkaufsinfosatzhMap()
        {
            Id(x => x.Id);
            Map(x => x.GültigAb);
            Map(x => x.GültigBis);
            Map(x => x.Planlieferzeit);
            Map(x => x.Normalmenge);
            Map(x => x.Preis);
        }
    }
}
