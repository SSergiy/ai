using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Aufgabe2
{
    public class Kurs
    {
        public virtual int Id { get; protected set; }
        public virtual string Titel { get; set; }
        public virtual IList<Buch> Buch { get; set; }
    }

    public class KurseMap : ClassMap<Kurs> 
    {
        public KurseMap()
        {
            Id(x => x.Id);
            Map(x => x.Titel);
            HasManyToMany(x => x.Buch)
                .Table("KurseBuch");
        }
    }



}
