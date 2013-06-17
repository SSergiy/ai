using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport;
namespace Testlib
{
    public class TestClassAVerwalter
    {
        public ITest erzeuge() 
        {
            return new TestClassA("Teeeest");
        }
    }
}
