using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        class Orderbuch
        {
            public virtual int Id { get; protected set; }
            public virtual IList<Orderbuchsatz> Orderbuchsatz { get; protected set; }
        }

        public class OrderbuchMap : ClassMap<Orderbuch>
        {
            public OrderbuchMap()
            {
                Id(x => x.Id);
                HasMany(x => x.Orderbuchsatz).Table("OrderbuchOrderbuchsatz");
            }
        }
    }
}