using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using KundeVerwaltungKomponente;
using FluentNHibernate.Mapping;
using _0TypenKomponente.NummerTypen;

namespace AuftragVerwaltungKomponente
{
    public class Auftrag : IAuftrag
    {
        public Auftrag() { }

        public virtual int Id { get; protected set; }
        public virtual AuftragNummerTyp nummer { get; set; }
        public virtual DateTime BeauftragtAm { get; set; }
        public virtual IAngebot Angebot { get; set; }
        public virtual IKunde Kunde { get; set; }
    }

    public class AuftragMap : ClassMap<Auftrag>
    {
        public AuftragMap()
        {
            Id(x => x.Id);
            Map(x => x.BeauftragtAm);
            HasOne<Angebot>(x => x.Angebot);
            HasOne<Kunde>(x => x.Kunde);
            Component<AuftragNummerTyp>(x => x.nummer, m => // hiermit mappen wir einen fachlichen Datentyp innerhalb einer Entität
            {
                m.Map(x => x.nummer);
            }).Unique();
        }
    }
}
