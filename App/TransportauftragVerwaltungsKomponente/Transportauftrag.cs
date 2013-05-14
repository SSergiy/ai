using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace TransportauftragVerwaltungsKomponente
    {
        public class Transportauftrag
        {
            public virtual int Id { get; protected set; }
            public virtual DateTime Ausgangsdatum { get; protected set; }
            public virtual bool LieferungErfolgt { get; protected set; }
            public virtual DateTime Lieferdatum { get; protected set; }
            //public virtual TransportdienstleisterTyp Transportdienstleister { get; protected set; }
        }

        public class TransportauftragMap : ClassMap<Transportauftrag>
        {
            public TransportauftragMap()
            {
                Id(x => x.Id);
                Map(x => x.Ausgangsdatum);
                Map(x => x.LieferungErfolgt);
                Map(x => x.Lieferdatum);
                //Map(x => x.Transportdienstleister);
            }
        }
    }
}