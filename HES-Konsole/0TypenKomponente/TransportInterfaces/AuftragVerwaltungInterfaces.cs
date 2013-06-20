using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.NummerTypen;

namespace _0TypenKomponente.TransportInterfaces
{
    public interface IAngebot
    {
        int Id { get; }
        IList<IProduktAnzahl> Produkte { get; set;  }
        AngebotNummerTyp nummer { get; }
        void FügeNeuesProduktHinzu(IProduktAnzahl produktAnzahl);
        DateTime GültigAb { get; }
        DateTime GültigBis { get; }
    }


    public interface IAuftrag
    {
        int Id { get; }
        AuftragNummerTyp nummer { get; }
        DateTime BeauftragtAm { get; }
        IAngebot Angebot { get; }
        IKunde Kunde { get; }
    }

    public interface IProduktAnzahl
    {
        int Id { get; }
        IProdukt Produkt { get; }
        int Anzahl { get; }
    }
}
