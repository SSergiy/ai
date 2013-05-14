using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SzenarioKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ProduktVerwaltungFassade f = new ProduktVerwaltungFassade();

            var ap = f.HoleAlleProdukte();
        }
    }
}
