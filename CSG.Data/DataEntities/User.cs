using System.Collections.Generic;

namespace CSG.Data.DataEntities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public List<Login> Logins { get; set; }
        public User(string id) : base(id)
        { }
    }
}
