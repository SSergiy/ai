using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente;
using FluentNHibernate.Mapping;

namespace ProduktVerwaltungKomponente
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
            Map(x => x.Name);
            Component<AdresseTyp>(x => x.Adresse, m =>
            {
                m.Map(x => x.strasse);
                m.Map(x => x.hausnummer);
                m.Map(x => x.postleitzahl);
                m.Map(x => x.ort);
                m.Map(x => x.land);
            });
            Map(x => x.Kontoverbindung);
            HasMany(x => x.Einkaufsinfosatz).Table("LieferantEinkaufsinfosatz");
            HasMany(x => x.Bestellung).Table("LieferantBestellung");
        }
    }
}
