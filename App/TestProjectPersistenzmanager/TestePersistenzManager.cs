using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Anwendungskern.AuftragsVerwaltungsKomponente;
using Anwendungskern.NullTypenKomponente;

namespace TestProjectPersistenzmanager
{
    [TestClass]
    public class TestePersistenzManager
    {
        private static readonly ISessionFactory persistenz = Persistence_Management_Komponente.Implementations.PersistenceManagerFactory.Persistenz();

        [TestMethod]
        public void ErstelleAuftrag()
        {
            var auftragsverwaltung = new AuftragsVerwaltungFassade();
            var auftrag = auftragsverwaltung.ErstelleAuftrag(DateTime.Now, new AngebotNummerTyp(42), new KundeNummerTyp(42));
            Assert.IsNotNull(auftrag);
        }
    }
}
