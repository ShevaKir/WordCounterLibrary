using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class TextParse : IWordIndexer
    {
        private string[] _words;
        private char[] _separators = new char[] { ' ', '.', ',', '!' };

        public TextParse(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _words = source.Split(_separators, StringSplitOptions.RemoveEmptyEntries);      
        }

        public string this[int index] => _words[index];

        public int Count => _words.Length;

        //public IEnumerator<string> GetEnumerator()
        //{
        //    return _words.Cast<string>().GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return _words.GetEnumerator();
        //}
    }
}
