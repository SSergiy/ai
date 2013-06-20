using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0TypenKomponente.NummerTypen
{
    public abstract class NummerTyp
    {
        public virtual Int32 nummer { get; private set; }

        public NummerTyp() { }

        public NummerTyp(Int32 nr)
        {
            nummer = nr;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            NummerTyp p = obj as NummerTyp;
            if ((Object)p == null)
            {
                return false;
            }

            return nummer == p.nummer;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + nummer.GetHashCode();
            return hash;
        }
    }
}
