using Task6.Interfaces;
using Task6.Repository;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("John", "Doe", new DateOnly(1970, 5, 20));
            Author author2 = new Author("Jane", "Smith", new DateOnly(1980, 11, 15));
            Author author3 = new Author("Emily", "Johnson", new DateOnly(1990, 2, 10));

            Book book1 = new Book("C# Programming", "123-4-56-789012-3", new DateOnly(2020, 1, 1), new List<Author> { author1, author2 });
            Book book2 = new Book("Advanced C#", "123-4-56-789013-3", new DateOnly(2021, 2, 1), new List<Author> { author1 });
            Book book3 = new Book("Introduction to Programming", "1234567890143", new DateOnly(2019, 3, 1), new List<Author> { author2 });
            Book book4 = new Book("Data Structures", "123-4-56-789015-3", new DateOnly(2018, 4, 1), new List<Author> { author3 });

            Catalog catalog = new Catalog();
            catalog.AddBook(book1.ISBN, book1);
            catalog.AddBook(book2.ISBN, book2);
            catalog.AddBook(book3.ISBN, book3);
            catalog.AddBook(book4.ISBN, book4);

            IRepository xmlRepository = new XMLRepository();
            string xmlFilePath = "catalog.xml";
            xmlRepository.Save(catalog, xmlFilePath);

            Catalog loadedCatalogFromXml = xmlRepository.Load(xmlFilePath);
            Console.WriteLine("Catalog from XML:");
            foreach (var title in loadedCatalogFromXml.GetBookTitles())
            {
                Console.WriteLine(title);
            }

            IRepository jsonRepository = new JSONRepository();
            string jsonDirectoryPath = "catalog_json";
            jsonRepository.Save(catalog, jsonDirectoryPath);

            Catalog loadedCatalogFromJson = jsonRepository.Load(jsonDirectoryPath);
            Console.WriteLine("Catalog from JSON:");
            foreach (var title in loadedCatalogFromJson.GetBookTitles())
            {
                Console.WriteLine(title);
            }
        }
    }
}
