using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transportdienstleister.Models;
using _0TypenKomponente.NummerTypen;

namespace Transportdienstleister.Persistenz
{
    public class LieferungVerwalter
    {
        private List<Lieferung> lieferungen = new List<Lieferung>();
        public Lieferung HoleLieferungUeberLieferNummer(int liefernummer)
        {
            return (from lieferung in lieferungen where lieferung.LieferungNr.nummer == (liefernummer) select lieferung).SingleOrDefault<Lieferung>();
        }

        public Lieferung ErstelleLieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister LieferDienstLeister)
        {
            var l = new Lieferung(LieferungNr, AuftragNr, Ausgangsdatum, LieferungErfolgt, Lieferdatum, LieferDienstLeister);
            lieferungen.Add(l);
            return l;
        }

        public void LöscheLieferung(LieferungNummerTyp LieferungNr) 
        {
            lieferungen.Remove(HoleLieferungUeberLieferNummer(LieferungNr.nummer));
        }


        public List<Lieferung> HoleAlleLieferungen() 
        {
            return lieferungen;
        }

    }
}