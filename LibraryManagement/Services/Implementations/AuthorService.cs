using LibraryManagement.Data;
using LibraryManagement.DTOs.Authors;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorResponseDto>> GetAllAsync()
        {
            return await _context.Authors
                .AsNoTracking()
                .Select(a => new AuthorResponseDto
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<AuthorResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Authors
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(a => new AuthorResponseDto
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string? Error, AuthorResponseDto? Author)>
            CreateAsync(AuthorDto dto)
        {
            var exists = await _context.Authors
                .AnyAsync(a => a.Name == dto.Name);

            if (exists)
            {
                return (false, "An author with this name already exists.", null);
            }

            var author = new Author
            {
                Name = dto.Name,
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            var result = await GetByIdAsync(author.Id);

            return (true, null, result);
        }

        public async Task<(bool Success, string? Error)>
            UpdateAsync(int id, AuthorDto dto)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                return (false, "Author not found.");
            }

            var exists = await _context.Authors
                .AnyAsync(a =>
                    a.Name == dto.Name &&
                    a.Id != id);

            if (exists)
            {
                return (false, "An author with this name already exists.");
            }

            author.Name = dto.Name;

            await _context.SaveChangesAsync();

            return (true, null);
        }

        public async Task<(bool Success, string? Error)>
            DeleteAsync(int id)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                return (false, "Author not found.");
            }

            var hasBooks = await _context.BookAuthors
                .AnyAsync(ba => ba.AuthorId == id);

            if (hasBooks)
            {
                return (
                    false,
                    "Cannot delete an author assigned to books.");
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return (true, null);
        }
    }
}
