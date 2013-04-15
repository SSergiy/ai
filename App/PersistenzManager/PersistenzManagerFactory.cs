using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using System.Diagnostics.Contracts;


namespace PersistenzManager
{
    public class PersistenzManagerFactory
    {
        private static ISessionFactory peristenz;

        public PersistenzManagerFactory() 
        {
             Configuration configuration = new Configuration();
                FluentConfiguration fluentConfiguration = Fluently.Configure(configuration);
                fluentConfiguration = fluentConfiguration.Database(
                            (SQLiteConfiguration.Standard.UsingFile("ai.db"))
                        ).Mappings(m =>
     m.FluentMappings
       .AddFromAssemblyOf<Aufgabe2.StudentMap>()
       .AddFromAssemblyOf<Aufgabe2.BuchMap>()
       .AddFromAssemblyOf<Aufgabe2.KurseMap>()
       .AddFromAssemblyOf<Aufgabe2.NotenkontoMap>()
       )
   .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
        peristenz = configuration.BuildSessionFactory();
        }

        public static ISessionFactory SessionFactory()
        {
            return peristenz; 
        }
    }
}

