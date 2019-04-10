using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CarParser
    {
        Car Cars;
        CarParser()
        {
            Cars = new Car();
        }
        void Parse()
        {
            var html = @"https://auto.drom.ru/volkswagen/golf/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var carslist = new List<string>();
            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"b-media-cont b-media-cont_modifyMobile_sm\"]");
            //  .SelectNodes("//a").ToList();
            // var nodes = node.Descendants("a");//("//a[@class=\"b-advItem\"]").ToList();
            // .Select(a => a.Attributes["href"].Value.Trim()).ToList();
            //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);
            foreach (var nNode in node.Descendants("a"))
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    // Cars = new Car(nNode);
                    carslist.Add("Node Name: " + nNode.Name + "\n" + nNode.OuterHtml);
                   // Console.WriteLine("Node Name: " + nNode.Name + "\n" + nNode.OuterHtml);
                }
            }
        }
    }
}
