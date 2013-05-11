using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace BuchhaltungsVerwaltungsKomponente
    {
        public class Rechnung
        {
            public virtual int Id { get; protected set; }
            public virtual DateTime RechnungsDatum { get; protected set; }
            public virtual bool IstBezahlt { get; protected set; }
            public virtual List<Zahlungseingang> Zahlungseingang { get; protected set; }
        }

        public class RechnungMap : ClassMap<Rechnung>
        {
            public RechnungMap()
            {
                Id(x => x.Id);
                Map(x => x.RechnungsDatum);
                Map(x => x.IstBezahlt);
                HasMany(x => x.Zahlungseingang).Table("RechnungZahlungseingang");
            }
        }
    }
}