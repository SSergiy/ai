using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.EnumTypen;
using _0TypenKomponente.TransportTypen;
namespace TransportdienstleisterVerwaltungKomponente
{
    public class TransportdienleisterVerwaltungFassade
    {
        private TransportdienstleisterWebAPIAdapter adapter = new TransportdienstleisterWebAPIAdapter();

        // Diese Signatur ist für den Remote Call
        public TLieferung HoleLieferungUeberLieferNummerRemote(string liefernummer)
        {
            return HoleLieferungUeberLieferNummer(new LieferungNummerTyp(int.Parse(liefernummer)));
        }

        public TLieferung ErstelleLieferungRemote(string LieferungNr, string AuftragNr, string Ausgangsdatum, string LieferungErfolgt, string Lieferdatum, string LieferDienstLeister)
        {
            var lieferungNr = new LieferungNummerTyp(int.Parse(LieferungNr));
            var aufftragNr = new TransportAuftragNummerTyp(int.Parse(AuftragNr));
            var ausgangsdatum = DateTime.FromBinary(long.Parse(Ausgangsdatum));
            var lieferungErfolgt = bool.Parse(LieferungErfolgt);
            var lieferdatum = DateTime.FromBinary(long.Parse(Lieferdatum));
            var lieferDienstLeister = TransportDienstleister.DHL;
            return ErstelleLieferung(lieferungNr,
            aufftragNr, ausgangsdatum, lieferungErfolgt, lieferdatum, lieferDienstLeister);
        }

        public TLieferung HoleLieferungUeberLieferNummer(LieferungNummerTyp liefernummer)
        {
            return adapter.HoleLieferungUeberLieferNummer(liefernummer);
        }

        public TLieferung ErstelleLieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister LieferDienstLeister)
        {
            return adapter.ErstelleLieferung(LieferungNr,
             AuftragNr, Ausgangsdatum, LieferungErfolgt, Lieferdatum, LieferDienstLeister);
        }

        public void LöscheLieferung(LieferungNummerTyp LieferungNr)
        {
            adapter.Lösche(LieferungNr.nummer);
        }


        public IList<TLieferung> HoleAlleLieferungen()
        {
            return adapter.HoleAlleLieferungen();
        }
    }
}
