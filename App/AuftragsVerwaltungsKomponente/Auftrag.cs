using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.KundenVerwaltungsKomponente;
using FluentNHibernate.Mapping;
using Anwendungskern.TransportauftragVerwaltungsKomponente;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        public class Auftrag
        {
            public Auftrag() { }
            public virtual Int32 id { get; private set; }
            public virtual DateTime beauftragtAm;
            public virtual Angebot angebot;
            public virtual Kunde kunde;
            public virtual Lieferung Lieferung { get; protected set; }
        }

        public class AuftragMap : ClassMap<Auftrag> 
        {
            public AuftragMap()
            {
                Id(x => x.id);
                Map(x => x.beauftragtAm);
                Map(x => x.angebot);
                Map(x => x.kunde);
                Map(x => x.Lieferung);
            }
        }
    
    }
}