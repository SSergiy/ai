using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace SchluesselverwaltungsKomponente
    {
        interface IAWKSchluesselVerwalter
        {
            /// <summary>
            /// Erzeugt einen neuen fachlichen Schlüssel-Slot.
            /// </summary>
            /// <param name="schlüsselName">Der Name des Schlüssels</param>
            /// <param name="wert">Der Startwert/Reset des Schlüssels</param>
            void CreateOrResetSchlüssel(String schlüsselName, Int32 wert = 1);

            /// <summary>
            /// Gibt den aktuellen Wert eines Schlüssels und erhöht den Zähler um 1.
            /// </summary>
            /// <param name="schlüsselName">Der Name des Schlüssels</param>
            /// <returns>Wert des Schlüssels</returns>
            Int32 NächsterSchlüssel(String schlüsselName);
        }
    }
}