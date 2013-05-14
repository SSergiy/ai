using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Reflection;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace Persistenzmanager
{
    public static class Factory
    {
        private static readonly IList<string> erlaubtedll = new List<string>();
        private static ISessionFactory factory = null;
        public static ISessionFactory Session()
        {
            if (factory != null)
                return factory;

            // Erlaubte DLL
            erlaubtedll.Add("KundeVerwaltungKomponente.dll");
            erlaubtedll.Add("ProduktVerwaltungKomponente.dll");
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
                                //System.Console.WriteLine(dll);
                                //System.Console.ReadKey();
                                m.FluentMappings.AddFromAssembly(Assembly.LoadFile(dll));
                            }
                        }
                    }
                }).ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
            return factory;
        }
    }
}
