using System.Diagnostics.Contracts;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Collections.Generic;
using System.IO;
using NHibernate;

namespace Persistenzmanager
{
    /// <summary>
    /// Fabrik für verschiedene Persistenz-Implementierungen.
    /// </summary>
    public static class PersistenceManagerFactory
    {
        private static readonly IList<string> erlaubtedll = new List<string>();
        private static ISessionFactory factory = null;
        public static ISessionFactory Persistenz()
        {
            if (factory != null)
                return factory;

            // Erlaubte DLL
            erlaubtedll.Add("KomponenteA.dll");
            erlaubtedll.Add("KomponenteB.dll");
            List<Assembly> allAssemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            factory = Fluently.Configure()
                .Database(SQLiteConfiguration
                .Standard
                .UsingFile("ai.db"))
                .Mappings(m =>
                {

                    foreach (string dll in Directory.GetFiles(path, "*.dll"))
                    {
                        if (File.Exists(dll))
                        {
                            string filename = Path.GetFileName(dll);
                            if (erlaubtedll.Contains(filename))
                            {
                                System.Console.WriteLine(dll);
                                System.Console.ReadKey();
                                m.FluentMappings.AddFromAssembly(Assembly.LoadFile(dll));
                            }
                        }
                    }
                }).ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
            return factory;
        }
    }
}
