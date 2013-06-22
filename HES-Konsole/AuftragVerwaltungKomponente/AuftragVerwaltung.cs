using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using NHibernate.Linq;

namespace AuftragVerwaltungKomponente
{

    class AuftragVerwaltung
    {
        private static ISessionFactory persistenz = Persistenzmanager.Factory.Session();

        public IAngebot ErstelleAngebot(List<KeyValuePair<IProdukt, int>> produkte, DateTime gültigAb, DateTime gültigBis)
        {
            var produktfassade = new ProduktVerwaltungKomponente.ProduktVerwaltungFassade();

            var angebot = new Angebot();

            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var dic = new List<KeyValuePair<IProdukt, int>>();
                    foreach (var pair in produkte)
                    {
                        var produkt = produktfassade.HoleProdukt(pair.Key.nummer);
                        var pa = new ProduktAnzahl();
                        pa.Produkt = pair.Key;
                        pa.Anzahl = pair.Value;
                        angebot.FügeNeuesProduktHinzu(pa);
                    }
                    angebot.GültigAb = gültigAb;
                    angebot.GültigBis = gültigBis;
                    
                    session.SaveOrUpdate(angebot);
                    angebot.nummer = new AngebotNummerTyp(angebot.Id);
                    session.SaveOrUpdate(angebot);
                    transaction.Commit();
                }
            }

            return angebot;
        }

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
                    auftrag.Angebot = HoleAngebot(angebotnummer);
                    auftrag.Kunde = kundenfassade.HoleKunde(kundennummer);
                    auftrag.BeauftragtAm = beauftragtAm;
                    session.SaveOrUpdate(auftrag);
                    auftrag.nummer = new AuftragNummerTyp(auftrag.Id);
                    session.SaveOrUpdate(auftrag);
                    transaction.Commit();
                }
            }

            if (auftrag == null) throw new NullReferenceException();

            return auftrag;
        }

        internal IAngebot HoleAngebot(AngebotNummerTyp angebot)
        {
            IAngebot a = null;

            using (var session = persistenz.OpenSession())
            {
                var temp = session.Query<Angebot>().ToList();
                foreach (Angebot t in temp)
                {
                    if (t.nummer != null && t.nummer.nummer == angebot.nummer)
                        a = t;
                }
            }

            return a;
        }

        internal IAuftrag HoleAuftrag(AuftragNummerTyp auftrag)
        {
            IAuftrag a = null;

            using (var session = persistenz.OpenSession())
            {
                var temp = session.Query<Auftrag>().ToList();
                foreach (Auftrag t in temp)
                {
                    if (t.nummer.nummer == auftrag.nummer)
                        a = t;
                }
            }

            return a;
        }
    }
}
