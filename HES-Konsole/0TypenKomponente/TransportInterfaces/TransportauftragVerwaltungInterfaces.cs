using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.EnumTypen;
using _0TypenKomponente.NummerTypen;
namespace _0TypenKomponente.TransportInterfaces
{
    public interface ILieferung
    {
        LieferungNummerTyp LieferungNr { get; }
        TransportAuftragNummerTyp AuftragNr { get; }
        DateTime Ausgangsdatum { get; }
        bool LieferungErfolgt { get; }
        DateTime Lieferdatum { get; }
        TransportDienstleister Transportdienstleister { get; }
    }
}
