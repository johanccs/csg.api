using System;

namespace CSG.Api.Commands
{
    public static class StudentCommand
    {
        public static class V1
        {
            public class Request
            {
                public string Name { get; set; }
                public string Surname { get; set; }
                public DateTime DateRegistered { get; set; }
            }
        }
    }
}
