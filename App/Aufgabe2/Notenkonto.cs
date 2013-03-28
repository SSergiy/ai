using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Aufgabe2
{
    public class Notenkonto
    {
        public virtual int Id { get; protected set; }
        public virtual double Gesamtnote { get; set; }
    }

    public class NotenkontoMap : ClassMap<Notenkonto> 
    {
        public NotenkontoMap() 
        {
            Id(x => x.Id);
            Map(x => x.Gesamtnote);
        }
    }
}
