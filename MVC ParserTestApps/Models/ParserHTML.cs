using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using System.Text;
using System.Configuration;
using System.Data.Linq;

namespace MVC_ParserTestApps
{
    public class ParserHTML
    {

        public List<string> parsedstring { get; set; }
        string parserstring { get; set; }
        public string URIadress { get; set; }
        CarsDBDataContext context = new CarsDBDataContext(
                ConfigurationManager.ConnectionStrings["CDBConnectionString"].ConnectionString);
        HtmlWeb web;

        public ParserHTML()
        {
            web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding(65001)
            };
            // URIadress = @"https://auto.drom.ru/volkswagen/golf/";
            URIadress = @"https://exist.ru/Catalog/Global/Cars/AC";
        }
        public ParserHTML(string URI)
        {
            web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding(1251)
            };
            URIadress = URI;
        }
        public List<string> dbSelect()
        {
            var resstring = new List<string>();
            

            var roles = context.CarModels.ToList();
            foreach (var role in roles)
            {
                resstring.Add(role.ModelId + role.BrandName + role.ModelName);
            }
            return resstring;
        }
        public List<string> dbSelect(string slStr)
        {
            var resstring = new List<string>();
            var roles = context.CarModels.Where(p => p.ModelName == slStr).ToList();
            foreach (var role in roles)
            {
                resstring.Add(role.ModelId + role.BrandName + role.ModelName);
            }
            return resstring;
        }
        public void dbInsert(string[] inStr)
        {
            if (inStr.Length < 2) throw new Exception("low Array Lenght");
            var newRole = new CarModels
            {
                BrandName = inStr[0],
                ModelName = inStr[1]
            };
            context.CarModels.InsertOnSubmit(newRole);
            context.CarModels.Context.SubmitChanges();
        }
        public void dbDelete(string[] inStr)
        {
            if (inStr.Length < 1) throw new Exception("low Array Lenght");
            var delCarmodel = context.CarModels.Where(p => p.ModelName == inStr[0]).FirstOrDefault();
            if (delCarmodel != null)
            {
                context.CarModels.DeleteOnSubmit(delCarmodel);
                context.CarModels.Context.SubmitChanges();
            }           
        }
        public void dbUpdate(string[] upStr,string[] inStr)
        {
            if (inStr.Length < 2 || upStr.Length < 2) throw new Exception("low Array Lenght");
            var updCarmodel = context.CarModels.Where(p => p.ModelName == inStr[0]).FirstOrDefault();
            if (updCarmodel != null)
            {

                updCarmodel.ModelName = "Манагер";
                context.CarModels.Context.SubmitChanges();
            }
        }       
        public List<string> Parse()
        {                
            return parsedstring;
        }
        //public List<string> ParsePage()
        //{
        //    var carslist = new List<string>();
        //    parsedstring = carslist;
           
        //    var htmlDoc = web.Load(URIadress);
        //    var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"rModel\"]");
        //    //  .SelectNodes("//a").ToList();
        //    // var nodes = node.Descendants("a");//("//a[@class=\"b-advItem\"]").ToList();
        //    // .Select(a => a.Attributes["href"].Value.Trim()).ToList();
        //    //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);     

        //    var carsnames = "//div[@class=\"car-info__car-name\"]";
        //    var carsyears = "//div[@class=\"car-info__car-years\"]";
        //    //foreach (var nNode in node.SelectNodes())
        //    //{
        //    //    if (nNode.NodeType == HtmlNodeType.Element)
        //    //    {
        //    //        // var CurCarName = nNode;
        //    //        //var nextstep = CurCarName.SelectNodes("//*[@class=\"car-info__car-name\"]");  //("//*[@class=\"car-info__car-name\"]");//SelectNodes("//*[@class=\"car-info__car-name\"]").First().InnerHtml;
        //    //        //foreach(var twostep in nextstep)
        //    //        //{
        //    //      //  var ycar = nNode.SelectSingleNode("/div[@class=\"car-info__car-years\"]");
        //    //        carslist.Add(nNode.InnerText);

        //    //        //}
        //    //        //  Console.WriteLine("Node Name: " + nNode.Name + "\n" + nNode.OuterHtml);
        //    //    }
        //    //}

        //    carslist.AddRange(parsers(node, carsnames));
        //    carslist.AddRange(parsers(node, carsyears));
        //    return carslist;
        //}
        public List<CarModels> ParsePage()  
        {
            List<CarModels> par = new List<CarModels>();
            var carslist = new List<string>();
            parsedstring = carslist;
            var htmlDoc = web.Load(URIadress);
            var model = htmlDoc.DocumentNode.SelectSingleNode("//span[@class=\"menu-curent-node\"]").InnerHtml;

            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"rModel\"]");    
            var name = "//div[@class=\"car-info__car-name\"]";
            var years = "//div[@class=\"car-info__car-years\"]";
            var models = "//div[@class=\"car-info__car-models\"]";
            var pnames = parsers(node, name);
            var pyears = parsers(node, years);
            var pmodels = parsers(node, models);

            for (var i = 0; i<pnames.Count;i++)
            {
                var sa = new CarModels();
                sa.BrandName = model;
                sa.ModelName = pnames[i];                
                sa.CarId = pmodels[i];
                par.Add(sa);
            }
            return par;
        }
        public List<CarModels> ParsePage(string uri)
        {
            List<CarModels> par = new List<CarModels>();
            var carslist = new List<string>();
            parsedstring = carslist;
            var htmlDoc = web.Load(uri);
            var model = htmlDoc.DocumentNode.SelectSingleNode("//span[@class=\"menu-curent-node\"]").InnerHtml;
            var type = htmlDoc.DocumentNode.SelectSingleNode("//a[@class=\"menu-node\"]").InnerHtml;
            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"rModel\"]");
            var name = "//div[@class=\"car-info__car-name\"]";
            var years = "//div[@class=\"car-info__car-years\"]";
            var models = "//div[@class=\"car-info__car-models\"]";
            var pnames = parsers(node, name);
            var pyears = parsers(node, years);
            var pmodels = parsers(node, models);

            for (var i = 0; i < pnames.Count; i++)
            {
                var sa = new CarModels();
                sa.BrandName = model;
                sa.ModelName = pnames[i];
                sa.CarId = pmodels[i];
                //sa.CarType = type;
                par.Add(sa);
            }
            return par;
        }
        public List<string> ParseListpages()
        {
            List<string> listpage = new List<string>();
            var htmlDoc = web.Load(URIadress);
            var model = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"top-r\"]");
            var name = "//div[@class=\"catalog-column\"]/ul/li/a";
           // var pnames = parsers(model, name);
            List<string> carsyears = new List<string>();
            foreach (var nNode in model.SelectNodes(name))
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    var uri = nNode.GetAttributeValue("href", string.Empty);
                   
                    carsyears.Add(@"https://exist.ru"+uri);
                }
            }
            //foreach (var node in pnames)
            //{
            //    var hsd = new HtmlDocument();
            //    hsd.LoadHtml(node);
            //    var sel = hsd.DocumentNode.Attributes;
            //}



            return carsyears;
        }
        //public List<CarParsed> ParsePage(string URI)
        //{
        //    List<CarParsed> par = new List<CarParsed>();
        //    var carslist = new List<string>();
        //    parsedstring = carslist;
        //    var htmlDoc = web.Load(URI);
        //    var model = htmlDoc.DocumentNode.SelectSingleNode("//span[@class=\"menu-curent-node\"]").InnerHtml;
        //    var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"rModel\"]");
        //    var name = "//div[@class=\"car-info__car-name\"]";
        //    var years = "//div[@class=\"car-info__car-years\"]";
        //    var models = "//div[@class=\"car-info__car-models\"]";
        //    var pnames = parsers(node, name);
        //    var pyears = parsers(node, years);
        //    var pmodels = parsers(node, models);
        //    for (var i = 0; i < pnames.Count; i++)
        //    {
        //        par.Add(new CarParsed(pnames[i], pmodels[i], pyears[i]));
        //    }

        //    return par;
        //}
        private List<string> parsers(HtmlNode node,string parse)
        {
            List<string> carsyears = new List<string>();
            foreach (var nNode in node.SelectNodes(parse))
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    carsyears.Add(nNode.InnerText);
                }
            }
            return carsyears;
        }
        public List<string> ParsePageDrom()
        {
            var carslist = new List<string>();
            parsedstring = carslist;
            var htmlDoc = web.Load(URIadress);
            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"b-media-cont b-media-cont_modifyMobile_sm\"]");
            //  .SelectNodes("//a").ToList();
            // var nodes = node.Descendants("a");//("//a[@class=\"b-advItem\"]").ToList();
            // .Select(a => a.Attributes["href"].Value.Trim()).ToList();
            //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);     
            foreach (var nNode in node.Descendants("a"))
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    carslist.Add(nNode.OuterHtml);
                    //  Console.WriteLine("Node Name: " + nNode.Name + "\n" + nNode.OuterHtml);
                }
            }
            return carslist;
        }
    }
}