using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Anwendungskern.NullTypenKomponente;

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

            public bool PrüfeProduktLagerbestand(IDictionary<ProduktNummerTyp, int> produktliste)
            {
                foreach (var p in produktliste) {
                    if (!PrüfeProduktLagerbestand(p.Key, p.Value)) return false;
                }

                return true;
            }

            public bool PrüfeProduktLagerbestand(ProduktNummerTyp nummer, int anzahl) {
                return true;
            }

            public void MeldeProduktAuslagerung(IDictionary<ProduktNummerTyp, int> produktliste, int auftragsnummer)
            {

            }
        }
    }
}
