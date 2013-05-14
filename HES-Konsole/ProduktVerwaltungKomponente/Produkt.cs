using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace ProduktVerwaltungKomponente
{
    public class Produkt : IProdukt
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual int Lagerbestand { get; set; }
        public virtual IOrderbuch Orderbuch { get; set; }
        public virtual IList<IEinkaufsinfosatz> Einkaufsinfosatz { get; set; }
        public virtual IList<IWarenausgansmeldung> Warenausgansmeldung { get; set; }
    }

    public class ProduktMap : ClassMap<Produkt>
    {
        public ProduktMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Lagerbestand);
            Map(x => x.Orderbuch);
            HasManyToMany(x => x.Einkaufsinfosatz).Table("ProduktEinkaufsinfosatz");
            HasManyToMany(x => x.Warenausgansmeldung).Table("ProduktWarenausgansmeldung");
        }
    }
}
