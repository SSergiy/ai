using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;
using _0TypenKomponente.NummerTypen;

namespace ProduktVerwaltungKomponente
{
    public class Produkt : IProdukt
    {
        public virtual int Id { get; protected set; }
        public virtual ProduktNummerTyp nummer { get; set; }
        public virtual string Name { get; set; }
        public virtual int Lagerbestand { get; set; }
        public virtual IOrderbuch Orderbuch { get; set; }

        public virtual IList<IEinkaufsinfosatz> Einkaufsinfosatz { get; set; }
        public virtual IList<IWarenausgansmeldung> Warenausgansmeldung { get; set; }

        public Produkt() { }
    }

    public class ProduktMap : ClassMap<Produkt>
    {
        public ProduktMap()
        {
            Id(x => x.Id);
            Component<ProduktNummerTyp>(x => x.nummer, m =>
            {
                m.Map(x => x.nummer);
            }).Unique();

            Map(x => x.Name);
            Map(x => x.Lagerbestand);
            HasOne<Orderbuch>(x => x.Orderbuch);
            HasManyToMany<Einkaufsinfosatz>(x => x.Einkaufsinfosatz).Table("ProduktEinkaufsinfosatz");
            HasManyToMany<Warenausgansmeldung>(x => x.Warenausgansmeldung).Table("ProduktWarenausgansmeldung");
        }
    }
}
