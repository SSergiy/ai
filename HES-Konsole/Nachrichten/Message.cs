using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;
namespace Nachrichten
{
    public class Message
    {
        public string fassade { get; private set; }
        public string method { get; private set; }
        public string client_name { get; private set; }

        private string key_client_name = "client_name";

        public List<string> parameter { get; private set; }
        public Message() { }
        public Message(string component, string method, string client_name)
        {
            this.fassade = component;
            this.method = method;
            this.client_name = client_name;
        }

        public Message(string component, string method, string client_name, List<string> parameter)
            : this(component, method, client_name)
        {
            this.parameter = parameter;
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
            if (values.Count() > 1)
            {
                for (int i = 0; i < values.Count() - 1; i++)
                {
                    result += "\"" + values[i] + "\",";
                }
            }

            if (values.Count() != 0)
            { result += values[values.Count() - 1]; }

            result += "]";
            return result;

        }


        public string getMessage()
        {
            string result = "{\n";
            result += getjson("client_name", client_name) + ",\n";
            result += getjson("fassade", fassade) + ",\n";
            result += getjson("methode", method) + ",\n";
            result += getjson("parameter", parameter) + "\n";
            result += "}";
            return result;
        }

        /// <summary>
        /// Konvertiert den String in eine Nachricht. 
        /// Sicherlich auch mit RegEx lösbar...
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Message getMessage(string message)
        {
            string[] groups = message.Split('\n');
            string[] client_group = groups[1].Split(',');
            string client = client_group[1].Replace("\"", string.Empty);

            string[] fassade_group = groups[2].Split(',');
            string fassdae = fassade_group[1].Replace("\"", string.Empty);

            string[] methode_group = groups[3].Split(',');
            string methode = methode_group[1].Replace("\"", string.Empty);

            string[] parameter_group = groups[4].Split(':');
            string parameter = parameter_group[1].Replace("[", string.Empty).Replace("]", string.Empty);

            if (parameter.Length > 0)
            {
                string[] parameter_elements = parameter.Split(',');
                List<string> parameter_liste = new List<string>();
                foreach (String p in parameter_elements)
                {
                    parameter_liste.Add(p);
                }
                return new Message(fassdae, methode, client, parameter_liste);
            }
            else
            {
                return new Message(fassdae, methode, client);
            }
        }
    }
}
