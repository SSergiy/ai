using System.Diagnostics.Contracts;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Persistence_Management_Komponente.Implementations.NHibernateImplementation;
using Persistence_Management_Komponente.Interfaces;

namespace Persistence_Management_Komponente.Implementations
{
    /// <summary>
    /// Fabrik für verschiedene Persistenz-Implementierungen.
    /// </summary>
    public class PersistenceManagerFactory
    {
        /// <summary>
        /// Zur Verfügung stehende Arten von Persistenz-Implementierungen.
        /// </summary>
        public enum PersistenceManagerType { MSSQL2008, SQLite };

        /// <summary>
        /// Fabrikmethode für verschiedene Persistenz-Implementierungen.
        /// </summary>
        /// <param name="type">Art der zu erzeugenden Persistenz-Implementierung.</param>
        /// <param name="mappingAssemblies">Assemblies, die Mapping-Informationen für Entitäten enthalten.</param>
        /// <param name="persistenceManager">Eine Referenz auf den erzeugten Persistenzmanager</param>
        /// <param name="conversationFactory">Eine Referenz auf die erzeugte Konversationsfabrik</param>
        /// <pre>fluentMappings != null</pre>
        /// <pre>hbmMappings != null</pre>
        /// <post>persistenceManager != null</post>
        /// <post>conversationFactory != null</post>
        public static void CreatePersistence(PersistenceManagerType type, Assembly[] fluentMappings, Assembly[] hbmMappings, out IPersistenceManager persistenceManager, out IConversationFactory conversationFactory)
        {
            Contract.Requires(fluentMappings != null);
            Contract.Requires(hbmMappings != null);
            Configuration configuration = new Configuration();
            FluentConfiguration fluentConfiguration = Fluently.Configure(configuration);

            switch(type)
            {
                case PersistenceManagerType.SQLite:
                    fluentConfiguration = fluentConfiguration.Database(
                        SQLiteConfiguration.Standard.ConnectionString("Data Source=SQLiteTempData.db")
                    );
                    break;
            }
            foreach (Assembly mappingAssembly in fluentMappings)
            {
                fluentConfiguration = fluentConfiguration.Mappings(m => m.FluentMappings.AddFromAssembly(mappingAssembly));
            }
            foreach (Assembly mappingAssembly in hbmMappings)
            {
                fluentConfiguration = fluentConfiguration.Mappings(m => m.HbmMappings.AddFromAssembly(mappingAssembly));
            }
            configuration = fluentConfiguration
                .ExposeConfiguration(cfg =>
                    {
                        new SchemaExport(cfg)
                            .Create(false, true);
                    })
                .BuildConfiguration();

            persistenceManager = new NHibernatePersistenceManager(configuration);
            conversationFactory = persistenceManager as IConversationFactory;
            Contract.Assert(persistenceManager != null, "PersistenceManager should have been set.");
            Contract.Assert(conversationFactory != null, "ConversationFactory should have been set.");
        }
    }
}
