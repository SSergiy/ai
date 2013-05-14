using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anwendungskern
{
    namespace NullTypenKomponente
    {
        public class LieferscheinTyp
        {
            public virtual int nummer { get; set; }

            public LieferscheinTyp() { }
            public LieferscheinTyp(int nummer) 
            {
                this.nummer = nummer;
            }
        }
    }
}