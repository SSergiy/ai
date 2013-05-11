using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;
using Anwendungskern.ProduktVerwaltunsKomponente;
using NHibernate;
using NullTypenKomponente;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        class AuftragsVerwalter
        {
            private static ISessionFactory persistenz =  Persistence_Management_Komponente.Implementations.PersistenceManagerFactory.Persistenz();

            public IAngebot ErstelleAngebot(IDictionary<ProduktVerwaltunsKomponente.ProduktNummerTyp, int> produkte, DateTime gültigAb, DateTime gültigBis)
            {
                
                var produktfassade = new ProduktVerwaltunsKomponente.ProduktVerwaltungFassade();
               
                var angebot = new Angebot();

                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {

                        var dic = new Dictionary<Produkt, int>();
                        foreach (var pair in produkte)
                        {
                            var produkt = produktfassade.HoleProdukt(pair.Key);
                            dic.Add(produkt, pair.Value);
                        }
                        angebot.gültigAb = gültigAb;
                        angebot.gültigBis = gültigBis;
                        session.SaveOrUpdate(angebot);
                        transaction.Commit();
                    }
                }

                return angebot;
            }

            public IAuftrag ErstelleAuftrag(DateTime beauftragsAm, AngebotNummerTyp angebotnummer, KundenVerwaltungsKomponente.KundeNummerTyp kundennummer)
            {
                var kundenfassade = new KundenVerwaltungsKomponente.KundenVerwaltungFassade();

                var auftrag = new Auftrag();
                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        auftrag.angebot = persistenz.OpenSession().Get<Angebot>(angebotnummer.nummer);
                        auftrag.kunde = kundenfassade.HoleKunde(kundennummer);
                        auftrag.beauftragtAm = beauftragsAm;
                        session.SaveOrUpdate(auftrag);
                        transaction.Commit();
                    }
                }
                return auftrag;
            }
        }
    }
}