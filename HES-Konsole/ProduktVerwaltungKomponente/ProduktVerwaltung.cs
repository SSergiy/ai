using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using NHibernate.Linq;

namespace ProduktVerwaltungKomponente
{
    class ProduktVerwaltung
    {
        private static readonly ISessionFactory persistenz = Persistenzmanager.Factory.Session();

        public IProdukt HoleProdukt(ProduktNummerTyp produktnummer)
        {
            using (var session = persistenz.OpenSession())
            {
                var temp = session.Query<Produkt>().ToList();

                if (temp.Count == 0)
                {
                    temp = erzeugeDummyProdukte();
                }
            }
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

        private List<Produkt> erzeugeDummyProdukte()
        {
            List<Produkt> result = new List<Produkt>();

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
                        result.Add(p);
                    }
                    trans.Commit();
                }
            }
            return result;
        }


        internal List<IProdukt> HoleAlleProdukte()
        {
            IList<Produkt> temp;
            List<IProdukt> result = new List<IProdukt>();
            using (var session = persistenz.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    temp = session.Query<Produkt>().ToList();

                    if (temp.Count == 0)
                    {
                        temp = erzeugeDummyProdukte();
                    }

                    foreach (Produkt produkt in temp)
                    {
                        result.Add(produkt);
                    }
                }
            }
            return result;
        }
    }
}
