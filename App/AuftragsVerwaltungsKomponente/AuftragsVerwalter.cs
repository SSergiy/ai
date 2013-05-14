using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;
using Anwendungskern.ProduktVerwaltungsKomponente;
using NHibernate;

namespace Anwendungskern
{
    namespace AuftragsVerwaltungsKomponente
    {
        class AuftragsVerwalter
        {
            private static ISessionFactory persistenz = Persistenzmanager.Factory.Session();

            public IAngebot ErstelleAngebot(IDictionary<ProduktNummerTyp, int> produkte, DateTime gültigAb, DateTime gültigBis)
            {
                var produktfassade = new ProduktVerwaltungsKomponente.ProduktVerwaltungFassade();
               
                var angebot = new Angebot();

                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var dic = new Dictionary<IProdukt, int>();
                        foreach (var pair in produkte)
                        {
                            var produkt = produktfassade.HoleProdukt(pair.Key);
                            dic.Add(produkt, pair.Value);
                        }
                        angebot.gültigAb = gültigAb;
                        angebot.gültigBis = gültigBis;
                        angebot.produkte = dic;
                        session.SaveOrUpdate(angebot);
                        transaction.Commit();
                    }
                }

                return angebot;
            }

            //public void VerschickeRechnung(RechnungNummerTyp rechnung)
            public void VerschickeRechnung(RechnungNummerTyp rechnung)
            {
                var buchhaltungfassade = new BuchhaltungsVerwaltungsKomponente.BuchhaltungsVerwaltungFassade();
            }

            public IAuftrag ErstelleAuftrag(DateTime beauftragsAm, AngebotNummerTyp angebotnummer, KundeNummerTyp kundennummer)
            {
                var kundenfassade = new KundenVerwaltungsKomponente.KundenVerwaltungFassade();

                var auftrag = new Auftrag();
                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        auftrag.angebot = session.Get<Angebot>(angebotnummer.nummer);
                        auftrag.kunde = kundenfassade.HoleKunde(kundennummer);
                        auftrag.beauftragtAm = beauftragsAm;
                        session.SaveOrUpdate(auftrag);
                        transaction.Commit();
                    }
                }
                return auftrag;
            }

            internal IAuftrag HoleAuftrag(AuftragNummerTyp auftrag)
            {
                IAuftrag a = null;
                a = persistenz.OpenSession().Get<Auftrag>(auftrag.nummer);
                if (a == null) throw new NullReferenceException();
                return a;
            }
        }
    }
}