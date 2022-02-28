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
        //private string[] _inputWords;
        private IWordIndexer _inputWords;
        private int _numberEntries;
        private List<string> _phrase;

        public WordAnalysis(IWordIndexer sourceWord, int numberEntries = ENTRIES) // отправлять инумератор
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
            //_inputWords = sourceWord;
            _numberEntries = numberEntries;
            Count = sourceWord.Count - (numberEntries - 1);
            _phrase = new List<string>(Count);

            CreatePhrase();
        }

        private void CreatePhrase()
        {
            StringBuilder builderPharse = new StringBuilder();

            for (int i = 0; i < _inputWords.Count - (_numberEntries - 1); i++)
            {
                int count = 0;
                while (count < _numberEntries)
                {
                    builderPharse.Append(_inputWords[i + count]);
                    if (count < _numberEntries - 1)
                    {
                        builderPharse.Append(" ");
                    }
                    count++;
                }
                _phrase.Add(builderPharse.ToString());
                builderPharse.Clear();
            }
        }

        public int Count { get; }

        public IEnumerable<WordCount> GetTopWordPharse(int topWord = 0)
        {
            if (topWord > _phrase.Count && topWord < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(topWord));
            }

            var phrases = _phrase.Select(x => x.ToLower())
                                 .GroupBy(x => x)
                                 .Select(word => new WordCount() { Word = word.Key, Count = word.Count() })
                                 .OrderBy(x => x);

            if (topWord != 0)
            {
                phrases.Take(topWord);
            }

            return phrases;
        }
    }
}
