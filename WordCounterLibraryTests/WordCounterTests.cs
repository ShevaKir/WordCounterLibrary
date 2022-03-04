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
        #region Data Test
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

        private static IEnumerable<object[]> GetTestTextForLengthPhrase()
        {
            yield return new object[]
            {
                1,
                new TextParse("Hello, my dear friend!"),
                4
            };
            yield return new object[]
            {
                2,
                new TextParse("Hello, my dear friend!"),
                3
            };
            yield return new object[]
            {
                3,
                new TextParse("Hello, my dear friend!"),
                2
            };
        }

        private static IEnumerable<object[]> GetTestTextForThrowArgumentOutOfRangeException()
        {
            yield return new object[]
            {
                1,
                new TextParse("Hello, my dear friend!"),
                5
            };
            yield return new object[]
            {
                2,
                new TextParse("Hello, my dear friend!"),
                4
            };
            yield return new object[]
            {
                3,
                new TextParse("Hello, my dear friend!"),
                3
            };
        }

        #endregion

        #region Test TextParse

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

        [TestMethod]
        [DataRow(0, "Hello")]
        [DataRow(1, "my")]
        [DataRow(2, "dear")]
        [DataRow(3, "friend")]
        public void Indexer_GetElementAtPosition_ShouldReturnString(int index, string expected)
        {
            //Arrange
            var source = "Hello, my dear friend";

            //Act
            TextParse text = new TextParse(source);
            var actual = text[index];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Hello", 1)]
        [DataRow("Hello my", 2)]
        [DataRow("Hello, my dear", 3)]
        [DataRow("Hello, my dear friend", 4)]
        public void Length_Get_ShouldReturnCorrectValue(string source, int expected)
        {
            //Act
            TextParse text = new TextParse(source);
            var actual = text.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Failure Test TextParse

        [TestMethod]
        public void CreateTextParse_WithNullString_ShoulThrowArgumentNullException()
        {
            //Arrange
            string source = null;

            // Act and assert
            Assert.ThrowsException<System.ArgumentNullException>(() => new TextParse(source));
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(4)]
        public void Indexer_SetElementOutOfRange_ShouldThrowArgumentException(int index)
        {
            //Arrange
            TextParse text = new TextParse("Hello, my dear friend");

            //Act and assert
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => text[index]);
        }

        #endregion

        #region Test WordAnalysis

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

        [TestMethod]
        [DynamicData(nameof(GetTestTextForLengthPhrase), DynamicDataSourceType.Method)]
        public void LengthPhrase_Get_ShouldReturnCorrectValue(int quntilytyPharase, IWordIndexer source, int expected)
        {
            //Arrange
            WordAnalysis wordAnalysis = new WordAnalysis(source, quntilytyPharase);

            //Act
            var actual = wordAnalysis.CountPhrase;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Failure Test WordAnalysis

        [TestMethod]
        public void CreateWordAnalysis_WithNullIWordIndexer_ShoulThrowNullReferenceException()
        {
            //Arrange
            IWordIndexer wordIndexer = null;

            //Act and assert
            Assert.ThrowsException<System.NullReferenceException>(() => new WordAnalysis(wordIndexer));
        }

        [TestMethod]
        public void CreateWordAnalysis_WithZero_ShoulThrowLessThanOneWordException()
        {
            //Arrange
            int numberEntries = 0;

            //Act and assert
            Assert.ThrowsException<WordCounterLibrary.LessThanOneWordException>(() => 
                new WordAnalysis(new TextParse("Hello, my dear friend"), numberEntries));
        }

        [TestMethod]
        public void GetTopWords_WithLessZero_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            IWordIndexer words = new TextParse("Hello, my dear friend");
            int topWords = -1;

            //Act
            WordAnalysis wordAnalysis = new WordAnalysis(words);

            //Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => wordAnalysis.GetTopWordPharse(topWords));
        }

        [TestMethod]
        [DynamicData(nameof(GetTestTextForThrowArgumentOutOfRangeException), DynamicDataSourceType.Method)]
        public void GetTopWords_WithMoreThanCountPhrase_ShouldThrowArgumentOutOfRangeException
                (int numberEntries, TextParse source, int topWords)
        {
            //Arrange
            WordAnalysis wordAnalysis = new WordAnalysis(source, numberEntries);

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => wordAnalysis.GetTopWordPharse(topWords));
        }

        #endregion
    }
}
