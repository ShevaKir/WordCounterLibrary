using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    class TwoWords : Word, ICreateCollectionPharse
    {

        public TwoWords(string[] source) : base(source)
        {
            _words = new List<string>(_inputWords.Length - 1);
        }

        public void CreatePharse()
        {
            StringBuilder builderPharse = new StringBuilder();

            for (int i = 0; i < _inputWords.Length - 1; i++)
            {
                builderPharse.Append(_inputWords[i]);
                builderPharse.Append(" ");
                builderPharse.Append(_inputWords[i + 1]);
                _words.Add(builderPharse.ToString());
                builderPharse.Clear();
            }
        }
    }
}
