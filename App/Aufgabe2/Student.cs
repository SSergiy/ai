using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Aufgabe2
{
    public class Student
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<Kurs> Kurse { get; protected set; }
        public virtual Notenkonto Notenkonto { get; set; }

        public Student() { }
    }

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Kurse);
            HasOne(x => x.Notenkonto);
        }
    }
}
