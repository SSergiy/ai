using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        public class Produkt : IProdukt
        {
            public virtual int Id { get; protected set; }
            public virtual int Name { get; protected set; }
            public virtual int Lagerbestand { get; protected set; }
            public virtual IOrderbuch Orderbuch { get; protected set; }
            public virtual IList<IEinkaufsinfosatz> Einkaufsinfosatz { get; protected set; }
            public virtual IList<IWarenausgansmeldung> Warenausgansmeldung { get; protected set; }
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
}