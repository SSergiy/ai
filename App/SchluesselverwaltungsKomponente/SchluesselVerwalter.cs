using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Anwendungskern.NullTypenKomponente;
using Persistence_Management_Komponente.Interfaces;

namespace Anwendungskern
{
    namespace SchluesselverwaltungsKomponente
    {
        class SchluesselVerwalter : IAWKSchluesselVerwalter
        {
            private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            private IPersistenceManager persistenceManager = null;

            public SchluesselVerwalter(IPersistenceManager persistenceManager)
            {
                this.persistenceManager = persistenceManager;
            }

            public void CreateOrResetSchlüssel(String schlüsselName, Int32 wert = 1)
            {
                try
                {
                    SchluesselZaehler z = GetSchlüsselZähler(schlüsselName);
                    if (z != null)
                    {
                        z.wert = wert;
                        persistenceManager.Save<SchluesselZaehler>(z);
                    }
                    else
                    {
                        z = new SchluesselZaehler(schlüsselName, wert);
                        persistenceManager.Save<SchluesselZaehler>(z);
                    }
                }
                catch (Exception ex)
                {
                    //LogHelper.LogExceptionPassed(logger, ex);
                    throw new TechnicalException(ex);
                }
            }

            public Int32 NächsterSchlüssel(String schlüsselName)
            {
                try
                {
                    SchluesselZaehler z = GetSchlüsselZähler(schlüsselName);
                    if (z != null)
                    {
                        Int32 wert = z.wert;
                        z.wert++;
                        persistenceManager.Save<SchluesselZaehler>(z);
                        return wert;
                    }
                    else
                    {
                        throw new UnbekannterSchlüsselException(schlüsselName);
                    }
                }
                catch (Exception ex)
                {
                    //LogHelper.LogExceptionPassed(logger, ex);
                    throw new TechnicalException(ex);
                }
            }

            private SchluesselZaehler GetSchlüsselZähler(String schlüsselName)
            {
                try
                {
                    return (from schlüssel in persistenceManager.LinqQuery<SchluesselZaehler>()
                            where schlüssel.name == schlüsselName
                            select schlüssel).SingleOrDefault<SchluesselZaehler>();
                }
                catch (Exception ex)
                {
                    //LogHelper.LogExceptionPassed(logger, ex);
                    throw new TechnicalException(ex);
                }
            }
        }
    }
}

