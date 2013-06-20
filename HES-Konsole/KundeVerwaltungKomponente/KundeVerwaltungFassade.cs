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

        public IKunde ErstelleKunde(String name, AdresseTyp adresse)
        {
            return verwalter.ErstelleKunde(name, adresse);
        }


        public IKunde HoleKunde(KundeNummerTyp kundennummerntyp)
        {
            return verwalter.HoleKunde(kundennummerntyp);
        }

        // Remote Call
        public IKunde HoleKundeRemote(string kundennummerntyp)
        {
            return verwalter.HoleKunde(new KundeNummerTyp(int.Parse(kundennummerntyp)));
        }

    }
}
