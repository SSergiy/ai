using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace ProduktVerwaltungKomponente
{
    public class Orderbuch : IOrderbuch
    {
        public virtual int Id { get; protected set; }
        public virtual IList<IOrderbuchsatz> Orderbuchsatz { get; protected set; }

        public Orderbuch() { }
    }

    public class OrderbuchMap : ClassMap<Orderbuch>
    {
        public OrderbuchMap()
        {
            Id(x => x.Id);
            HasMany<Orderbuchsatz>(x => x.Orderbuchsatz).Table("OrderbuchOrderbuchsatz");
        }
    }
}
