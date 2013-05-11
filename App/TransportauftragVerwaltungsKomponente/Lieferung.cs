using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NullTypenKomponente.TransportInterfaces;

namespace Anwendungskern
{
    namespace TransportauftragVerwaltungsKomponente
    {
        public class Lieferung : ILieferung
        {
            public Lieferung() { }

            public virtual int Id { get; protected set; }
            public virtual ITransportauftrag Transportauftrag { get; protected set; }
        }

        public class LieferungMap : ClassMap<ILieferung>
        {
            public LieferungMap()
            {
                Id(x => x.Id);
                Map(x => x.Transportauftrag);
            }
        }
    }
}