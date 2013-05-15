using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente
{
    public class KontoverbindungTyp
    {
        public virtual int nummer { get; set; }

        public KontoverbindungTyp() { }
        public KontoverbindungTyp(int nummer)
        {
            this.nummer = nummer;
        }
    }
}
