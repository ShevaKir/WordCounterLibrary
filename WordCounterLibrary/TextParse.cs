using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class TextParse : IWordIndexer, IEnumerable<string>
    {
        private string[] _words;
        private char[] _separators = new char[] { ' ', '.', ',', '!' };

        public TextParse(string source)
        {
            _words = source.Split(_separators, StringSplitOptions.RemoveEmptyEntries);      
        }

        public string this[int index] => _words[index];

        public int Count => _words.Length;

        public IEnumerator<string> GetEnumerator()
        {
            return _words.Cast<string>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _words.GetEnumerator();
        }
    }
}
