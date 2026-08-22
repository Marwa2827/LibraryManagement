using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs.Categories
{
    public class CategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }
    }
}
