using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport;
namespace Testlib
{
    public class TestClassA : ITest
    {
        public string name { get; private set; }
        public TestClassA(string name)
        {
            this.name = name;
        }



        public string pups
        {
            get { return name; }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
