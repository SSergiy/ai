﻿using System;
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
        // private static readonly ISessionFactory persistenz = Persistenzmanager.Factory.Session();

        [TestMethod]
        public void ErstelleAuftrag()
         {
            ISessionFactory persistenz = Persistenzmanager.Factory.Session();
            var auftragsverwaltung = new AuftragsVerwaltungFassade();
            var auftrag = auftragsverwaltung.ErstelleAuftrag(DateTime.Now, new AngebotNummerTyp(42), new KundeNummerTyp(42));
            Assert.IsNotNull(auftrag);
        }
    }
}
