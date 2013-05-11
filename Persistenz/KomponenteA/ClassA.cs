using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace KomponenteA
{
    public class ClassA
    {
        public ClassA() { }
        public virtual int id { get; set; }
        public virtual string name { get; set; }
    }
    public class ClassAMap : ClassMap<ClassA> 
    {
        public ClassAMap() 
        {
            Id(x => x.id);
            Map(x => x.name);
        }
    }
}
