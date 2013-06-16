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
            return adapter.Hole<ILieferung>(liefernummer.nummer);
        }

        public ILieferung ErstelleLieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister LieferDienstLeister)
        {
            List<string> parameter_liste = new List<string>();
            parameter_liste.Add(LieferungNr.nummer.ToString());
            parameter_liste.Add(AuftragNr.nummer.ToString());
            parameter_liste.Add(Ausgangsdatum.ToBinary().ToString());
            parameter_liste.Add(LieferungErfolgt.ToString());
            parameter_liste.Add(Lieferdatum.ToBinary().ToString());
            parameter_liste.Add(LieferDienstLeister.ToString());
            return adapter.Erstelle<ILieferung>(parameter_liste);
        }

        public void LöscheLieferung(LieferungNummerTyp LieferungNr)
        {
            adapter.Lösche<ILieferung>(LieferungNr.nummer);
        }


        public IList<ILieferung> HoleAlleLieferungen()
        {
            return adapter.HoleAlle<ILieferung>();
        }
    }
}
