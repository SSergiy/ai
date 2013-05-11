using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Persistenzmanager;
using KomponenteA;
using KomponenteB;

namespace Persistenz
{
    class Program
    {
        private static readonly ISessionFactory persistenz =  PersistenceManagerFactory.Persistenz();

        static void Main(string[] args)
        {
            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var a = new ClassA();
                    a.name = "Peter";
                    session.SaveOrUpdate(a);
                    var b = new ClassB();
                    b.name = "Hans";
                    session.SaveOrUpdate(b);
                    transaction.Commit();
                }
            }

            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var a = session.Get<ClassA>(1);
                }
            }

        }
    }
}
