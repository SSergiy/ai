using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.ProduktVerwaltunsKomponente;

namespace NullTypenKomponente.TransportTypen
{
    public class AngebotTyp(Int32 id, IDictionary<Produkt, int> produkte, DateTime gültigAb, DateTime gültigBis)
    }
}
