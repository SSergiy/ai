using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.EnumTypen;

namespace TransportdienstleisterVerwaltungKomponente
{
    public class Lieferung : ILieferung
    {
        public Lieferung(LieferungNummerTyp LieferungNr, TransportAuftragNummerTyp AuftragNr, DateTime Ausgangsdatum, bool LieferungErfolgt, DateTime Lieferdatum, TransportDienstleister Transportdienstleister) 
        {
            this.LieferungNr = LieferungNr;
            this.AuftragNr = AuftragNr;
            this.Ausgangsdatum = Ausgangsdatum;
            this.LieferungErfolgt = LieferungErfolgt;
            this.Lieferdatum = Lieferdatum;
            this.Transportdienstleister = Transportdienstleister;
        }

        public _0TypenKomponente.NummerTypen.LieferungNummerTyp LieferungNr
        {
            get { return this.LieferungNr; }
            private set { this.LieferungNr = LieferungNr; }
        }

        public _0TypenKomponente.NummerTypen.TransportAuftragNummerTyp AuftragNr
        {
            get { return this.AuftragNr; }
            private set { this.AuftragNr = AuftragNr; }
        }

        public DateTime Ausgangsdatum
        {
            get { return this.Ausgangsdatum; }
            private set { this.Ausgangsdatum = Ausgangsdatum; }
        }

        public bool LieferungErfolgt
        {
            get { return this.LieferungErfolgt; }
            private set { this.LieferungErfolgt = LieferungErfolgt; }
        }

        public DateTime Lieferdatum
        {
            get { return this.Lieferdatum; }
            private set { this.Lieferdatum = Lieferdatum; }
        }

        public _0TypenKomponente.EnumTypen.TransportDienstleister Transportdienstleister
        {
            get { return this.Transportdienstleister; }
            private set { this.Transportdienstleister = Transportdienstleister; }
        }
    }
}
