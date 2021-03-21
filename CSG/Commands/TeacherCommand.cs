using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSG.Api.Commands
{
    public static class TeacherCommand
    {
       public static class V1
        {
            public class Request
            {
                public string Name { get; set; }
                public string Surname { get; set; }
                public string DateRegistered { get; set; }
            }
        }
    }
}
