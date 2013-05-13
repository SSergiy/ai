using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Anwendungskern.NullTypenKomponente;
using NHibernate.Linq;

namespace Anwendungskern
{
    namespace ProduktVerwaltungsKomponente
    {
        class ProduktVerwalter
        {
            private static readonly ISessionFactory persistenz = Persistenzmanager.Factory.Session();

            public IProdukt HoleProdukt(ProduktNummerTyp produktnummer)
            {
                return persistenz.OpenSession().Get<Produkt>(produktnummer.nummer);
            }

            public bool PrüfeProduktLagerbestand(IDictionary<ProduktNummerTyp, int> produktliste)
            {
                foreach (var p in produktliste)
                {
                    if (!PrüfeProduktLagerbestand(p.Key, p.Value)) return false;
                }

                return true;
            }

            public bool PrüfeProduktLagerbestand(ProduktNummerTyp nummer, int anzahl)
            {
                return true;
            }

            public void MeldeProduktAuslagerung(IDictionary<ProduktNummerTyp, int> produktliste, int auftragsnummer)
            {
                // ok
            }

            internal List<IProdukt> HoleAlleProdukte()
            {
                List<IProdukt> ret = persistenz.OpenSession().Query<IProdukt>().ToList();

                if (ret.Count == 0)
                {
                    using (var session = persistenz.OpenSession())
                    {
                        using (var trans = session.BeginTransaction())
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                Produkt p = new Produkt();
                                p.Lagerbestand = 10;
                                p.Name = "Produkt " + i;
                                session.SaveOrUpdate(p);
                            }
                            trans.Commit();
                        }
                    }
                    ret = persistenz.OpenSession().Query<IProdukt>().ToList();
                }

                return ret;
            }
        }
    }
}
