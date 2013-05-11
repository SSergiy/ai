using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        class Bestellung
        {
            public virtual int Id { get; protected set; }
            public virtual DateTime Bestelldatum{ get; protected set; }
            public virtual int Menge { get; protected set; }
            public virtual bool Freigabe { get; protected set; }
            public virtual Wareneingangsmeldung Wareneingangsmeldung { get; protected set; }
        }

        public class BestellungMap : ClassMap<Bestellung>
        {
            public BestellungMap()
            {
                Id(x => x.Id);
                Id(x => x.Bestelldatum);
                Id(x => x.Menge);
                Id(x => x.Freigabe);
                Id(x => x.Wareneingangsmeldung);
            }
        }
    }
}