using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.EnumTypen;
using _0TypenKomponente.TransportTypen;

namespace Transportdienstleister.Persistenz
{
    public class LieferungVerwalter
    {
        private List<TLieferung> lieferungen = new List<TLieferung>();

        public LieferungVerwalter()
        {
            // Erstelle einen Test Daten Satz
            lieferungen.Add(new TLieferung(new LieferungNummerTyp(1), new TransportAuftragNummerTyp(1), DateTime.Now, true, DateTime.Now, TransportDienstleister.DHL));
        }


        public TLieferung HoleLieferungUeberLieferNummer(int liefernummer)
        {
            return (from lieferung in lieferungen where lieferung.LieferungNr.nummer == (liefernummer) select lieferung).SingleOrDefault<TLieferung>();
        }

        public TLieferung ErstelleLieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister LieferDienstLeister)
        {
            var l = new TLieferung(LieferungNr, AuftragNr, Ausgangsdatum, LieferungErfolgt, Lieferdatum, LieferDienstLeister);
            lieferungen.Add(l);
            return l;
        }

        public void LöscheLieferung(LieferungNummerTyp LieferungNr)
        {
            lieferungen.Remove(HoleLieferungUeberLieferNummer(LieferungNr.nummer));
        }


        public IList<TLieferung> HoleAlleLieferungen()
        {
            return lieferungen;
        }

    }
}