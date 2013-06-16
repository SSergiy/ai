using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adapter;
namespace TransportdienstleisterVerwaltungKomponente
{
    public class TransportdienstleisterWebAPIAdapter : WebAPIBasisKlasse
    {
        public override string controller
        {
            get { return "lieferung"; }
        }
        public override string port
        {
            get { return "51856"; }
        }
    }
}
