using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;


namespace KomponenteB
{
    public class ClassB
    {
        public ClassB() { }
        public virtual int id { get; set; }
        public virtual string name { get; set; }


    }

    public class ClassBMap : ClassMap<ClassB>
    {
        public ClassBMap()
        {
            Id(x => x.id);
            Map(x => x.name);
        }
    }
}
