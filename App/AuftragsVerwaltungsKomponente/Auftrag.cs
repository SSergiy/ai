using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.KundenVerwaltungsKomponente;
using FluentNHibernate.Mapping;
using NullTypenKomponente;
namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        public class Auftrag : IAuftrag
        {
            public Auftrag() { }
            public virtual Int32 id { get; private set; }
            public virtual DateTime beauftragtAm;
            public virtual Angebot angebot;
            public virtual Kunde kunde;




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
            }
        }
    
    }
}