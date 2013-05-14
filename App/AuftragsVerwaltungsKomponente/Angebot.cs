using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.ProduktVerwaltungsKomponente;
using FluentNHibernate.Mapping;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        public class Angebot : IAngebot
        {
            public Angebot() { }
            public virtual Int32 id { get; private set; }
            public virtual IDictionary<IProdukt, int> produkte { get; set; }
            public virtual DateTime gültigAb { get; set; }
            public virtual DateTime gültigBis { get; set; }

            public int Id()
            {
                return id;
            }

            public IDictionary<IProdukt, int> Produkte()
            {
                return produkte;
            }

            public DateTime GültigAb()
            {
                return gültigAb;
            }

            public DateTime GültigBis()
            {
                return gültigBis;
            }
        }

        public class AngebotMap : ClassMap<Angebot> 
        {
            public AngebotMap() 
            {
                Id(x => x.id);
                // TODO: Testen !
                Map(x => x.produkte);
                Map(x => x.gültigAb);
                Map(x => x.gültigBis);
            }
        }





    }
}