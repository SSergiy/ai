using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using _0TypenKomponente;

namespace CleanRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            clean();
            Console.ReadKey();
        }

        public static void clean()
        {
            try
            {
                var w = new WebClient();
                NetworkCredential nc = new NetworkCredential("guest", "guest", "");
                w.Credentials = nc;
                var url = "http://localhost:15672/api/connections";
                var json = w.DownloadString(url);
                Console.WriteLine(json);
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

                dynamic obj = serializer.Deserialize(json, typeof(object));

                for (int i = 0; i < obj.Length; i++)
                {
                    Console.WriteLine(obj[i].name);
                    using (var client = new WebClient())
                    {
                        client.Credentials = nc;
                        client.UploadString(url + "/" + obj[i].name, "DELETE", "");
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
