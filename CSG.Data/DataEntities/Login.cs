using System;

namespace CSG.Data.DataEntities
{
    public class Login:BaseEntity
    {
        public DateTime LoginTime { get; set; }
        public DateTime LogOutTime { get; set; }
        public string UserId { get; set; }

        public Login(string id):base(id)
        {
        }

    }
}
