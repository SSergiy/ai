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

namespace TestVerwaltungKomponente
{
    [TestClass]
    public class TestFassade
    {
        [TestMethod]
        public void TestKundeVerwaltung()
        {
            KundeVerwaltungFassade f = new KundeVerwaltungFassade();
            // , String name, AdresseTyp adresse)
            KundeNummerTyp nummer = new KundeNummerTyp(1);
            AdresseTyp adresse = new AdresseTyp("1", "2", "3", "4", "5");
            IKunde k = f.ErstelleKunde(nummer, "name", adresse);

            Assert.AreEqual("name", k.name);

            IKunde k2 = f.HoleKunde(nummer);
            Assert.AreEqual("name", k2.name);
        }

        //[TestMethod]
        //public void TestProduktVerwaltung()
        //{
        //    ProduktVerwaltungFassade pv = new ProduktVerwaltungFassade();

        //    IProdukt p = pv.HoleProdukt(new ProduktNummerTyp(1));
        //    Assert.AreEqual(10, p.Lagerbestand);
        //}

        //[TestMethod]
        //public void TestBuchhaltungVerwaltung()
        //{
        //    BuchhaltungVerwaltungFassade f = new BuchhaltungVerwaltungFassade();

        //    //f.ErstelleRechnung(null);
        //}

        [TestMethod]
        public void TestAuftragVerwaltung()
        {
            //AuftragVerwaltungFassade f = new AuftragVerwaltungFassade();

            //AngebotNummerTyp an = new AngebotNummerTyp(1);
            //KundeNummerTyp kn = new KundeNummerTyp(1);

            //IAuftrag auf = f.ErstelleAuftrag(DateTime.Now, an, kn);

            //AuftragNummerTyp n = new AuftragNummerTyp(auf.Id);

            //IAuftrag a = f.HoleAuftrag(n);

            //Assert.AreEqual(auf.BeauftragtAm, a.BeauftragtAm);
        }

    }
}
