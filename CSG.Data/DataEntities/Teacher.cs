using System;

namespace CSG.Data.DataEntities
{
    public class Teacher:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
