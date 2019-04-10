using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Car
    {
        string Source { get; set; }
        string Header { get; set; }
        Content carscontent = new Content();
        Car(HtmlWeb elem) { }

        public Car()
        {
        }
    }       
    class Content
    {
        string title { get; set; }
        int price { get; set; }

    }

}


