using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace Anwendungskern
{
    namespace KundenVerwaltungsKomponente
    {
        public interface IAWKKundenVerwaltung
        {
            Kunde ErstelleKunde(AdresseTyp adresse);

            /// <summary>
            /// Löscht einen Kunden.
            /// </summary>
            /// <param name="adresse">Der Kunde, der gelöscht werden soll</param>
            void LöscheKunde(Kunde kunde);


            /// <summary>
            /// Ändert einen Kunden.
            /// </summary>
            /// <param name="adresse">Der Kunde, der geändert werden soll</param>
            Kunde ÄndereKunde(Kunde kunde);
        }
    }
}
