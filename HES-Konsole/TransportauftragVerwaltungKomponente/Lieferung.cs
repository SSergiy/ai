using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace TransportauftragVerwaltungKomponente
{
    public class Lieferung : ILieferung
    {
        public Lieferung() { }

        public virtual int Id { get; set; }
        public virtual ITransportauftrag Transportauftrag { get; set; }
        public virtual IAuftrag Auftrag { get; set; }
    }

    public class LieferungMap : ClassMap<ILieferung>
    {
        public LieferungMap()
        {
            Id(x => x.Id);
            Map(x => x.Transportauftrag);
            Map(x => x.Auftrag);
        }
    }
}
