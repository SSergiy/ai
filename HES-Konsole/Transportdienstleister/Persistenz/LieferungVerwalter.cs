using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transportdienstleister.Models;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.EnumTypen;

namespace Transportdienstleister.Persistenz
{
    public class LieferungVerwalter
    {
        private List<ILieferung> lieferungen = new List<ILieferung>();

        public LieferungVerwalter()
        {
            // Erstelle einen Test Daten Satz
            lieferungen.Add(new TransportdienstleisterLieferung(new LieferungNummerTyp(1), new TransportAuftragNummerTyp(1), DateTime.Now, true, DateTime.Now, TransportDienstleister.DHL));
        }


        public ILieferung HoleLieferungUeberLieferNummer(int liefernummer)
        {
            return (from lieferung in lieferungen where lieferung.LieferungNr.nummer == (liefernummer) select lieferung).SingleOrDefault<ILieferung>();
        }

        public ILieferung ErstelleLieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister LieferDienstLeister)
        {
            var l = new TransportdienstleisterLieferung(LieferungNr, AuftragNr, Ausgangsdatum, LieferungErfolgt, Lieferdatum, LieferDienstLeister);
            lieferungen.Add(l);
            return l;
        }

        public void LöscheLieferung(LieferungNummerTyp LieferungNr)
        {
            lieferungen.Remove(HoleLieferungUeberLieferNummer(LieferungNr.nummer));
        }


        public IList<ILieferung> HoleAlleLieferungen()
        {
            return lieferungen;
        }

    }
}