using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente;
using _0TypenKomponente.NummerTypen;

namespace KundeVerwaltungKomponente
{
    internal class KundeVerwaltung
    {
        private static ISessionFactory persistenz = Persistenzmanager.Factory.Session();

        internal IKunde ErstelleKunde(KundeNummerTyp nummer, String name, AdresseTyp adresse)
        {
            Kunde k = new Kunde(nummer, name, adresse);

            using (var session = persistenz.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
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
                k = session.Get<Kunde>(kundennummerntyp.nummer);
            }

            if (k == null) throw new NullReferenceException();

            return k;
        }
    }
}
