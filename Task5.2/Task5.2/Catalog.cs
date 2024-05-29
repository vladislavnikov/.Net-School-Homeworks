using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2
{
    public class Catalog
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        public void AddBook(string isbn, Book book)
        {
            string formattedIsbn = Book.IsbnCombine(isbn);
            books[formattedIsbn] = book;
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

         public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return books.Values
                .Where(b => b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate);
        }

        public IEnumerable<(string Author, int BookCount)> GetAuthorBookCounts()
        {
            return books.Values
                .SelectMany(b => b.Authors)
                .GroupBy(author => author)
                .Select(group => (Author: group.Key, BookCount: group.Count()));
        }
    }
}
