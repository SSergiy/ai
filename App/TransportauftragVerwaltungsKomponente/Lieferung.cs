using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace TransportauftragVerwaltungsKomponente
    {
        public class Lieferung
        {
            public virtual int Id { get; protected set; }
            public virtual Transportauftrag Transportauftrag { get; protected set; }
        }

        public class LieferungMap : ClassMap<Lieferung>
        {
            public LieferungMap()
            {
                Id(x => x.Id);
                Map(x => x.Transportauftrag);
            }
        }
    }
}