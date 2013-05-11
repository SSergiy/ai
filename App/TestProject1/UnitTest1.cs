using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Anwendungskern.ProduktVerwaltunsKomponente;
using Anwendungskern.NullTypenKomponente;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pvf = new ProduktVerwaltungFassade();

            IDictionary<ProduktNummerTyp, int> i = new Dictionary<ProduktNummerTyp, int>();

            i.Add(new ProduktNummerTyp(1),96);
            i.Add(new ProduktNummerTyp(2), 48);
            i.Add(new ProduktNummerTyp(3), 24);
            i.Add(new ProduktNummerTyp(4), 12);
            i.Add(new ProduktNummerTyp(5), 6);
            i.Add(new ProduktNummerTyp(6), 3);

            Assert.AreEqual(true, pvf.PrüfeProduktLagerbestand(i));

        }
    }
}
