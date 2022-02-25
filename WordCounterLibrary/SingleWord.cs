using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    class SingleWord : Word
    {
        public SingleWord(string[] source) 
            : base(source)
        {
            _words = new List<string>(_inputWords);
        }

    }
}
