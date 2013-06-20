using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;
using _0TypenKomponente.NummerTypen;

namespace BuchhaltungVerwaltungKomponente
{
    public class Rechnung : IRechnung
    {
        public Rechnung() { }

        public virtual int Id { get; protected set; }
        public virtual DateTime RechnungsDatum { get; set; }

        public virtual bool IstBezahlt()
        {
            return Restbetrag() <= 0;
        }

        public virtual IList<IZahlungseingang> Zahlungseingang { get; set; }
        public virtual RechnungNummerTyp nummer { get; set; }
        public virtual double Betrag { get; set; }

        public virtual double Restbetrag()
        { 
            var betrag = Betrag;

            foreach (IZahlungseingang i in Zahlungseingang)
            {
                betrag -= i.Betrag;
            }

            return betrag;
        }

        public virtual void NeuerZahlungseingang(IZahlungseingang zahlungseingang)
        {
            Zahlungseingang.Add(zahlungseingang);
        }
    }

    public class RechnungMap : ClassMap<Rechnung>
    {
        public RechnungMap()
        {
            Id(x => x.Id);
            Component<RechnungNummerTyp>(x => x.nummer, m =>
            {
                m.Map(x => x.nummer);
            }).Unique();
            Map(x => x.RechnungsDatum);
            HasMany<Zahlungseingang>(x => x.Zahlungseingang).Table("RechnungZahlungseingang").Not.LazyLoad().Cascade.SaveUpdate();
        }
    }
}
