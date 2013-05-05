using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.ProduktVerwaltunsKomponente;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        public class Angebot
        {
            public Angebot() { }
            public virtual Int32 id { get; private set; }
            public virtual IDictionary<Produkt, int> produkte { get; set; }
            public virtual DateTime gültigAb { get; set; }
            public virtual DateTime gültigBis { get; set; }
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