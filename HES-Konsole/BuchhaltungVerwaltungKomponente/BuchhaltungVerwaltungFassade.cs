using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0TypenKomponente.TransportInterfaces;

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
    }
}
