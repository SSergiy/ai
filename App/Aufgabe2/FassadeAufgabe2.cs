using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Aufgabe2;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;


namespace Aufgabe2
{
    // Diese Fassade implementiert die Schnittstellen für die Aufgabe 2
    public class FassadeAufgabe2 : IAufgabe2
    {
        private static ISessionFactory persistenz;

        public FassadeAufgabe2()
        {
            persistenz = Helper.CreateSessionFactory();
        }



        public Buch ErstelleBuch(string Titel)
        {
            using (var session = persistenz.OpenSession())
            {
                Buch buch = new Buch();
                buch.Titel = Titel;

                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(buch);
                    transaction.Commit();
                    return buch;
                }
            }
        }

        public Buch holeBuch(int id)
        {
            return persistenz.OpenSession().Get<Buch>(id);
        }

        public Buch ÄndereBuch(int id, string Titel)
        {

            Buch buch;
            using (var session = persistenz.OpenSession())
            {
                buch = session.Get<Buch>(id);
                buch.Titel = Titel;

                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(buch);
                    transaction.Commit();

                }
            }

            return buch;
        }

        public void LöscheBuch(int id)
        {
            using (var session = persistenz.OpenSession())
            {
                Buch buch = session.Get<Buch>(id);

                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(buch);
                    transaction.Commit();
                }
            }
        }

        public Kurs holeKurs(int id)
        {
            return persistenz.OpenSession().Get<Kurs>(id);
        }

        public Kurs ErstelleKurs(string titel, IList<Buch> bücher)
        {
            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    Kurs kurs = new Kurs();
                    kurs.Titel = titel;
                    kurs.Buch = bücher;
                    foreach (Buch b in bücher)
                    {
                        session.SaveOrUpdate(b);
                    }

                    session.SaveOrUpdate(kurs);
                    transaction.Commit();
                    return kurs;
                }
            }
        }

        public Kurs ÄndereKurs(int id, string titel, IList<Buch> bücher)
        {
            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Kurs kurs = session.Get<Kurs>(id);
                    kurs.Titel = titel;
                    kurs.Buch = bücher; 
                    session.SaveOrUpdate(kurs);
                    transaction.Commit();
                    return kurs;
                }
            }
        }

        public void LöscheKurs(int id)
        {
            using (var session = persistenz.OpenSession())
            {
                Kurs kurs = session.Get<Kurs>(id);
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(kurs);
                    transaction.Commit();
                }
            }
        }

        public Notenkonto holeNotenkonto(int id)
        {
            return persistenz.OpenSession().Get<Notenkonto>(id);
        }

        public Notenkonto ErstelleNotenkonto(double gesamtnote)
        {
            using (var session = persistenz.OpenSession())
            {
                Notenkonto notenkonto = new Notenkonto();
                notenkonto.Gesamtnote = gesamtnote;
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(notenkonto);
                    transaction.Commit();
                    return notenkonto;
                }
            }
        }

        public Notenkonto ÄndereNotenkonto(int id, double gesamtnote)
        {
            using (var session = persistenz.OpenSession())
            {
                Notenkonto notenkonto = session.Get<Notenkonto>(id);
                notenkonto.Gesamtnote = gesamtnote;
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(notenkonto);
                    transaction.Commit();
                    return notenkonto;
                }
            }
        }

        public void LöscheNotenkonto(int id)
        {
            using (var session = persistenz.OpenSession())
            {
                Notenkonto notenkonto = session.Get<Notenkonto>(id);
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(notenkonto);
                    transaction.Commit();
                }
            }
        }

        public Student holeStudent(int id)
        {
            return persistenz.OpenSession().Get<Student>(id);
        }

        public Student ErstelleStudent(string name, IList<Kurs> kurse, Notenkonto notenkonto)
        {
            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Student student = new Student();
                    Notenkonto nk = session.Get<Notenkonto>(notenkonto.Id);

                    if (nk == null)
                        throw new Exception();
                    else
                    {
                        student.Notenkonto = nk;
                    }

                    foreach (Kurs k in kurse)
                    {
                        var temp = session.Get<Kurs>(k.Id);
                        if (temp == null)
                            throw new Exception();
                    }
                    student.Kurse = kurse;
                    student.Name = name;
                    session.SaveOrUpdate(student);
                    transaction.Commit();
                    return student;
                }
            }
        }

        public Student ÄndereStudent(int id, string name, IList<Kurs> kurse, Notenkonto notenkonto)
        {
            Student student;
            using (var session = persistenz.OpenSession())
            {
                student = session.Get<Student>(id);
                student.Name = name;
                student.Kurse = kurse;
                student.Notenkonto = notenkonto;
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(student);
                    transaction.Commit();
                }
            }
            return student;
        }

        public void LöscheStudent(int id)
        {
            Student student;
            using (var session = persistenz.OpenSession())
            {
                student = session.Get<Student>(id);
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(student);
                    transaction.Commit();
                }
            }
        }
    }
}
