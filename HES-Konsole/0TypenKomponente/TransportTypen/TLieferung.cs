using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.EnumTypen;

namespace _0TypenKomponente.TransportTypen
{
    [Serializable]
    public class TLieferung
    {
        public TLieferung() { }
        public TLieferung(LieferungNummerTyp LieferungNr, TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister Transportdienstleister) 
        {
            this.LieferungNr = LieferungNr;
            this.AuftragNr = AuftragNr;
            this.Ausgangsdatum = Ausgangsdatum;
            this.LieferungErfolgt = LieferungErfolgt;
            this.Lieferdatum = Lieferdatum;
            this.Transportdienstleister = Transportdienstleister;
        }

        public LieferungNummerTyp LieferungNr
        {
            get;
            set;
        }

        public TransportAuftragNummerTyp AuftragNr
        {
             get;
             set;
        }

        public DateTime Ausgangsdatum
        {
             get;
             set;
        }

        public bool LieferungErfolgt
        {
             get;
             set;
        }

        public DateTime Lieferdatum
        {
             get;
             set;
        }

        public TransportDienstleister Transportdienstleister
        {
             get;
             set;
        }

        public override string ToString()
        {
            return "Lieferung: " + LieferungNr + " Auftrag: " + AuftragNr + "Ausgang: " + Ausgangsdatum + "Erfolg? " + LieferungErfolgt + " Lieferdatum: " + Lieferdatum + " Dienstleister: " + Transportdienstleister;
        }
    }
}
