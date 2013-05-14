using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente;

namespace KundeVerwaltungKomponente
{
    public class KundeVerwaltungFassade
    {
        static KundeVerwaltung verwalter = new KundeVerwaltung();

        public IKunde ErstelleKunde(KundeNummerTyp nummer, String name, AdresseTyp adresse)
        {
            return verwalter.ErstelleKunde(nummer, name, adresse);
        }

        public IKunde HoleKunde(KundeNummerTyp kundennummerntyp)
        {
            return verwalter.HoleKunde(kundennummerntyp);
        }
    }
}
