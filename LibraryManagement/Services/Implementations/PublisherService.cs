using LibraryManagement.Data;
using LibraryManagement.DTOs.Publishers;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Implementations
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;

        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PublisherResponseDto>> GetAllAsync()
        {
            return await _context.Publishers
                .AsNoTracking()
                .Select(p => new PublisherResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email
                })
                .ToListAsync();
        }

        public async Task<PublisherResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Publishers
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new PublisherResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string? Error, PublisherResponseDto? Publisher)>
            CreateAsync(PublisherDto dto)
        {
            var exists = await _context.Publishers
                .AnyAsync(p => p.Name == dto.Name);

            if (exists)
            {
                return (
                    false,
                    "A publisher with this name already exists.",
                    null);
            }

            var publisher = new Publisher
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email
            };

            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return (
                true,
                null,
                await GetByIdAsync(publisher.Id));
        }

        public async Task<(bool Success, string? Error)>
            UpdateAsync(int id, PublisherDto dto)
        {
            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(p => p.Id == id);

            if (publisher == null)
                return (false, "Publisher not found.");

            var exists = await _context.Publishers
                .AnyAsync(p =>
                    p.Name == dto.Name &&
                    p.Id != id);

            if (exists)
            {
                return (
                    false,
                    "A publisher with this name already exists.");
            }

            publisher.Name = dto.Name;
            publisher.Address = dto.Address;
            publisher.Phone = dto.Phone;
            publisher.Email = dto.Email;

            await _context.SaveChangesAsync();

            return (true, null);
        }

        public async Task<(bool Success, string? Error)>
            DeleteAsync(int id)
        {
            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(p => p.Id == id);

            if (publisher == null)
                return (false, "Publisher not found.");

            var hasBooks = await _context.Books
                .AnyAsync(b => b.PublisherId == id);

            if (hasBooks)
            {
                return (
                    false,
                    "Cannot delete a publisher assigned to books.");
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return (true, null);
        }
    }
}
