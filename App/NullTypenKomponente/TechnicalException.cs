using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace NullTypenKomponente
    {
        /// <summary>
        /// Repräsentiert den Fall, wenn ein technischen Fehler auftrit.
        /// </summary>
        public class TechnicalException:Exception
        {
            public TechnicalException(Exception inner)
                : base("Es gab ein technischer Fehler!", inner)
            {
            }
        }
    }
}