using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adapter;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.EnumTypen;
using _0TypenKomponente.TransportTypen;
namespace TransportdienstleisterVerwaltungKomponente
{
    public class TransportdienstleisterWebAPIAdapter : WebAPIBasisKlasse
    {
        public override string controller
        {
            get { return "lieferung"; }
        }
        public override string port
        {
            get { return "51856"; }
        }

        public TLieferung HoleLieferungUeberLieferNummer(LieferungNummerTyp liefernummer)
        {
            var respond = base.Hole(liefernummer.nummer);
            return base.Descerialize<TLieferung>(respond);
            
        }

        public TLieferung ErstelleLieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister LieferDienstLeister)
        {
            List<string> parameter_liste = new List<string>();
            parameter_liste.Add(LieferungNr.nummer.ToString());
            parameter_liste.Add(AuftragNr.nummer.ToString());
            parameter_liste.Add(Ausgangsdatum.ToBinary().ToString());
            parameter_liste.Add(LieferungErfolgt.ToString());
            parameter_liste.Add(Lieferdatum.ToBinary().ToString());
            parameter_liste.Add(LieferDienstLeister.ToString());
            var respond = base.Erstelle(parameter_liste);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TLieferung>(respond); 
        }

        public void LöscheLieferung(LieferungNummerTyp LieferungNr)
        {
            base.Lösche(LieferungNr.nummer);
        }


        public IList<TLieferung> HoleAlleLieferungen()
        {
            var respond = base.HoleAlle();
            TLieferung[] elemente = Newtonsoft.Json.JsonConvert.DeserializeObject<TLieferung[]>(respond);
            return elemente.ToList<TLieferung>();
        }


    }
}
