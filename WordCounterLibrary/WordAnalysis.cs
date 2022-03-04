using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class WordAnalysis
    {
        private const int ONE_HUNGRED_PERCENT = 100;
        private const int ENTRIES = 1;
        private IWordIndexer _inputWords;
        private int _numberEntries;
        private List<string> _phrase;
        private IEnumerable<WordCount> _allPhrase;

        public WordAnalysis(IWordIndexer sourceWord, int numberEntries = ENTRIES)
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
            CountPhrase = sourceWord.Count - (numberEntries - 1);
            _phrase = new List<string>(CountPhrase);

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

        public int CountPhrase { get; }

        private double GetPercentWord(int count)
        {
            return (ONE_HUNGRED_PERCENT * count) / (double)CountPhrase;
        }

        private IEnumerable<WordCount> GetPhrase()
        {
            return _phrase.Select(x => x.ToLower())
                          .GroupBy(x => x)
                          .Select(word => new WordCount() 
                          { 
                              Word = word.Key, 
                              Count = word.Count(), 
                              Percent = GetPercentWord(word.Count())
                          })
                          .OrderBy(x => x);
        }

        public IEnumerable<WordCount> GetTopWordPharse(int topWord = 0)
        {
            if (topWord < 0 || topWord > _phrase.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(topWord));
            }

            if (topWord != 0)
            {
                _allPhrase = GetPhrase().Take(topWord);
            }
            else
            {
                _allPhrase = GetPhrase();
            }

            return _allPhrase;
        }
    }
}
