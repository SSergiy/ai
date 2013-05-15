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

        private static int AuftrNrCount = 0;

        private int neueAuftrNr()
        {
            AuftrNrCount += 1;
            return AuftrNrCount;
        }

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

                Auftrag auftrag = null;
                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        auftrag = new Auftrag();
                        auftrag.Angebot = session.Get<Angebot>(angebotnummer.nummer);
                        auftrag.Kunde = kundenfassade.HoleKunde(kundennummer);
                        auftrag.BeauftragtAm = beauftragtAm;
                        auftrag.nummer = new AuftragNummerTyp(neueAuftrNr()) ;
                        session.SaveOrUpdate(auftrag);
                        transaction.Commit();
                    }
                }

                if (auftrag == null) throw new NullReferenceException();

                return auftrag;
            }

            internal IAuftrag HoleAuftrag(AuftragNummerTyp auftrag)
            {
                IAuftrag a = null;

                using (var session = persistenz.OpenSession())
                {
                    a = session.Get<Auftrag>(auftrag.nummer);
                }

                return a;
            }
        }
}
