using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.EnumTypen;
namespace TransportdienstleisterVerwaltungKomponente
{
    public class TransportdienleisterVerwaltungFassade
    {

        private TransportdienstleisterWebAPIAdapter adapter = new TransportdienstleisterWebAPIAdapter();

        // Diese Signatur ist für den Remote Call
        public ILieferung HoleLieferungUeberLieferNummerRemote(string liefernummer)
        {
            return HoleLieferungUeberLieferNummer(new LieferungNummerTyp(int.Parse(liefernummer)));
        }

        public ILieferung HoleLieferungUeberLieferNummer(LieferungNummerTyp liefernummer)
        {
            return adapter.HoleLieferungUeberLieferNummer(liefernummer);
        }

        public ILieferung ErstelleLieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister LieferDienstLeister)
        {
            return adapter.ErstelleLieferung(LieferungNr,
             AuftragNr, Ausgangsdatum, LieferungErfolgt, Lieferdatum, LieferDienstLeister);
        }

        public void LöscheLieferung(LieferungNummerTyp LieferungNr)
        {
            adapter.Lösche(LieferungNr.nummer);
        }


        public IList<ILieferung> HoleAlleLieferungen()
        {
            return adapter.HoleAlleLieferungen();
        }
    }
}
