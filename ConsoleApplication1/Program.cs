using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ParserTest
{
    public static class Program
    {
       
        private static void Main()
        {
        
            List<string> parslist = Parse();
         //   foreach (var list in parslist)
              //  DromParser.ParserLists.Items.Add(list);
            

        }


        static List<string> Parse()
        {
            var html = @"https://auto.drom.ru/volkswagen/golf/";
            HtmlWeb web = new HtmlWeb();
            var carslist = new List<string>();
            var htmlDoc = web.Load(html);
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
