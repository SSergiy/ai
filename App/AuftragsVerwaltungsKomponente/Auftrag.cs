using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.KundenVerwaltungsKomponente;
using FluentNHibernate.Mapping;
using Anwendungskern.TransportauftragVerwaltungsKomponente;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        public class Auftrag : IAuftrag
        {
            public Auftrag() { }

            public virtual Int32 id { get; private set; }
            public virtual DateTime beauftragtAm { get; set; }
            public virtual Angebot angebot { get; set; }
            public virtual Kunde kunde { get; set; }

            public virtual Lieferung Lieferung { get; protected set; }

            public int Id()
            {
                return this.id;
            }

            public DateTime BeauftragtAm()
            {
                return beauftragtAm;
            }

            public IAngebot Angebot()
            {
                return angebot;
            }

            public IKunde Kunde()
            {
                return kunde;
            }


            IKunde IAuftrag.Kunde()
            {
                return kunde;
            }
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