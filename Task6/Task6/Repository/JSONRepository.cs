using System.Text.Json;
using Task6.Interfaces;

namespace Task6.Repository
{
    public class JSONRepository : IRepository
    {
        public void Save(Catalog catalog, string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var authors = catalog.GetAuthors();

            foreach (var author in authors)
            {
                var booksByAuthor = catalog.GetBooksByAuthor(author);
                var authorData = new AuthorData { Author = author, Books = booksByAuthor.ToList() };

                string fileName = $"{author.FirstName}_{author.LastName}.json";
                string filePath = Path.Combine(directoryPath, fileName);

                string json = JsonSerializer.Serialize(authorData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
        }

        public Catalog Load(string directoryPath)
        {
            Catalog catalog = new Catalog();

            var jsonFiles = Directory.GetFiles(directoryPath, "*.json");
            foreach (var file in jsonFiles)
            {
                string json = File.ReadAllText(file);
                var authorData = JsonSerializer.Deserialize<AuthorData>(json);

                foreach (var book in authorData.Books)
                {
                    catalog.AddBook(book.ISBN, book);
                }
            }

            return catalog;
        }

        private class AuthorData
        {
            public Author Author { get; set; }
            public List<Book> Books { get; set; }
        }
    }
}
