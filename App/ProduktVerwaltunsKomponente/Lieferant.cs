using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Anwendungskern.NullTypenKomponente;
using NullTypenKomponente;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        class Lieferant : ILieferant
        {
            public virtual int Id { get; protected set; }
            public virtual string Name { get; protected set; } 
            public virtual AdresseTyp Adresse { get; protected set; }
            public virtual KontoverbindungTyp Kontoverbindung { get; protected set; }
            public virtual IList<IEinkaufsinfosatz> Einkaufsinfosatz { get; protected set; }
            public virtual IList<IBestellung> Bestellung { get; protected set; }
        }

        public class LieferantMap : ClassMap<ILieferant>
        {
            public LieferantMap()
            {
                Id(x => x.Id);
                Id(x => x.Name);
                Id(x => x.Adresse);
                Id(x => x.Kontoverbindung);
                HasMany(x => x.Einkaufsinfosatz).Table("LieferantEinkaufsinfosatz");
                HasMany(x => x.Bestellung).Table("LieferantBestellung");
            }
        }
    }
}