using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;
namespace Nachrichten
{
    public class Message
    {
        public string client { get; private set; }
        public string dll { get; private set; }
        // NameSpace
        public string ns { get; private set; }
        public string fassade { get; private set; }
        public string methode { get; private set; }
        public DateTime zeitpunkt { get; private set; }
        public List<string> parameter { get; private set; }

        // Basis Konstruktor
        public Message(string dll, string ns, string fassade, string method, string client)
        {
            this.zeitpunkt = DateTime.UtcNow;
            this.dll = dll;
            this.ns = ns;
            this.fassade = fassade;
            this.methode = method;
            this.client = client;
            this.parameter = new List<string>();
        }


        public Message(DateTime zeitpunkt, string dll, string ns, string fassade, string method, string client)
            : this(dll, ns, fassade, method, client) { this.zeitpunkt = zeitpunkt; }

        public Message(string dll, string ns, string fassade, string method, string client, List<string> parameter)
            : this(dll, ns, fassade, method, client)
        {
            this.parameter = parameter;
        }

        private Message(DateTime zeitpunkt, string dll, string ns, string fassade, string method, string client, List<string> parameter)
            : this(dll, ns, fassade, method, client)
        {
            this.parameter = parameter;
            this.zeitpunkt = zeitpunkt;
        }

        private string getjson(string key, string value)
        {
            // "key":"value"
            return "\"" + key + "\":\"" + value + "\"";
        }



        private string getjson(string key, List<string> values)
        {
            // "key":["value1","value2"]

            string result = "\"" + key + "\":[";
            if (values != null)
            {
                if (values.Count() > 1)
                {
                    for (int i = 0; i < values.Count() - 1; i++)
                    {
                        result += "\"" + values[i] + "\",";
                    }
                }

                if (values.Count() != 0)
                { result += "\"" + values[values.Count() - 1] + "\""; }
            }
            result += "]";
            return result;

        }


        public string getMessage()
        {
            string result = "{\n";
            result += getjson("zeitpunkt", DateTime.UtcNow.ToBinary().ToString()) + ",\n";
            result += getjson("client", client) + ",\n";
            result += getjson("dll", dll) + ",\n";
            result += getjson("ns", ns) + ",\n";
            result += getjson("fassade", fassade) + ",\n";
            result += getjson("methode", methode) + ",\n";
            result += getjson("parameter", parameter) + "\n";
            result += "}";
            return result;
        }

        public static Message getMessage(string message)
        {
            string[] groups = message.Split('\n');
            string[] zeitpunkt_group = groups[1].Split(':');
            string zeitpunkt = zeitpunkt_group[1].Replace("\"", string.Empty).Replace(",", string.Empty);

            string[] client_group = groups[2].Split(':');
            string client = client_group[1].Replace("\"", string.Empty).Replace(",", string.Empty);

            string[] dll_group = groups[3].Split(':');
            string dll = dll_group[1].Replace("\"", string.Empty).Replace(",", string.Empty);

            string[] ns_group = groups[4].Split(':');
            string ns = ns_group[1].Replace("\"", string.Empty).Replace(",", string.Empty);

            string[] fassade_group = groups[5].Split(':');
            string fassade = fassade_group[1].Replace("\"", string.Empty).Replace(",", string.Empty);

            string[] methode_group = groups[6].Split(':');
            string methode = methode_group[1].Replace("\"", string.Empty).Replace(",", string.Empty);

            string[] parameter_group = groups[7].Split(':');
            string parameter = parameter_group[1].Replace("[", string.Empty).Replace("]", string.Empty);

            if (parameter.Length > 0)
            {
                string[] parameter_elements = parameter.Split(',');
                List<string> result_params = new List<string>();

                for (int i = 0; i < parameter_elements.Count(); i++)
                {
                    result_params.Add(parameter_elements[i].Replace("\"", string.Empty));
                }
                return new Message(DateTime.FromBinary(long.Parse(zeitpunkt)), dll, ns, fassade, methode, client, result_params);
            }
            else
            {
                return new Message(DateTime.FromBinary(long.Parse(zeitpunkt)), dll, ns, fassade, methode, client);
            }
        }
    }
}
