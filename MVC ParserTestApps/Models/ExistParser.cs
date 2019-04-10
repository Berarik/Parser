using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ParserTestApps.Models
{
    public class ExistParser : Parser
    {
        //public ExistParser(string URI) : base()
        //{
        //    carcontainer = "//div[@class=\"top-r\"]";
        //    carcontainername = "//div[@class=\"catalog-column\"]/ul/li/a";
        //    URIadress = URI;
        //}
        public ExistParser():base()
        {
            URIadress = @"https://exist.ru/Catalog/Global/";
            brandxpath = "//span[@class=\"menu-curent-node\"]";
            modelxpath = "//*[@class=\"rModel\"]";
            namexpath = "//div[@class=\"car-info__car-name\"]";
            yearxpath = "//div[@class=\"car-info__car-years\"]";
            caridxpath = "//div[@class=\"car-info__car-models\"]";
            carcontainer = "//div[@class=\"top-r\"]";
            carcontainername = "//div[@class=\"catalog-column\"]/ul/li/a";

        }
        //public ExistParser(string URI, string brand, string model, string name, string year, string carid) : base(URI, brand, model, name, year, carid)
        //{
        //}
    }
}