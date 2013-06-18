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
        public virtual int Id { get; protected set; }
        public virtual DateTime RechnungsDatum { get; set; }
        public bool IstBezahlt() {
            return Restbetrag() <= 0;
        }
        public virtual List<IZahlungseingang> Zahlungseingang { get; set; }
        public virtual RechnungNummerTyp nummer { get; set; }
        public virtual double Betrag { get; set; }

        public double Restbetrag() { 
            var betrag = Betrag;

            foreach (IZahlungseingang i in Zahlungseingang)
            {
                betrag -= i.Betrag;
            }

            return betrag;
        }
    }

    public class RechnungMap : ClassMap<Rechnung>
    {
        public RechnungMap()
        {
            Id(x => x.Id);
            Map(x => x.RechnungsDatum);
            HasMany<Zahlungseingang>(x => x.Zahlungseingang).Table("RechnungZahlungseingang");
        }
    }
}
