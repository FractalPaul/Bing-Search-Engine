using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace BingSearchCallNative
{
    class Program
    {
        protected static string _searchFileName = "searchlist.txt";
        protected static string _bingSearchEngineBase = "https://www.bing.com/search?q={0}&qs=n&form=QBLH";
        protected static int _delayTime = 2000;
        protected static int _maxLines = 60;

        static void Main(string[] args)
        {
            Console.WriteLine("Search Bing Engine with list...");
            Console.WriteLine("Bing Search web site: {0}", _bingSearchEngineBase);
            Console.WriteLine("The file list to list the search terms is: {0}", _searchFileName);
            Console.WriteLine("{0} searches being performed.", _maxLines);

            if (File.Exists(_searchFileName))
            {
                SearchListFile(_searchFileName);
            } else
            {
                if (args != null && args.Count() >0)
                {
                    foreach (string eachSearch in args)
                    {
                        Console.WriteLine("Bing Search for: {0}", eachSearch);
                        CallBingSearchEngine(eachSearch);
                        Thread.Sleep(_delayTime);
                    }
                }
                else
                {
                    Console.WriteLine("**** Nothing found to search Bing for...");
                }
            }
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("##### End Search Bing ########");
        }

        private static void SearchListFile(string searchFileName)
        {
            string[] lines = File.ReadAllLines(searchFileName);

            if(lines != null && lines.Count() >0)
            {
                int iLine = 0;
                foreach(string eachLine in lines)
                {
                    iLine++;
                    if (!string.IsNullOrEmpty(eachLine))
                    {
                        Console.WriteLine("Calling Bing Search for: {0}", eachLine);
                        CallBingSearchEngine(eachLine);
                        Thread.Sleep(_delayTime);
                    }

                    if (iLine >= _maxLines)
                        break;
                }
            } else
            {
                Console.WriteLine("Nothing found in the file: {0}", searchFileName);
            }
        }

        protected static void CallBingSearchEngine(string searchTerm)
        {
            //WebRequest webReq = WebRequest.Create(string.Format(bingSearchEngineBase, HttpUtility.HtmlEncode(searchTerm)));            
            Process.Start (string.Format( "microsoft-edge:{0}", string.Format(_bingSearchEngineBase, HttpUtility.HtmlEncode(searchTerm))));
        }
    }
}
