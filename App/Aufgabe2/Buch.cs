using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Aufgabe2
{
    public class Buch
    {

        public virtual int Id {get; protected set;}
        public virtual string Titel { get; set; }
    }

    public class BuchMap : ClassMap<Buch>
    {
        public BuchMap() 
        {
            Id(x => x.Id);
            Map(x => x.Titel);
        }
    }
}
