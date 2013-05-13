using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;
using NHibernate;

namespace Anwendungskern
{
    namespace BuchhaltungsVerwaltungsKomponente
    {
        class BuchhaltungsVerwalter
        {
            private static ISessionFactory persistenz = Persistenzmanager.Implementations.PersistenceManagerFactory.Persistenz();

            internal IRechnung ErstelleRechnung(IAuftrag auftrag)
            {
                Rechnung ir = null;
                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        ir = new Rechnung();
                        ir.RechnungsDatum = DateTime.Now;
                        session.SaveOrUpdate(ir);
                        transaction.Commit();
                    }
                }

                if (ir == null) throw new NullReferenceException();
                return ir;
            }

            internal void VerschickeRechnung(IRechnung rechnung)
            {
                // ok, verschickt
            }
        }
    }
}