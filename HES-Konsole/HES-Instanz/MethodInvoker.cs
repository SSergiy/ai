using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nachrichten;
using System.Reflection;

namespace HES_Instanz
{
    public class MethodInvoker
    {
        public static object Process(Message m)
        {
            object result = null;

            string pfad_zur_assembly = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + m.dll;
            Assembly assembly_der_komponente = System.Reflection.Assembly.LoadFile(pfad_zur_assembly);
            string voller_type = m.ns + "." + m.fassade;
            Type type_der_komponente = assembly_der_komponente.GetType(voller_type);

            if (type_der_komponente == null)
            {
                Console.WriteLine("Fassade: " + m.fassade + " nicht gefunden");
            }
            else
            {
                object instanz_der_komponente = Activator.CreateInstance(type_der_komponente);
                MethodInfo Methode = type_der_komponente.GetMethod(m.methode);

                if (m.parameter.Count() > 0)
                {

                    object[] p = m.parameter.ToArray<object>();
                    result = Methode.Invoke(instanz_der_komponente, p);
                }
                else
                {
                    result = Methode.Invoke(instanz_der_komponente, null);
                }

                // Falls Ergebnis Null, leeren String setzten.
                if (result == null)
                {
                    result = "Die Anfrage lieferte kein Ergebnis";
                }
            }

            return result;
        }
    }
}
