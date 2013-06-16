using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    // Dieses Interface muss von Allen Adapterklassen Implementiert werden
    public interface IWebAPIAdapter
    {
        T Hole<T>(int id);
        IList<T> HoleAlle<T>();
        void Lösche<T>(int id);
        T Erstelle<T>(IList<String> parameter);
        // HTTP Schnitstellen
        string protokoll { get; }
        string HostName { get; }
        string api_pfad { get; }
        string port { get; }
        string controller { get; }

    }
}
