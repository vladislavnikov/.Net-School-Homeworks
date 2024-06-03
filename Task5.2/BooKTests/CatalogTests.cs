
namespace Task5._2.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestCatalogAddAndRetrieveBook_ValidIsbn()
        {
            var catalog = new Catalog();
            var book = new Book("Sample Title", "123-4-56-789012-3", new DateOnly(2020, 1, 1), new HashSet<string> { "Author1" });

            catalog.AddBook("123-4-56-789012-3", book);

            Assert.IsTrue(catalog.TryGetBook("1234567890123", out var retrievedBook));
            Assert.AreEqual(book, retrievedBook);

            Assert.IsTrue(catalog.TryGetBook("123-4-56-789012-3", out retrievedBook));
            Assert.AreEqual(book, retrievedBook);
        }

        [TestMethod]
        public void TestCatalogAddAndRetrieveBook_InvalidIsbnFormat()
        {
            var catalog = new Catalog();
            var book = new Book("Sample Title", "1234567890123", new DateOnly(2020, 1, 1), new HashSet<string> { "Author1" });

            catalog.AddBook("1234567890123", book);

            Assert.IsTrue(catalog.TryGetBook("123-4-56-789012-3", out var retrievedBook));
            Assert.AreEqual(book, retrievedBook);

            Assert.IsTrue(catalog.TryGetBook("1234567890123", out retrievedBook));
            Assert.AreEqual(book, retrievedBook);
        }

        [TestMethod]
        public void TestGetBookTitles_SortedAlphabetically()
        {
            var catalog = new Catalog();
            catalog.AddBook("123-4-56-789012-3", new Book("Zeta", "123-4-56-789012-3", null, null));
            catalog.AddBook("123-4-56-789013-3", new Book("Alpha", "123-4-56-789013-3", null, null));

            var titles = catalog.GetBookTitles().ToArray();
            CollectionAssert.AreEqual(new[] { "Alpha", "Zeta" }, titles);
        }

        [TestMethod]
        public void TestGetBooksByAuthor_SortedByPublicationDate()
        {
            var catalog = new Catalog();
            var book1 = new Book("Book1", "123-4-56-789012-3", new DateOnly(2020, 1, 1), new HashSet<string> { "Author1" });
            var book2 = new Book("Book2", "123-4-56-789013-3", new DateOnly(2019, 1, 1), new HashSet<string> { "Author1" });

            catalog.AddBook("123-4-56-789012-3", book1);
            catalog.AddBook("123-4-56-789013-3", book2);

            var books = catalog.GetBooksByAuthor("Author1").ToArray();
            CollectionAssert.AreEqual(new[] { book2, book1 }, books);
        }

        [TestMethod]
        public void TestGetAuthorBookCounts()
        {
            var catalog = new Catalog();
            var book1 = new Book("Book1", "123-4-56-789012-3", null, new HashSet<string> { "Author1", "Author2" });
            var book2 = new Book("Book2", "123-4-56-789013-3", null, new HashSet<string> { "Author1" });

            catalog.AddBook("123-4-56-789012-3", book1);
            catalog.AddBook("123-4-56-789013-3", book2);

            var authorCounts = catalog.GetAuthorBookCounts().ToArray();
            CollectionAssert.AreEquivalent(new[] { ("Author1", 2), ("Author2", 1) }, authorCounts);
        }
    }
}
