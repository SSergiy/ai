﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using FluentNHibernate.Mapping;

namespace BuchhaltungVerwaltungKomponente
{
    public class Zahlungseingang : IZahlungseingang
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Eingangsdatum { get; set; }
        public virtual double Betrag { get; set; }
    }

    public class ZahlungseingangMap : ClassMap<Zahlungseingang>
    {
        public ZahlungseingangMap()
        {
            Id(x => x.Id);
            Map(x => x.Eingangsdatum);
            Map(x => x.Betrag);
        }
    }
}
