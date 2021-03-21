using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSG.Api.Commands
{
    public static class ClassCommand
    {
        public static class V1
        {
            public class Request
            {
                public string ClassName { get; set; }
                public string Description { get; set; }
            }
        }
    }
}
