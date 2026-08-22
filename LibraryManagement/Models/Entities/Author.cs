using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<BookAuthor> BookAuthors { get; set; }
            = new List<BookAuthor>();
    }
}
