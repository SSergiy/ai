using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anwendungskern.ProduktVerwaltungsKomponente;
using Anwendungskern.NullTypenKomponente;

namespace TestSzenario
{
    [TestClass]
    public class Szenario
    {
        [TestMethod]
        public void BestellungÜberHotline()
        {
            ProduktVerwaltungFassade f = new ProduktVerwaltungFassade();

            var ap = f.HoleAlleProdukte();

            Assert.AreEqual(10, ap.Count);

        }
    }
}
