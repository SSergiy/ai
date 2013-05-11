using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        class Orderbuchsatz
        {
            public virtual int Id { get; protected set; }
            public virtual DateTime GültigAb  { get; protected set; }
            public virtual DateTime GültigBis { get; protected set; }

        }

        public class OrderbuchsatzMap : ClassMap<Orderbuchsatz>
        {
            public OrderbuchsatzMap()
            {
                Id(x => x.Id);
                Map(x => x.GültigAb);
                Map(x => x.GültigBis);
            }
        }
    }
}