using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var expected = new string[] {"Hello", "my", "dear", "friend"};

            //Act
            TextParse text = new TextParse(source);

            //Assert
            var actual = text.Words;
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
