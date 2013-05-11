using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NullTypenKomponente.TransportInterfaces;

namespace Anwendungskern
{
    namespace BuchhaltungsVerwaltungsKomponente
    {
        class Zahlungseingang : IZahlungseingang
        {
            public virtual int Id { get; protected set; }
            public virtual DateTime Eingangsdatum { get; protected set; }
            public virtual double Betrag { get; protected set; }
        }

        public class ZahlungseingangMap : ClassMap<IZahlungseingang>
        {
            public ZahlungseingangMap()
            {
                Id(x => x.Id);
                Map(x => x.Eingangsdatum);
                Map(x => x.Betrag);
            }
        }
    }
}