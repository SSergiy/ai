using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Anwendungskern
{
    namespace NullTypenKomponente
    {
        public interface IKunde
        {
            Int32 id { get; }
            KundeNummerTyp nummer { get; }
            String name { get; }
            AdresseTyp adresse { get; }
        }
    }
}