using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace KundenVerwaltungsKomponente
    {
        public interface IAWKKundenVerwaltung
        {
            /// <summary>
            /// Erzeugt einen neuen Kunde
            /// Die Adresse wird anhand  strasse,  hausnummer,  postleitzahl,  ort,  land erzeugt
            /// </summary>
            /// <param name="name">Name des Kundes</param>
            /// <param name="strasse">Die Strasse der neue Adresse des Kundes</param>
            /// <param name="hausnummer">Die Hausnumer der neue Adresse des Kundes</param>
            /// <param name="postleitzahl">Die Postleitzahl der neue Adresse des Kundes</param>
            /// <param name="ort">Der Ort der neue Adresse des Kundes</param>
            /// <param name="land">Die Land der neue Adresse des Kundes</param>
            /// <returns>Kunde</returns>
            /// 
            Kunde ErstelleKunde(String name, String strasse, String hausnummer, String postleitzahl, String ort, String land);


            /// <summary>
            /// Löscht einen Kunden.
            /// </summary>
            /// <param name="adresse">Der Kunde, der gelöscht werden soll</param>
            void LoescheKunde(Kunde kunde);


            /// <summary>
            /// Ändert einen Kunden.
            /// </summary>
            /// <param name="adresse">Der Kunde, der geändert werden soll</param>
            Kunde AendereKunde(Kunde kunde);
        }
    }
}
