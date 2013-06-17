using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Testlib;
using Transport;

namespace WebAPITest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var verwalter = new TestClassAVerwalter();
            var neu = verwalter.erzeuge();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(neu);
            Console.WriteLine(json);
            var o = Newtonsoft.Json.JsonConvert.DeserializeObject<Test2>(json);
            Console.WriteLine(o.ToString());
            Console.ReadKey();
        }

        public class Test2 : ITest
        {
            public string pups
            {
                get { return "ABC"; }
            }
        }

    }
}
