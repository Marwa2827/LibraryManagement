namespace LibraryManagement.DTOs.Categories
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        public string? ParentCategoryName { get; set; }
    }
}
