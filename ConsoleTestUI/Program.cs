using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WordCounterLibrary;

namespace ConsoleTestUI
{
    class Program
    {
        public static string inputTest = "Split PDF document online is a web service that allows you to split your PDF document into separate pages. This simple application has several modes of operation, you can split your PDF document into separate pages, i.e. each page of the original document will be a separate PDF document, you can split your document into even and odd pages, this function will come in handy if you need to print a document in the form of a book, you can also specify page numbers in the settings and the Split PDF application will create separate PDF documents only with these pages and the fourth mode of operation allows you to create a new PDF document in which there will be only those pages that you specified.";
        //public static string inputTest = "Hello, my dear friend.";

        static void Main(string[] args)
        {
            TextParse text = new TextParse(inputTest);
            WordAnalysis wordAnalysis = new WordAnalysis(text, 2);

            foreach (var item in wordAnalysis.GetTopWordPharse(wordAnalysis.Count))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
