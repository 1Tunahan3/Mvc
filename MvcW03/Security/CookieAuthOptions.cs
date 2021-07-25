using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcW03.Security
{
    public class CookieAuthOptions
    {
        public string Name { get; set; }

        public string LoginPath { get; set; }

        public string LogoutPath { get; set; }

        public string AccessDeniedPath { get; set; }

        public bool SlidingExpiration { get; set; }

        public int Timeout { get; set; }

        

    }
}
