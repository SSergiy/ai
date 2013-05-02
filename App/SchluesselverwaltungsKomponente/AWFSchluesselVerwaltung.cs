using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;
using log4net;
using Persistence_Management_Komponente.Interfaces;

namespace Anwendungskern
{
    namespace SchluesselverwaltungsKomponente
    {
        class AWFSchluesselVerwaltung: IAWKSchluesselVerwalter
        {
            private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            private SchluesselVerwalter schlüsselVerwalter = null;

            public AWFSchluesselVerwaltung(IPersistenceManager persistenceManager)
            {
                this.schlüsselVerwalter = new SchluesselVerwalter(persistenceManager);
            }

            public void CreateOrResetSchlüssel(String schlüsselName, Int32 wert = 1)
            {
                try
                {
                    schlüsselVerwalter.CreateOrResetSchlüssel(schlüsselName, wert);
                }
                catch (Exception ex)
                {
                    //LogHelper.LogExceptionPassed(logger, ex);
                    throw ex;
                }
            }

            public Int32 NächsterSchlüssel(String schlüsselName)
            {
                try
                {
                    return schlüsselVerwalter.NächsterSchlüssel(schlüsselName);
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