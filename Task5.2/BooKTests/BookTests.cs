namespace Task5._2.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void TestBookInitialization_ValidData()
        {
            var authors = new HashSet<string> { "Author1", "Author2" };
            var book = new Book("Sample Title", "123-4-56-789012-3", new DateOnly(2020, 1, 1), authors);

            Assert.AreEqual("Sample Title", book.Title);
            Assert.AreEqual("1234567890123", book.ISBN);
            Assert.AreEqual(new DateOnly(2020, 1, 1), book.PublicationDate);
            CollectionAssert.AreEquivalent(new List<string> { "Author1", "Author2" }, new List<string>(book.Authors));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Title can't be null or empty.")]
        public void TestBookInitialization_EmptyTitle()
        {
            var authors = new HashSet<string> { "Author1" };
            var book = new Book("", "123-4-56-789012-3", new DateOnly(2020, 1, 1), authors);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid ISBN.")]
        public void TestBookInitialization_InvalidIsbnFormat()
        {
            var authors = new HashSet<string> { "Author1" };
            var book = new Book("Sample Title", "123-456-789012-3", new DateOnly(2020, 1, 1), authors);
        }

        [TestMethod]
        public void TestBookInitialization_NullAuthors()
        {
            var book = new Book("Sample Title", "123-4-56-789012-3", new DateOnly(2020, 1, 1), null);

            Assert.AreEqual("Sample Title", book.Title);
            Assert.AreEqual("1234567890123", book.ISBN);
            Assert.AreEqual(new DateOnly(2020, 1, 1), book.PublicationDate);
            Assert.AreEqual(0, book.Authors.Count);
        }
    }
}
