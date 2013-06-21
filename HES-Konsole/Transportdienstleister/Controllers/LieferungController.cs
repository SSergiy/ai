using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transportdienstleister.Persistenz;
using System.Web.Helpers;
using _0TypenKomponente.NummerTypen;
using _0TypenKomponente.TransportInterfaces;
using System.Collections;
using ServiceStack.Text;
using _0TypenKomponente.TransportTypen;

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
            return Newtonsoft.Json.JsonConvert.SerializeObject(verwalter.HoleAlleLieferungen().ToArray<TLieferung>());
        }

        // GET api/lieferung/5
        public TLieferung Get(int id)
        {
            var tlieferung = verwalter.HoleLieferungUeberLieferNummer(id);
            return tlieferung;


            //return TypeSerializer.SerializeToString<TLieferung>(verwalter.HoleLieferungUeberLieferNummer(id));
            //return Newtonsoft.Json.JsonConvert.SerializeObject(verwalter.HoleLieferungUeberLieferNummer(id),);
        }

        // POST api/lieferung
        /// <example>curl -X POST "Content-Type: application/json" -d '"[\"2\",\"2\",\"-858829873463932369\",\"False\",\"-858829873463932369\",\"DHL\"]"' http://localhost:51856/api/lieferung/</example>
        /// <summary>
        /// Ruft die Erstellen Methode auf für einen Lieferungsauftrag.
        /// Eingabe ist hier eine Liste an Strings in JSON Verpackt. Reihenfolge beachten !
        /// </summary>
        /// <param name="json_lieferung_erstellen"></param>
        /// <returns>Liefert die Erzeugte Instanz als JSON string zurück.</returns>
        public TLieferung Post([FromBody]string[] parameter_liste)
        {
            try {
               // Nun das Große Casten
                LieferungNummerTyp LieferungNr = new LieferungNummerTyp(int.Parse(parameter_liste[0]));
                TransportAuftragNummerTyp AuftragNr = new TransportAuftragNummerTyp(int.Parse(parameter_liste[1]));
                 DateTime Ausgangsdatum = DateTime.FromBinary(long.Parse(parameter_liste[2]));
                 bool LieferungErfolgt = Boolean.Parse(parameter_liste[3]);
                 DateTime Lieferdatum = DateTime.FromBinary(long.Parse(parameter_liste[4]));
                 var dienstleister = (_0TypenKomponente.EnumTypen.TransportDienstleister) (Enum.Parse(typeof(_0TypenKomponente.EnumTypen.TransportDienstleister), parameter_liste[5]));
                 var result=  verwalter.ErstelleLieferung(LieferungNr, AuftragNr, Ausgangsdatum, LieferungErfolgt, Lieferdatum, dienstleister);
                 return result;
            }
            catch (InvalidCastException ex) { 
                Console.Error.WriteLine(ex.Message);
               
            }

            return null;
           
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