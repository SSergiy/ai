using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using NHibernate.Linq;

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
                    ir.nummer = new RechnungNummerTyp(ir.Id);
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



        internal IRechnung HoleRechnung(RechnungNummerTyp rechnungnummertyp)
        {
            Rechnung r = null;

            using (var session = persistenz.OpenSession())
            {
                var temp = session.Query<Rechnung>().ToList();
                foreach (Rechnung t in temp)
                {
                    if (t.nummer != null && t.nummer.nummer == rechnungnummertyp.nummer)
                        r = t;
                }
            }

            return r;
        }

        internal void VerbucheZahlung(RechnungNummerTyp rechnungnummertyp, double betrag)
        {
            IRechnung r = HoleRechnung(rechnungnummertyp);

            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Zahlungseingang z = new Zahlungseingang();
                    z.Betrag = betrag;
                    z.Eingangsdatum = DateTime.Now;
                    //session.SaveOrUpdate(z);
                    
                    r.NeuerZahlungseingang(z);
                    session.SaveOrUpdate(r);
                    transaction.Commit();
                }
            }
        }
    }
}
