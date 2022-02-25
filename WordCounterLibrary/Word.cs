using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    abstract class Word
    {
        protected string[] _inputWords;
        protected List<string> _words;

        public Word(string[] source)
        {
            _inputWords = source;
        }

        public  IEnumerable<string> Words 
        { 
            get 
            {
                return _words.AsEnumerable();
            } 
        }
    }
}
