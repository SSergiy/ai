using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;

namespace NullTypenKomponente.TransportInterfaces
{
    public interface ILieferung
    {
        int Id { get; }
        ITransportauftrag Transportauftrag { get; }
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
