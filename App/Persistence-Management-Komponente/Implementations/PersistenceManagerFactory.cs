using System.Diagnostics.Contracts;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Persistence_Management_Komponente.Implementations.NHibernateImplementation;
using Persistence_Management_Komponente.Interfaces;
using System.Collections.Generic;
using System.IO;
using NHibernate;
using System;

namespace Persistence_Management_Komponente.Implementations
{
    /// <summary>
    /// Fabrik für verschiedene Persistenz-Implementierungen.
    /// </summary>
    public static class PersistenceManagerFactory
    {

        private static ISessionFactory factory = null;
        public static ISessionFactory Persistenz()
        {
            if (factory != null)
                return factory;

            FluentConfiguration a = Fluently.Configure().Database(SQLiteConfiguration.Standard.UsingFile("ai.db"));
            
            List<Assembly> allAssemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

 
            FluentConfiguration f = a.Mappings(m =>
                {
                    foreach (string dll in Directory.GetFiles(path, "*.dll"))
                    {
                        Console.WriteLine(dll);
                        if (dll.Contains("Produkt")) m.FluentMappings.AddFromAssembly(Assembly.LoadFile(dll));
                    }
                });

           factory = f.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();

            return factory;
        }
    }
}

/*

 * 
 * return Fluently.Configure().Database(SQLiteConfiguration.Standard.UsingFile("ai.db")).Mappings(m => m.FluentMappings
               .AddFromAssemblyOf<Aufgabe2.StudentMap>()
               .AddFromAssemblyOf<Aufgabe2.BuchMap>()
               .AddFromAssemblyOf<Aufgabe2.KurseMap>()
               .AddFromAssemblyOf<Aufgabe2.NotenkontoMap>())
               .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
 */