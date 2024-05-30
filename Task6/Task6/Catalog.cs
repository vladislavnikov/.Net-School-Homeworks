namespace Task6
{
    public class Catalog
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        public void AddBook(string isbn, Book book)
        {
            string formattedIsbn = Book.IsbnCombine(isbn);
            if (!books.ContainsKey(formattedIsbn))
            {
                books[formattedIsbn] = book;
            }
            else
            {
                throw new ArgumentException("Book with the same ISBN already exists in the catalog.");
            }
        }

        public bool TryGetBook(string isbn, out Book book)
        {
            string formattedIsbn = Book.IsbnCombine(isbn);
            return books.TryGetValue(formattedIsbn, out book);
        }

        public Book GetBook(string isbn)
        {
            string formattedIsbn = Book.IsbnCombine(isbn);
            return books.ContainsKey(formattedIsbn) ? books[formattedIsbn] : null;
        }

        public IEnumerable<string> GetBookTitles()
        {
            return books.Values.Select(b => b.Title).OrderBy(t => t);
        }

        public IEnumerable<Book> GetBooksByAuthor(Author author)
        {
            return books.Values
                .Where(b => b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate);
        }

        public IEnumerable<(string Author, int BookCount)> GetAuthorBookCounts()
        {
            return books.Values
                .SelectMany(b => b.Authors)
                .GroupBy(author => $"{author.FirstName} {author.LastName}")
                .Select(group => (Author: group.Key, BookCount: group.Count()));
        }

        public IEnumerable<Author> GetAuthors()
        {
            return books.Values.SelectMany(b => b.Authors).Distinct();
        }
    }
}
