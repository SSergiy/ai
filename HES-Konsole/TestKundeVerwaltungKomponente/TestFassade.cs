using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KundeVerwaltungKomponente;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente;
using _0TypenKomponente.TransportInterfaces;
using ProduktVerwaltungKomponente;
using BuchhaltungVerwaltungKomponente;
using AuftragVerwaltungKomponente;
using Nachrichten;
namespace TestVerwaltungKomponente
{

    [TestClass]
    public class TestFassade
    {
        [TestMethod]
        public void TestKundeVerwaltung()
        {
            KundeVerwaltungFassade f = new KundeVerwaltungFassade();

            KundeNummerTyp nummer = new KundeNummerTyp(1);
            AdresseTyp adresse = new AdresseTyp("1", "2", "3", "4", "5");
            IKunde k = f.ErstelleKunde("name", adresse);

            Assert.AreEqual("name", k.name);

            IKunde k2 = f.HoleKunde(nummer);
            Assert.AreEqual("name", k2.name);
        }

        [TestMethod]
        public void TestProduktVerwaltung()
        {
            ProduktVerwaltungFassade pv = new ProduktVerwaltungFassade();

            IProdukt p = pv.HoleProdukt(new ProduktNummerTyp(1));
            Assert.AreEqual(10, p.Lagerbestand);
        }

        [TestMethod]
        public void TestBuchhaltungVerwaltung()
        {
            BuchhaltungVerwaltungFassade buchhaltungVerwaltungFassade = new BuchhaltungVerwaltungFassade();
            AuftragVerwaltungFassade auftragVerwaltungFassade = new AuftragVerwaltungFassade();
            ProduktVerwaltungFassade produktVerwaltungFassade = new ProduktVerwaltungFassade();

            ProduktNummerTyp pn = new ProduktNummerTyp(1);
            var prodlist = new List<KeyValuePair<IProdukt, int>>();
            prodlist.Add(new KeyValuePair<IProdukt, int>(produktVerwaltungFassade.HoleProdukt(pn), 2));
            auftragVerwaltungFassade.ErstelleAngebot(prodlist, DateTime.Now, DateTime.Now);

            AngebotNummerTyp an = new AngebotNummerTyp(1);
            KundeNummerTyp kn = new KundeNummerTyp(1);

            IAuftrag NeuerAuftrag = auftragVerwaltungFassade.ErstelleAuftrag(DateTime.Now, an, kn);
            IRechnung r = buchhaltungVerwaltungFassade.ErstelleRechnung(NeuerAuftrag);

            IRechnung test = buchhaltungVerwaltungFassade.HoleRechnung(r.nummer);

            buchhaltungVerwaltungFassade.VerbucheZahlung(r.nummer, 10);

            Assert.AreEqual(r.nummer.nummer, test.nummer.nummer);

        }

        [TestMethod]
        public void TestAuftragVerwaltung()
        {
            AuftragVerwaltungFassade auftragVerwaltungFassade = new AuftragVerwaltungFassade();
            ProduktVerwaltungFassade produktVerwaltungFassade = new ProduktVerwaltungFassade();

            ProduktNummerTyp pn = new ProduktNummerTyp(1);
            var prodlist = new List<KeyValuePair<IProdukt, int>>();
            prodlist.Add(new KeyValuePair<IProdukt, int>(produktVerwaltungFassade.HoleProdukt(pn), 2));


            IAngebot an = auftragVerwaltungFassade.ErstelleAngebot(prodlist, DateTime.Now, DateTime.Now);
            KundeNummerTyp kn = new KundeNummerTyp(1);

            IAuftrag NeuerAuftrag = auftragVerwaltungFassade.ErstelleAuftrag(DateTime.Now, an.nummer, kn);


            IAuftrag a = auftragVerwaltungFassade.HoleAuftrag(NeuerAuftrag.nummer);

            Assert.AreEqual(NeuerAuftrag.Angebot.nummer, a.Angebot.nummer);
            Assert.AreEqual(NeuerAuftrag.Id, a.Id);
            Assert.AreEqual(NeuerAuftrag.nummer.nummer, a.nummer.nummer);
            Assert.AreEqual(NeuerAuftrag.BeauftragtAm.ToString(), a.BeauftragtAm.ToString());
        }

    }
}
