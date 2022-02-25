using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class TextParse
    {
        private string[] _words;
        private char[] _separators = new char[] { ' ', '.', ',' };

        public TextParse(string source)
        {
            _words = source.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
           
        }

        public string[] Words 
        { 
            get 
            { 
                return _words; 
            } 
        }
        //
        //public IEnumerable<WordCount> GetWordCounts()
        //{
        //    return _words.Select(x => x.ToLower())
        //                 .GroupBy(x => x)
        //                 .Select(word => new WordCount() { Word = word.Key, Count = word.Count() })
        //                 .OrderBy(x => x);
        //}
    }
}
