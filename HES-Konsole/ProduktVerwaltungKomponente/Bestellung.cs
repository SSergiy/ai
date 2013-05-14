using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace ProduktVerwaltungKomponente
{
    public class Bestellung : IBestellung
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Bestelldatum { get; protected set; }
        public virtual int Menge { get; protected set; }
        public virtual bool Freigabe { get; protected set; }
        public virtual IWareneingangsmeldung Wareneingangsmeldung { get; protected set; }
    }

    public class BestellungMap : ClassMap<Bestellung>
    {
        public BestellungMap()
        {
            Id(x => x.Id);
            Map(x => x.Bestelldatum);
            Map(x => x.Menge);
            Map(x => x.Freigabe);
            Map(x => x.Wareneingangsmeldung);
        }
    }
}
