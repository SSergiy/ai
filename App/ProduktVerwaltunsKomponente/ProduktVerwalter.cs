using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Anwendungskern
{
    namespace ProduktVerwaltunsKomponente
    {
        class ProduktVerwalter
        {
            private static readonly ISessionFactory persistenz = Persistence_Management_Komponente.Implementations.PersistenceManagerFactory.Persistenz();

            public Produkt HoleProdukt(ProduktNummerTyp produktnummer)
            {
                return persistenz.OpenSession().Get<Produkt>(produktnummer.nummer);
            }
        }
    }
}
