using LibraryManagement.Data;
using LibraryManagement.DTOs.Categories;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentCategoryId = c.ParentCategoryId,
                    ParentCategoryName =
                        c.ParentCategory != null
                            ? c.ParentCategory.Name
                            : null
                })
                .ToListAsync();
        }

        public async Task<CategoryResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentCategoryId = c.ParentCategoryId,
                    ParentCategoryName =
                        c.ParentCategory != null
                            ? c.ParentCategory.Name
                            : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string? Error, CategoryResponseDto? Category)>
            CreateAsync(CategoryDto dto)
        {
            var exists = await _context.Categories
                .AnyAsync(c => c.Name == dto.Name);

            if (exists)
            {
                return (
                    false,
                    "A category with this name already exists.",
                    null);
            }

            if (dto.ParentCategoryId.HasValue)
            {
                var parentExists = await _context.Categories
                    .AnyAsync(c => c.Id == dto.ParentCategoryId.Value);

                if (!parentExists)
                {
                    return (
                        false,
                        "Parent category not found.",
                        null);
                }
            }

            var category = new Category
            {
                Name = dto.Name,
                ParentCategoryId = dto.ParentCategoryId
            };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return (
                true,
                null,
                await GetByIdAsync(category.Id));
        }

        public async Task<(bool Success, string? Error)>
            UpdateAsync(int id, CategoryDto dto)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return (false, "Category not found.");

            if (dto.ParentCategoryId == id)
            {
                return (
                    false,
                    "A category cannot be its own parent.");
            }

            var exists = await _context.Categories
                .AnyAsync(c =>
                    c.Name == dto.Name &&
                    c.Id != id);

            if (exists)
            {
                return (
                    false,
                    "A category with this name already exists.");
            }

            if (dto.ParentCategoryId.HasValue)
            {
                var parentExists = await _context.Categories
                    .AnyAsync(c =>
                        c.Id == dto.ParentCategoryId.Value);

                if (!parentExists)
                {
                    return (
                        false,
                        "Parent category not found.");
                }
            }

            category.Name = dto.Name;
            category.ParentCategoryId = dto.ParentCategoryId;

            await _context.SaveChangesAsync();

            return (true, null);
        }

        public async Task<(bool Success, string? Error)>
            DeleteAsync(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return (false, "Category not found.");

            var hasBooks = await _context.Books
                .AnyAsync(b => b.CategoryId == id);

            if (hasBooks)
            {
                return (
                    false,
                    "Cannot delete a category assigned to books.");
            }

            var hasChildren = await _context.Categories
                .AnyAsync(c => c.ParentCategoryId == id);

            if (hasChildren)
            {
                return (
                    false,
                    "Cannot delete a category that has subcategories.");
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return (true, null);
        }
    }
}
