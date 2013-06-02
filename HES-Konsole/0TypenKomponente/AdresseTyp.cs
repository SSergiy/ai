using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente
{
    public class AdresseTyp
    {
        public virtual String strasse { get; set; }
        public virtual String hausnummer { get; set; }
        public virtual String postleitzahl { get; set; }
        public virtual String ort { get; set; }
        public virtual String land { get; set; }

        public AdresseTyp() { }

        public AdresseTyp(String strasse, String hausnummer, String postleitzahl,
            String ort, String land)
        {
            this.strasse = strasse;
            this.hausnummer = hausnummer;
            this.postleitzahl = postleitzahl;
            this.ort = ort;
            this.land = land;
        }

        public override string ToString()
        {
            return " Straße: " + strasse + " Hausnummer: " + hausnummer + " Postleitzahl " + postleitzahl + " Ort: " + ort + " Land: " + land; 
        }
    }
}
