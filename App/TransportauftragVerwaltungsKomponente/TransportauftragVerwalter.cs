using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transportdienstleiter_Komponente;
using Anwendungskern.NullTypenKomponente;
using NHibernate;

namespace Anwendungskern
{
    namespace TransportauftragVerwaltungsKomponente
    {
        class TransportauftragVerwalter
        {
            private static ISessionFactory persistenz = Persistenzmanager.Factory.Session();

            internal TransportauftragNummerTyp ErstelleTransportauftrag(DateTime ausgangsdatum, DateTime lieferdatum, TransportdienstleisterTyp transportdienstleister)
            {
                return new TransportauftragNummerTyp(TransportdienstleisterAdapter.ErstelleTransportauftrag(ausgangsdatum, lieferdatum, transportdienstleister));
            }

            internal ILieferung ErstelleLieferung(ITransportauftrag transportauftrag, IAuftrag auftrag)
            {
                Lieferung il = null;
                using (var session = persistenz.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        il = new Lieferung();
                        il.Auftrag = auftrag;
                        il.Transportauftrag = transportauftrag;
                        session.SaveOrUpdate(il);
                        transaction.Commit();
                    }
                }

                if (il == null) throw new NullReferenceException();
                return il;
            }
        }
    }
}