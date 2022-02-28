using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using WordCounterLibrary;


namespace WordCounterLibraryTests
{
    [TestClass]
    public class WordCounterTests
    {
        [TestMethod]
        public void ReturnWordsBeforeText()
        {
            //Arrange
            string source = "Hello, my dear friend.";
            var expected = new string[] { "Hello", "my", "dear", "friend" };

            //Act
            TextParse text = new TextParse(source);
            
            var actual = new List<string>();

            for (int i = 0; i < text.Count; i++)
            {
                actual.Add(text[i]);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }


        [DataTestMethod]
        [DynamicData(nameof(GetTestStrings), DynamicDataSourceType.Method)]
        public void ReturnPhrase(int quntilytyPharase, IWordIndexer source, IEnumerable<WordCount> expected)
        {
            //Arrange
            WordAnalysis wordAnalysis = new WordAnalysis(source, quntilytyPharase);
            
            //Act
            var actual = wordAnalysis.GetTopWordPharse();

            //Assert
            CollectionAssert.AreEqual(actual.ToArray(), expected.ToArray());
        }

        private static IEnumerable<object[]> GetTestStrings()
        {
            yield return new object[] 
            { 
                1, 
                new TextParse("Hello, my dear friend! Hello"), 
                new List<WordCount>()
                { 
                    new WordCount() { Word = "hello", Count = 2 },
                    new WordCount() { Word = "my", Count = 1 },
                    new WordCount() { Word = "dear", Count = 1 },
                    new WordCount() { Word = "friend", Count = 1 },
                } 
            };

            yield return new object[]
            {
                2,
                new TextParse("Hello, my dear friend! My dear friend, I am fine"),
                new List<WordCount>()
                {
                    new WordCount() { Word = "my dear", Count = 2 },
                    new WordCount() { Word = "dear friend", Count = 2 },
                    new WordCount() { Word = "hello my", Count = 1 },
                    new WordCount() { Word = "friend my", Count = 1 },
                    new WordCount() { Word = "friend i", Count = 1 },
                    new WordCount() { Word = "i am", Count = 1 },
                    new WordCount() { Word = "am fine", Count = 1 },
                }
            };

            yield return new object[]
            {
                3,
                new TextParse("Hello, my dear friend! My dear friend, I am fine"),
                new List<WordCount>()
                {
                    new WordCount() { Word = "my dear friend", Count = 2 },
                    new WordCount() { Word = "hello my dear", Count = 1 },
                    new WordCount() { Word = "dear friend my", Count = 1 },
                    new WordCount() { Word = "friend my dear", Count = 1 },
                    new WordCount() { Word = "dear friend i", Count = 1 },
                    new WordCount() { Word = "friend i am", Count = 1 },
                    new WordCount() { Word = "i am fine", Count = 1 },
                }
            };

        }
    }
}
