using System;

namespace CSG.Data.DataEntities
{
    public class Registration:BaseEntity
    {
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public string ClassId { get; set; }
        public int AttendanceStatusId { get; set; }
        public decimal Grade { get; set; }
        public DateTime AttendanceDate { get; set; }

        public Registration(string id) : base(id)
        { }
    }
}
