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
            var actual = text.Words;
            
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }


        [DataTestMethod]
        [DynamicData(nameof(GetTestStrings), DynamicDataSourceType.Method)]
        public void ReturnPhrase(int quntilytyPharase, string[] source, IEnumerable<WordCount> expected)
        {
            //Arrange
            WordAnalysis wordAnalysis = new WordAnalysis(source, quntilytyPharase);
            
            //Act
            var actual = wordAnalysis.GetTopWordPharse();

            var expected1 = expected.ToArray();
            var actual1 = actual.ToArray();

            //Assert
            CollectionAssert.AreEqual(expected1, actual1);
        }

        private static IEnumerable<object?[]> GetTestStrings()
        {
            yield return new object?[] 
            { 
                1, 
                new string[]{ "Hello", "my", "dear", "friend" }, 
                new List<WordCount>()
                { 
                    new WordCount() { Word = "hello", Count = 1 },
                    new WordCount() { Word = "my", Count = 1 },
                    new WordCount() { Word = "dear", Count = 1 },
                    new WordCount() { Word = "friend", Count = 1 },
                } 
            };
            
        }
    }
}
