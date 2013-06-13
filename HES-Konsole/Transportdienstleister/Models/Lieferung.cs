using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _0TypenKomponente.NummerTypen;

namespace Transportdienstleister.Models
{
    public class Lieferung
    {
        public LieferungNummerTyp LieferungNr { get; private set; }
        public TransportAuftragNummerTyp AuftragNr { get; private set; }
        public DateTime Ausgangsdatum { get; private set; }
        public bool LieferungErfolgt { get; private set; }
        public DateTime Lieferdatum { get; private set; }
        public TransportDienstleister Transportdienstleister { get; private set; }

        public Lieferung(LieferungNummerTyp LieferungNr,
            TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, Enum LieferDienstLeister)
        {
            this.LieferungNr = LieferungNr;
            this.AuftragNr = AuftragNr;
            this.Ausgangsdatum = Ausgangsdatum;
            this.LieferungErfolgt = LieferungErfolgt;
            this.Lieferdatum = Lieferdatum;
            this.Transportdienstleister = Transportdienstleister;
        }
    }
}