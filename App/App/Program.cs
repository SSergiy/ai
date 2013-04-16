using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Aufgabe2;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sessionFactory = Helper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // Listen zur Datenhaltung
                    IList<Student> studenten = new List<Student>();
                    IList<Notenkonto> notenkonten = new List<Notenkonto>();
                    IList<Kurs> kurse = new List<Kurs>();
                    IList<Buch> bücher = new List<Buch>();

                    // Erzeuge Studenten und Notenkonto
                    for (char character = 'A'; character < 'A' + 10; character++)
                    {
                        string name = Helper.CreateName(character, 10);

                        Notenkonto notenkonto = (new Notenkonto { Gesamtnote = (int)character });
                        notenkonten.Add(notenkonto);
                        studenten.Add(new Student { Name = name, Notenkonto = notenkonto });
                    }

                    // Erzeuge Kurse
                    for (char buchstabe = 'Z'; buchstabe > 'Z' - 10; buchstabe--)
                    {
                        string name = Helper.CreateName(buchstabe, 5);
                        kurse.Add(new Kurs { Titel = name });
                        bücher.Add(new Buch { Titel = name + "-Buch" });
                    }


                    Console.WriteLine("Daten erstellt. Speichere ...");
                    foreach (Notenkonto notenkonto in notenkonten)
                    {

                        session.SaveOrUpdate(notenkonto);
                    }

                    foreach (Student student in studenten)
                    {
                        session.SaveOrUpdate(student);
                    }

                    foreach (Kurs kurs in kurse)
                    {
                        session.SaveOrUpdate(kurs);
                    }

                    foreach (Buch buch in bücher)
                    {
                        session.SaveOrUpdate(buch);
                    }

                    Console.WriteLine("DB Fertig geschrieben nach ai.db");
                    Console.ReadKey();

                    transaction.Commit();

                }
            }
        }


    }
}
