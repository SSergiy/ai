using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using _0TypenKomponente.TransportInterfaces;
using ProduktVerwaltungKomponente;

namespace AuftragVerwaltungKomponente
{
    public class ProduktAnzahl : IProduktAnzahl
    {
        public virtual int Id { get; protected set; }
        public virtual IProdukt Produkt { get; set; }
        public virtual int Anzahl { get; set; }
    }

    public class ProduktAnzahlMap : ClassMap<ProduktAnzahl>
    {
        public ProduktAnzahlMap()
        {
            Id(x => x.Id);
            HasOne<Produkt>(x => x.Produkt);
            Map(x => x.Anzahl);
        }
    }
}
