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

            factory = Fluently.Configure()
                .Database(SQLiteConfiguration
                .Standard
                .UsingFile("ai.db"))
                .Mappings(m =>
                {
                    List<Assembly> allAssemblies = new List<Assembly>();
                    string path = Assembly.GetExecutingAssembly().Location;
                    foreach (string dll in Directory.GetFiles(path, "*.dll"))
                    {
                        m.FluentMappings.AddFromAssembly(Assembly.LoadFile(dll));
                    }
                }).ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
            return factory;
        }
    }
}
