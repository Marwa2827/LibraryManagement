using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }
            = new List<Category>();

        // Navigation Property
        public ICollection<Book> Books { get; set; }
            = new List<Book>();
    }
}
