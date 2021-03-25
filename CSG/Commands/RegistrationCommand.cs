using System;
using System.Collections.Generic;

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
                public bool AttendanceStatusId { get; set; }
                public int Grade { get; set; }
                public string AttendanceDate { get; set; }
            }

            public class Requests
            {
                public List<Request> Collection { get; set; }
            }
        }
    }
}
