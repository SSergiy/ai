using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using Aufgabe2;

namespace TestProjekt
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für UnitTestAufgabe2
    /// </summary>
    [TestClass]
    public class UnitTestAufgabe2
    {
        FassadeAufgabe2 f;

        public UnitTestAufgabe2()
        {
            f = new FassadeAufgabe2();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Textkontext mit Informationen über
        ///den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        //
        // Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
        //
        // Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen. 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestBuch()
        {
            Buch v1 = f.ErstelleBuch("b");
            int id1 = v1.Id;
            f.ÄndereBuch(id1, "a");
            v1 = f.holeBuch(v1.Id);
            Buch v2 = f.holeBuch(id1);
            Assert.AreEqual("a", v2.Titel, "Titel wurde nicht geändert");
            f.LöscheBuch(id1);
            Assert.AreEqual(null, f.holeBuch(id1), "Buch wurde nicht gelöscht!");
        }

        [TestMethod]
        public void TestNotenkonto()
        {
            Notenkonto v1 = f.ErstelleNotenkonto(2);
            int id1 = v1.Id;
            f.ÄndereNotenkonto(id1, 1);
            v1 = f.holeNotenkonto(v1.Id);
            Notenkonto v2 = f.holeNotenkonto(id1);
            Assert.AreEqual(1, v2.Gesamtnote, "Gesamtnote wurde nicht geändert");
            f.LöscheNotenkonto(id1);
            Assert.AreEqual(null, f.holeNotenkonto(id1), "Student wurde nicht gelöscht!");
        }

        [TestMethod]
        public void TestKurs()
        {
            Buch b1 = f.ErstelleBuch("b");

            IList<Buch> l = new List<Buch>();
            l.Add(b1);
            Kurs v1 = f.ErstelleKurs("b", l);
            int id1 = v1.Id;
            
            Kurs v2 = f.holeKurs(id1);

            Assert.AreEqual(b1.Titel, v2.Buch[0].Titel, "Buch wurde nicht hinzugefügt");

            f.ÄndereKurs(id1, "a", l);
            v1 = f.holeKurs(v1.Id);
            v2 = f.holeKurs(id1);
            Assert.AreEqual("a", v2.Titel, "Titel wurde nicht geändert");

            f.LöscheKurs(id1);
            Assert.AreEqual(null, f.holeKurs(id1), "Kurs wurde nicht gelöscht!");
        }

        [TestMethod]
        public void TestStudent()
        {
            IList<Buch> bs = new List<Buch>();
            IList<Kurs> ks = new List<Kurs>();
            Kurs k = f.ErstelleKurs("S1", bs);
            ks.Add(k);
            Notenkonto n = f.ErstelleNotenkonto(2);
            Student v1 = f.ErstelleStudent("b", ks, n);
            int id1 = v1.Id;
            f.ÄndereStudent(id1, "a", ks, n);
            v1 = f.holeStudent(v1.Id);
            Student v2 = f.holeStudent(id1);
            Assert.AreEqual("a", v2.Name, "Name wurde nicht geändert");
            Assert.AreEqual(k.Id, v2.Kurse[0].Id, "Kurse nicht gleich");
            f.LöscheStudent(id1);
            Assert.AreEqual(null, f.holeStudent(id1), "Student wurde nicht gelöscht!");
        }
    }
}
