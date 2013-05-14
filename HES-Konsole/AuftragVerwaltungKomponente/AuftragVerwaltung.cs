using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;

namespace AuftragVerwaltungKomponente
{

    class AuftragVerwaltung
        {
private static ISessionFactory persistenz = Persistenzmanager.Factory.Session();

            public IAngebot ErstelleAngebot(IDictionary<ProduktNummerTyp, int> produkte, DateTime gültigAb, DateTime gültigBis)
            {
                var produktfassade = new ProduktVerwaltungKomponente.ProduktVerwaltungFassade();
               
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
                        angebot.GültigAb = gültigAb;
                        angebot.GültigBis = gültigBis;
                        angebot.Produkte = dic;
                        session.SaveOrUpdate(angebot);
                        transaction.Commit();
                    }
                }

                return angebot;
            }

            //public void VerschickeRechnung(RechnungNummerTyp rechnung)
            public void VerschickeRechnung(RechnungNummerTyp rechnung)
            {
                var buchhaltungfassade = new BuchhaltungVerwaltungKomponente.BuchhaltungVerwaltungFassade();
            }

            public IAuftrag ErstelleAuftrag(DateTime beauftragtAm, AngebotNummerTyp angebotnummer, KundeNummerTyp kundennummer)
            {
                var kundenfassade = new KundeVerwaltungKomponente.KundeVerwaltungFassade();

                var auftrag = new Auftrag();
                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        auftrag.Angebot = session.Get<Angebot>(angebotnummer.nummer);
                        auftrag.Kunde = kundenfassade.HoleKunde(kundennummer);
                        auftrag.BeauftragtAm = beauftragtAm;
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
