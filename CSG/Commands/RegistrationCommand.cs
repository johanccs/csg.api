using System;

namespace CSG.Api.Commands
{
    public static class RegistrationCommand
    {
        public static class V1
        {
            public class Request
            {
                public string StudentId { get; set; }
                public string TeacherId { get; set; }
                public string ClassId { get; set; }
                public int AttendanceStatusId { get; set; }
                public decimal Grade { get; set; }
                public DateTime AttendanceDate { get; set; }
            }
        }
    }
}
