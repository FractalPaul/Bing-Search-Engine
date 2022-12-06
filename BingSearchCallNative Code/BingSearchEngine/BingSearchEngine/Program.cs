using System;
using System.Diagnostics;
using System.Net;
using System.Web;

namespace BingSearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Search Bing with a list....");

            CallBingSearchEngine("Muon");

            CallBingSearchEngine("Gravitational Coupling constant");            
        }

        protected static string bingSearchEngineBase = "https://www.bing.com/search?q={0}&qs=n&form=QBLH";

        protected static void CallBingSearchEngine(string searchTerm)
        {
            Process.Start(string.Format("microsoft-edge:{0}", string.Format(bingSearchEngineBase, HttpUtility.HtmlEncode(searchTerm))));
        }
    }
}
