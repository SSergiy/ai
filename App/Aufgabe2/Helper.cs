using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace Aufgabe2
{
    public class Helper
    {
        public static string CreateName(char character, int size)
        {
            string name = "";
            for (int zeichenlaenge = 0; zeichenlaenge < size; zeichenlaenge++)
            {
                name += character;
            }
            return name;
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure().Database(SQLiteConfiguration.Standard.UsingFile("ai.db")).Mappings(m => m.FluentMappings
               .AddFromAssemblyOf<Aufgabe2.StudentMap>()
               .AddFromAssemblyOf<Aufgabe2.BuchMap>()
               .AddFromAssemblyOf<Aufgabe2.KurseMap>()
               .AddFromAssemblyOf<Aufgabe2.NotenkontoMap>())
               .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
        }
    }
}
