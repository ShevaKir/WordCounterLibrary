using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class WordAnalysis
    {
        private const int ENTRIES = 1;
        private string[] _inputWords;
        private int _numberEntries;
        private List<string> _phrase;

        public WordAnalysis(string[] sourceWord, int numberEntries = ENTRIES)
        {
            if(numberEntries < 1)
            {
                throw new LessThanOneWordException(nameof(numberEntries));
            }
            if (sourceWord == null)
            {
                throw new NullReferenceException(nameof(sourceWord));
            }

            _inputWords = sourceWord;
            _numberEntries = numberEntries;
            _phrase = new List<string>(sourceWord.Length - numberEntries - 1);
            CreatePhrase();
        }

        private void CreatePhrase()
        {
            StringBuilder builderPharse = new StringBuilder();

            for (int i = 0; i < _inputWords.Length - _numberEntries - 1; i++)
            {
                int count = 0;
                while (count < _numberEntries)
                {
                    builderPharse.Append(_inputWords[i + count]);
                    builderPharse.Append(" ");
                    count++;
                }
                _phrase.Add(builderPharse.ToString());
                builderPharse.Clear();
            }
        }

        public IEnumerable<WordCount> GetTopWordPharse()
        {
            return _phrase.Select(x => x.ToLower())
                         .GroupBy(x => x)
                         .Select(word => new WordCount() { Word = word.Key, Count = word.Count() })
                         .OrderBy(x => x);
        }
    }
}
