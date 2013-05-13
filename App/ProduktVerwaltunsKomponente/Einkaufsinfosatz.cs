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
        class Einkaufsinfosatz : IEinkaufsinfosatz
        {
            public virtual int Id { get; protected set; }
            public virtual DateTime GültigAb { get; protected set; }
            public virtual DateTime GültigBis { get; protected set; }
            public virtual double Planlieferzeit { get; protected set; }
            public virtual int Normalmenge { get; protected set; }
            public virtual double Preis { get; protected set; }
        }

        public class EinkaufsinfosatzhMap : ClassMap<IEinkaufsinfosatz>
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
}