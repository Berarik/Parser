using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ParserTestApps
{
    public class CarParsed
    {
        public string year { get; set; }
        public string name { get; set; }
        public string models { get; set; }
        public CarParsed(string n, string m,string y)
        {
            year = y;
            name = n;
            models = m;
        }
    }
}