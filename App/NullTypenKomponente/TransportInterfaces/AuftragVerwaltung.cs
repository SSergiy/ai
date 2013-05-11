using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypenKomponente
{
    public interface IAngebot 
    {
       Int32 Id();
       IDictionary<IProdukt,int> Produkte();
       DateTime GültigAb();
       DateTime GültigBis();
    }


    public interface IAuftrag 
    {
        Int32 Id();
        DateTime BeauftragtAm();
        IAngebot Angebot();
        IKunde Kunde();
    }
}
