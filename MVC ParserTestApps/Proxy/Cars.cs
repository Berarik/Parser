using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ParserTestApps
{
    public partial class Cars
    {
        public static string GetActivateUrl()
        {
            return Guid.NewGuid().ToString("N");
        }
        
    }
}