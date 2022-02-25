using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    class ThreeWord : Word, ICreateCollectionPharse
    {
        private const int SHIFT_WORDS = 2;

        public ThreeWord(string[] source) : base(source)
        {
            _words = new List<string>(_inputWords.Length - SHIFT_WORDS);
        }

        public void CreatePharse()
        {
            StringBuilder builderPharse = new StringBuilder();

            for (int i = 0; i < _inputWords.Length - SHIFT_WORDS; i++)
            {
                builderPharse.Append(_inputWords[i]);
                builderPharse.Append(" ");
                builderPharse.Append(_inputWords[i + 1]);
                builderPharse.Append(" ");
                builderPharse.Append(_inputWords[i + SHIFT_WORDS]);
                _words.Add(builderPharse.ToString());
                builderPharse.Clear();
            }
        }
    }
}
