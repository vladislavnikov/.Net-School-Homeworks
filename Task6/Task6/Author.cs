namespace Task6
{
    public class Author
    {
        public Author(string fName, string lName, DateOnly bDate)
        {
            FirstName = fName;
            LastName = lName;
            BirthDate = bDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
