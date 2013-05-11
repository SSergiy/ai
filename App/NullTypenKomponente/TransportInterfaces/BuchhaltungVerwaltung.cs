using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullTypenKomponente.TransportInterfaces
{
    public interface IRechnung
    {
        int Id { get; }
        DateTime RechnungsDatum { get; }
        bool IstBezahlt { get; }
        List<IZahlungseingang> Zahlungseingang { get; }
    }

    public interface IZahlungseingang
    {
        int Id { get; }
        DateTime Eingangsdatum { get; }
        double Betrag { get; }
    }
}
