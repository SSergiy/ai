using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace SchluesselverwaltungsKomponente
    {
        class UnbekannterSchlüsselException:Exception
        {
            public UnbekannterSchlüsselException(String schlüsselName)
                : base(schlüsselName)
            {
            }
        }
    }
}