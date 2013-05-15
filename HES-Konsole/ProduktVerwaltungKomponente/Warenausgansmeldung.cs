using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace ProduktVerwaltungKomponente
{
    public class Warenausgansmeldung : IWarenausgansmeldung
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Datum { get; protected set; }
        public virtual int Menge { get; protected set; }

        public Warenausgansmeldung() { }
    }

    public class WarenausgansmeldungMap : ClassMap<Warenausgansmeldung>
    {
        public WarenausgansmeldungMap()
        {
            Id(x => x.Id);
            Map(x => x.Datum);
            Map(x => x.Menge);
        }
    }
}
