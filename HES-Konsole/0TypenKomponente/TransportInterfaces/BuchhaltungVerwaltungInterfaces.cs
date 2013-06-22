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
        DateTime RechnungsDatum { get; set; }
        bool IstBezahlt();
        IList<IZahlungseingang> Zahlungseingang { get; }
        RechnungNummerTyp nummer { get; set; }
        double Betrag { get; set; }
        double Restbetrag();
        void NeuerZahlungseingang(IZahlungseingang zahlungseingang);
    }

    public interface IZahlungseingang
    {
        int Id { get; }
        DateTime Eingangsdatum { get; }
        double Betrag { get; }
    }
}
