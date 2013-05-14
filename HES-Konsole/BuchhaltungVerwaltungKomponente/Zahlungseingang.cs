using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace BuchhaltungVerwaltungKomponente
{
    class Zahlungseingang : IZahlungseingang
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Eingangsdatum { get; protected set; }
        public virtual double Betrag { get; protected set; }
    }

    public class ZahlungseingangMap : ClassMap<IZahlungseingang>
    {
        public ZahlungseingangMap()
        {
            Id(x => x.Id);
            Map(x => x.Eingangsdatum);
            Map(x => x.Betrag);
        }
    }
}
