using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ParserTestApps
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public CarsDBDataContext Db { get; set; }

    }
}