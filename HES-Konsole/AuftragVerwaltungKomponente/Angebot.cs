using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;
using _0TypenKomponente.NummerTypen;

namespace AuftragVerwaltungKomponente
{
    public class Angebot : IAngebot
    {
        public Angebot() { }

        public virtual int Id { get; protected set; }
        public virtual AngebotNummerTyp nummer { get; set; }
        public virtual IList<IProduktAnzahl> Produkte { get; set; }
        public virtual DateTime GültigAb { get; set; }
        public virtual DateTime GültigBis { get; set; }

        public virtual void FügeNeuesProduktHinzu(IProduktAnzahl produktAnzahl)
        {
            if (Produkte == null) Produkte = new List<IProduktAnzahl>();
            Produkte.Add(produktAnzahl);
        }
    }

    public class AngebotMap : ClassMap<Angebot>
    {
        public AngebotMap()
        {
            Id(x => x.Id);
            Component<AngebotNummerTyp>(x => x.nummer, m =>
            {
                m.Map(x => x.nummer);
            }).Unique();

            HasMany<ProduktAnzahl>(x => x.Produkte).Table("AngebotProduktAnzahl").Not.LazyLoad().Cascade.SaveUpdate();
            //Map(x => x.GültigAb);
            //Map(x => x.GültigBis);
        }
    }
}
