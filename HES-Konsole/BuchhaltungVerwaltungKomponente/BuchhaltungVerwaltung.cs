using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using _0TypenKomponente.TransportInterfaces;

namespace BuchhaltungVerwaltungKomponente
{
    class BuchhaltungVerwaltung
    {
        private static ISessionFactory persistenz = Persistenzmanager.Factory.Session();

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
