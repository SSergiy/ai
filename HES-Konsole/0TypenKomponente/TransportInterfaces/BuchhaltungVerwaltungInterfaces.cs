using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.NummerTypen;

namespace _0TypenKomponente.TransportInterfaces
{
    public interface IRechnung
    {
        int Id { get; }
        DateTime RechnungsDatum { get; }
        bool IstBezahlt();
        List<IZahlungseingang> Zahlungseingang { get; }
        RechnungNummerTyp nummer { get; }
        double Betrag { get; }
        double Restbetrag();
    }

    public interface IZahlungseingang
    {
        int Id { get; }
        DateTime Eingangsdatum { get; }
        double Betrag { get; }
    }
}
