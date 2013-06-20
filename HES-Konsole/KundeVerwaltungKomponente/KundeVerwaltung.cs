using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente;
using _0TypenKomponente.NummerTypen;
using NHibernate.Linq;

namespace KundeVerwaltungKomponente
{
    internal class KundeVerwaltung
    {
        private static ISessionFactory persistenz = Persistenzmanager.Factory.Session();

        internal IKunde ErstelleKunde(String name, AdresseTyp adresse)
        {
            Kunde k = null;

            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    k = new Kunde(name, adresse);
                    session.SaveOrUpdate(k);
                    k.nummer = new KundeNummerTyp(k.id);
                    session.SaveOrUpdate(k);
                    transaction.Commit();
                }
            }

            return k;
        }


        internal IKunde HoleKunde(KundeNummerTyp kundennummerntyp)
        {
            Kunde k = null;

            using (var session = persistenz.OpenSession())
            {
                var temp = session.Query<Kunde>().ToList();
                foreach (Kunde t in temp)
                {
                    if (t.nummer.nummer == kundennummerntyp.nummer)
                        k = t;
                }
            }

            return k;
        }
    }
}
