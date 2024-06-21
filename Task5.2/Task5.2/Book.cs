﻿
using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace Task5._2
{
    public class Book
    {
        private static readonly List<string> IsbnRegex = new List<string>
        {
            @"^\d{3}-\d-\d{2}-\d{6}-\d$",
            @"^\d{13}$"
        };

        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public DateOnly? PublicationDate { get; }
        public HashSet<string> Authors { get; } = new HashSet<string>();

        public Book(string title, string isbn, DateOnly? date, IEnumerable<string> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title can't be null or empty.");
            }

            if (!IsISBNCorrect(isbn))
            {
                throw new ArgumentException("Invalid ISBN.");
            }

            Title = title;
            ISBN = IsbnCombine(isbn);
            PublicationDate = date;
            if (authors != null)
            {
                Authors = new HashSet<string>(authors);
            }
        }

        public static string IsbnCombine(string isbn)
        {
            return isbn.Replace("-", "");
        }

        public static bool IsISBNCorrect(string isbn)
        {
            foreach (string pattern in IsbnRegex)
            {
                var regex = new Regex(pattern);
                if (regex.IsMatch(isbn))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
