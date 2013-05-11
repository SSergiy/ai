using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;


namespace Anwendungskern
{
    namespace KundenVerwaltungsKomponente
    {
        public class KundenVerwaltungFassade : IAWKKundenVerwaltung
        {
            public Kunde HoleKunde(KundeNummerTyp kundennummerntyp) 
            {
                return new Kunde();
            }

            // Fachliche Typen  benutzen !
            //public Kunde ErstelleKunde(string name, string strasse, string hausnummer, string postleitzahl, string ort, string land)
            //{
            //    throw new NotImplementedException();
            //}


            public void LöscheKunde(Kunde kunde)
            {
                throw new NotImplementedException();
            }

            public Kunde ÄndereKunde(Kunde kunde)
            {
                throw new NotImplementedException();
            }

            public Kunde ErstelleKunde(NullTypenKomponente.AdresseTyp adresse)
            {
                throw new NotImplementedException();
            }
        }
    }
}
