using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NullTypenKomponente;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        public class Orderbuch : IOrderbuch
        {
            public Orderbuch() {}

            public virtual int Id { get; protected set; }
            public virtual IList<IOrderbuchsatz> Orderbuchsatz { get; protected set; }
        }

        public class OrderbuchMap : ClassMap<IOrderbuch>
        {
            public OrderbuchMap()
            {
                Id(x => x.Id);
                HasMany(x => x.Orderbuchsatz).Table("OrderbuchOrderbuchsatz");
            }
        }
    }
}