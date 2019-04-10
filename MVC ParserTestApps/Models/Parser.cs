using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MVC_ParserTestApps.Models
{
    public abstract class Parser
    {
        List<CarModels> parsed { get; set; }
        string parserstring { get; set; }
        public string URIadress { get; set; }
        CarsDBDataContext context;
        HtmlWeb web;
        protected string brandxpath { get; set; }
        protected string modelxpath { get; set; }
        protected string namexpath { get; set; }
        protected string yearxpath { get; set; }
        protected string caridxpath { get; set; }
        protected string carcontainer { get; set; }
        protected string carcontainername { get; set; }
        public string CurBrand { get; set; }
        private void Init()
        {
            context = new CarsDBDataContext(
            ConfigurationManager.ConnectionStrings["CDBConnectionString"].ConnectionString);
        }
        public Parser()
        {
            Init();
            web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding(65001)
            };
            parsed = new List<CarModels>();

        }
        public Parser(string URI) : this()
        {
            URIadress = URI;
        }
        public Parser(string URI, string brand, string model, string name, string year, string carid) : this(URI)
        {
            brandxpath = brand;
            modelxpath = model;
            namexpath = name;
            yearxpath = year;
            caridxpath = carid;
        }

        public List<CarModels> Parse()
        {

            var carslist = new List<string>();
            var str = ParseListpages();
            foreach (var br in str)
            {
                var htmlDoc = web.Load(br+"?all=1");
                var Brand = htmlDoc.DocumentNode.SelectSingleNode(brandxpath).InnerHtml;
                var node = htmlDoc.DocumentNode.SelectSingleNode(modelxpath);
                if (node.InnerLength != 0)
                {
                    var pnames = Parse(node, namexpath);
                    var pyears = Parse(node, yearxpath);
                    var pcarid = Parse(node, caridxpath);
                    for (var i = 0; i < pnames.Count; i++)
                    {

                        var sa = new CarModels();
                        sa.BrandName = Brand;
                        sa.ModelName = pnames[i];
                        sa.CarId = pcarid[i];
                        parsed.Add(sa);
                    }
                }
            }
            return parsed;
        }
        public List<CarModels> Parse(string brand)
        {

            var carslist = new List<string>();
            var str = searchBrand(brand);
            if (str != null)
            {
                var htmlDoc = web.Load(str);
                var Brand = htmlDoc.DocumentNode.SelectSingleNode(brandxpath).InnerHtml;
                var node = htmlDoc.DocumentNode.SelectSingleNode(modelxpath);
                var pnames = Parse(node, namexpath);
                if (pnames == null) return null;
                var pyears = Parse(node, yearxpath);
                var pcarid = Parse(node, caridxpath);
                for (var i = 0; i < pnames.Count; i++)
                {
                    var sa = new CarModels();
                    sa.BrandName = Brand;
                    sa.ModelName = pnames[i];
                    sa.CarId = pcarid[i];
                    parsed.Add(sa);
                }
                return parsed;
            }
            else
                return parsed;
            //return null;
        }
        public string searchBrand(string brand)
        {

            var htmlDoc = web.Load(URIadress);
            var model = htmlDoc.DocumentNode.SelectSingleNode(carcontainer);
            foreach (var nNode in model.SelectNodes(carcontainername))
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    var uri = nNode.GetAttributeValue("href", string.Empty);
                    if (uri.Contains(brand))
                        return URIadress.Remove(URIadress.IndexOf('/', 8)) + uri;
                }
            }
            return null;
        }

        List<string> ParseListpages()
        {
            List<string> listpage = new List<string>();
            var htmlDoc = web.Load(URIadress);
            var model = htmlDoc.DocumentNode.SelectSingleNode(carcontainer);
            //var namexpath = "//div[@class=\"catalog-column\"]/ul/li/a";
            List<string> carsyears = new List<string>();
            foreach (var nNode in model.SelectNodes(carcontainername))
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    var uri = nNode.GetAttributeValue("href", string.Empty);
                    carsyears.Add(URIadress.Remove(URIadress.IndexOf('/', 8)) + uri);
                }
            }
            return carsyears;
        }
        List<string> Parse(HtmlNode node, string parse)
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
    }
}
