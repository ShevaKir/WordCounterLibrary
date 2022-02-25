using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class WordCount : IComparable<WordCount>
    {
        public string Word { get; set; }

        public int Count { get; set; }

        public int CompareTo(WordCount other)
        {
            if (other == null)
            {
                return 1;
            }

            return other.Count.CompareTo(Count);
        }

        public override string ToString()
        {
            return string.Format("Word: {0}, Count: {1}", Word, Count);
        }
    }
}
