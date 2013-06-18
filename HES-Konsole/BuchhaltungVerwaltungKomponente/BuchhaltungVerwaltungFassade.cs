using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;
using _0TypenKomponente.NummerTypen;

namespace BuchhaltungVerwaltungKomponente
{
    public class BuchhaltungVerwaltungFassade
    {
        private static readonly BuchhaltungVerwaltung buchhaltungsVerwalter = new BuchhaltungVerwaltung();

        public IRechnung ErstelleRechnung(IAuftrag auftrag)
        {
            return buchhaltungsVerwalter.ErstelleRechnung(auftrag);
        }

        public void VerschickeRechnung(IRechnung rechnung)
        {
            buchhaltungsVerwalter.VerschickeRechnung(rechnung);
        }

        public void VerbucheZahlung(RechnungNummerTyp rechnungnummertyp, double betrag)
        {
            buchhaltungsVerwalter.VerbucheZahlung(rechnungnummertyp, betrag);
        }

        public IRechnung HoleRechnung(RechnungNummerTyp rechnungnummertyp)
        {
            return buchhaltungsVerwalter.HoleRechnung(rechnungnummertyp);
        } 
        
        // Remote Call
        public void VerbucheZahlungRemote(string rechnungnummer, string betrag)
        {
            VerbucheZahlung(new RechnungNummerTyp(int.Parse(rechnungnummer)), double.Parse(betrag));
        }
    }
}
