using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;


namespace AuftragsVerwaltungsKomponente
{
    public class AuftragMap : ClassMap<Anwendungskern.AuftragsVerwaltungsKomponente.Auftrag>
    {
        public AuftragMap()
        {
            Id(x => x.id);
            Map(x => x.beauftragtAm);
            Map(x => x.angebot);
            Map(x => x.kunde);
        }
    }

    public class AngebotMap : ClassMap<Anwendungskern.AuftragsVerwaltungsKomponente.Angebot>
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
