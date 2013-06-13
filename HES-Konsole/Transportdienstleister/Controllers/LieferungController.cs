using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transportdienstleister.Persistenz;
using Transportdienstleister.Models;
using System.Web.Helpers;
using _0TypenKomponente.NummerTypen;

namespace Transportdienstleister.Controllers
{
    public class LieferungController : ApiController
    {
        private LieferungVerwalter verwalter = new LieferungVerwalter();
        /// <summary>
        /// GET api/lieferung
        /// </summary>
        /// <returns>JSON String</returns>
        public string Get()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(verwalter.HoleAlleLieferungen());
        }

        // GET api/lieferung/5
        public string Get(int id)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(verwalter.HoleLieferungUeberLieferNummer(id));
        }

        // POST api/lieferung
        /// <summary>
        /// Ruft die Erstellen Methode auf für einen Lieferungsauftrag.
        /// Eingabe ist hier eine Liste an Strings in JSON Verpackt. Reihenfolge beachten !
        /// </summary>
        /// <param name="json_lieferung_erstellen"></param>
        /// <returns>Liefert die Erzeugte Instanz als JSON string zurück.</returns>
        public string Post([FromBody]string json_lieferung_erstellen)
        {
            object lieferung_parameter_liste = Newtonsoft.Json.JsonConvert.DeserializeObject(json_lieferung_erstellen);

            try {
                var parameter_liste = (string[]) lieferung_parameter_liste;
                // Nun das Große Casten
                LieferungNummerTyp LieferungNr = new LieferungNummerTyp(int.Parse(parameter_liste[0]));
                TransportAuftragNummerTyp AuftragNr = new TransportAuftragNummerTyp(int.Parse(parameter_liste[1]));
                 DateTime Ausgangsdatum = DateTime.Parse(parameter_liste[2]);
                 bool LieferungErfolgt = Boolean.Parse(parameter_liste[3]);
                 DateTime Lieferdatum = DateTime.Parse(parameter_liste[4]);
                 var dienstleister = (TransportDienstleister) (Enum.Parse(typeof(TransportDienstleister), parameter_liste[5]));
                 var result=  verwalter.ErstelleLieferung(LieferungNr, AuftragNr, Ausgangsdatum, LieferungErfolgt, Lieferdatum, dienstleister);
                 return Newtonsoft.Json.JsonConvert.SerializeObject(result);
            }
            catch (InvalidCastException ex) { 
                Console.Error.WriteLine(ex.Message);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message); ;
            }
           
        }

        // PUT api/lieferung/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/lieferung/5
        public void Delete(int id)
        {
            verwalter.LöscheLieferung(new LieferungNummerTyp(id));
        }
    }
}