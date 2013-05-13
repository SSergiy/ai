using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;
namespace Anwendungskern
{
    namespace NullTypenKomponente
    {
        public interface ILieferung
        {
            int Id { get; }
            ITransportauftrag Transportauftrag { get; }
            IAuftrag Auftrag  { get; }
        }

        public interface ITransportauftrag
        {
            int Id { get; }
            DateTime Ausgangsdatum { get; }
            bool LieferungErfolgt { get; }
            DateTime Lieferdatum { get; }
            TransportdienstleisterTyp Transportdienstleister { get; }
        }

    }
}