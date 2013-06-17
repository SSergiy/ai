using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    // Dieses Interface muss von Allen Adapterklassen Implementiert werden
    public interface IWebAPIAdapter
    {
        string Hole(int id);
        string HoleAlle();
        void Lösche(int id);
        string Erstelle(IList<String> parameter);
        // HTTP Schnitstellen
        string protokoll { get; }
        string HostName { get; }
        string api_pfad { get; }
        string port { get; }
        string controller { get; }

    }
}
