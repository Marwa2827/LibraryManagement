namespace LibraryManagement.Models.Entities
{
    public class BookAuthor
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        // Navigation Properties
        public Book Book { get; set; } = null!;

        public Author Author { get; set; } = null!;
    }
}
