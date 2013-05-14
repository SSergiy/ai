using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.TransportInterfaces
{
    public interface IAngebot
    {
        int Id { get; }
        IDictionary<IProdukt, int> Produkte { get; }
        DateTime GültigAb { get; }
        DateTime GültigBis { get; }
    }


    public interface IAuftrag
    {
        int Id { get; }
        DateTime BeauftragtAm { get; }
        IAngebot Angebot { get; }
        IKunde Kunde { get; }
    }
}
