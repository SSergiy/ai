using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace Persistenzmanager
{
    public static class Factory
    {
        private static readonly IList<string> erlaubte_dll = new List<string>();
        private static ISessionFactory factory = null;
        public static ISessionFactory Session() 
        {
            if (factory != null) 
            {
                return factory;
            }

            // Erlaubte DLL für Fluent NHibernate. 
            // Der Rest wird nicht nach Mappings durchsucht.
            erlaubte_dll.Add("AuftragsVerwaltungsKomponente");
            erlaubte_dll.Add("BuchhaltungsVerwaltungsKomponente");
            erlaubte_dll.Add("KundenVerwaltungsKomponente");
            erlaubte_dll.Add("ProduktVerwaltungsKomponente");
            erlaubte_dll.Add("TransportauftragsVerwaltungsKomponente");
            List<Assembly> assemblies = new List<Assembly>();
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            factory = Fluently.Configure()
               .Database(SQLiteConfiguration
               .Standard
               .UsingFile("ai.db"))
               .Mappings(m =>
               {

                   foreach (string dll in System.IO.Directory.GetFiles(path, "*.dll"))
                   {
                       if (System.IO.File.Exists(dll))
                       {
                           string filename = System.IO.Path.GetFileName(dll);
                           if (erlaubte_dll.Contains(filename))
                           {
                               m.FluentMappings.AddFromAssembly(Assembly.LoadFile(dll));
                           }
                       }
                   }
               }).ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
            return factory;

            
        }
    }
}
