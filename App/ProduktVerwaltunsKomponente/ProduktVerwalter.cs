using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        class ProduktVerwalter
        {
            private static ISessionFactory persistenz;

            public Produkt HoleProdukt(ProduktNummerTyp produktnummer)
            {
                return persistenz.OpenSession().Get<Produkt>(produktnummer.nummer);
            }
        }
    }
}
