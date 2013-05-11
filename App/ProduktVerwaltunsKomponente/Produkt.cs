using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        public class Produkt
        {
            public virtual int Id { get; protected set; }
            public virtual int Name { get; protected set; }
            public virtual int Lagerbestand { get; protected set; }
            public virtual Orderbuch Orderbuch { get; protected set; }
            public virtual IList<Einkaufsinfosatz> Einkaufsinfosatz { get; protected set; }
            public virtual IList<Warenausgansmeldung> Warenausgansmeldung { get; protected set; }
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