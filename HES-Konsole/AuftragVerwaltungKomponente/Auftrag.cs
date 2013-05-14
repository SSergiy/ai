using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using KundeVerwaltungKomponente;
using TransportauftragVerwaltungKomponente;
using FluentNHibernate.Mapping;

namespace AuftragVerwaltungKomponente
{
    public class Auftrag : IAuftrag
    {
        public Auftrag() { }

        public virtual Int32 Id { get; private set; }
        public virtual DateTime BeauftragtAm { get; set; }
        public virtual IAngebot Angebot { get; set; }
        public virtual IKunde Kunde { get; set; }
        public virtual Lieferung Lieferung { get; protected set; }

    }

    public class AuftragMap : ClassMap<Auftrag>
    {
        public AuftragMap()
        {
            Id(x => x.Id);
            Map(x => x.BeauftragtAm);
            Map(x => x.Angebot);
            Map(x => x.Kunde);
            Map(x => x.Lieferung);
        }
    }
}
