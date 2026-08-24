using LibraryManagement.Data;
using LibraryManagement.DTOs.Books;
using LibraryManagement.Models.Entities;
using LibraryManagement.Models.Enums;
using LibraryManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public BookService(ApplicationDbContext context,
    IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<BookResponseDto>> GetAllAsync()
        {
            var books = await _context.Books
                .AsNoTracking()
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .ToListAsync();

            return books.Select(b => new BookResponseDto
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Edition = b.Edition,
                Summary = b.Summary,
                Language = b.Language,
                PublicationYear = b.PublicationYear,

                CoverImageUrl = _fileService.GetBookCoverUrl(b.CoverImage),

                Status = b.Status,

                PublisherId = b.PublisherId,
                PublisherName = b.Publisher.Name,

                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name,

                AuthorIds = b.BookAuthors
                    .Select(ba => ba.AuthorId)
                    .ToList(),

                AuthorNames = b.BookAuthors
                    .Select(ba => ba.Author.Name)
                    .ToList()
            }).ToList();
        }

        public async Task<BookResponseDto?> GetByIdAsync(int id)
        {
            var book = await _context.Books
                .AsNoTracking()
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            return new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                Edition = book.Edition,
                Summary = book.Summary,
                Language = book.Language,
                PublicationYear = book.PublicationYear,

                CoverImageUrl = _fileService.GetBookCoverUrl(book.CoverImage),

                Status = book.Status,

                PublisherId = book.PublisherId,
                PublisherName = book.Publisher.Name,

                CategoryId = book.CategoryId,
                CategoryName = book.Category.Name,

                AuthorIds = book.BookAuthors
                    .Select(ba => ba.AuthorId)
                    .ToList(),

                AuthorNames = book.BookAuthors
                    .Select(ba => ba.Author.Name)
                    .ToList()
            };
        }

        public async Task<(bool Success, string? Error, BookResponseDto? Book)>
            CreateAsync(CreateBookDto dto)
        {
            // Check ISBN
            var isbnExists = await _context.Books
                .AnyAsync(b => b.ISBN == dto.ISBN);

            if (isbnExists)
            {
                return (false, "A book with this ISBN already exists.", null);
            }

            // Check Publisher
            var publisherExists = await _context.Publishers
                .AnyAsync(p => p.Id == dto.PublisherId);

            if (!publisherExists)
            {
                return (false, "Publisher not found.", null);
            }

            // Check Category
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == dto.CategoryId);

            if (!categoryExists)
            {
                return (false, "Category not found.", null);
            }

            // Check Authors
            var authorIds = dto.AuthorIds.Distinct().ToList();

            if (!authorIds.Any())
            {
                return (false, "At least one author is required.", null);
            }

            var existingAuthorIds = await _context.Authors
                .Where(a => authorIds.Contains(a.Id))
                .Select(a => a.Id)
                .ToListAsync();

            if (existingAuthorIds.Count != authorIds.Count)
            {
                return (false, "One or more authors were not found.", null);
            }

            string? coverFileName = null;

            if (dto.CoverImage != null)
            {
                coverFileName =
                    await _fileService.SaveBookCoverAsync(
                        dto.CoverImage);
            }

            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                Edition = dto.Edition,
                Summary = dto.Summary,
                Language = dto.Language,
                PublicationYear = dto.PublicationYear,
                CoverImage = coverFileName,
                PublisherId = dto.PublisherId,
                CategoryId = dto.CategoryId
            };

            foreach (var authorId in authorIds)
            {
                book.BookAuthors.Add(new BookAuthor
                {
                    AuthorId = authorId
                });
            }

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            var result = await GetByIdAsync(book.Id);

            return (true, null, result);
        }

        public async Task<(bool Success, string? Error)>
    UpdateAsync(int id, UpdateBookDto dto)
        {
            var book = await _context.Books
                .Include(b => b.BookAuthors)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return (false, "Book not found.");
            }

            var isbnExists = await _context.Books
                .AnyAsync(b => b.ISBN == dto.ISBN && b.Id != id);

            if (isbnExists)
            {
                return (false, "A book with this ISBN already exists.");
            }

            var publisherExists = await _context.Publishers
                .AnyAsync(p => p.Id == dto.PublisherId);

            if (!publisherExists)
            {
                return (false, "Publisher not found.");
            }

            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == dto.CategoryId);

            if (!categoryExists)
            {
                return (false, "Category not found.");
            }

            var authorIds = dto.AuthorIds
                .Distinct()
                .ToList();

            if (!authorIds.Any())
            {
                return (false, "At least one author is required.");
            }

            var existingAuthorIds = await _context.Authors
                .Where(a => authorIds.Contains(a.Id))
                .Select(a => a.Id)
                .ToListAsync();

            if (existingAuthorIds.Count != authorIds.Count)
            {
                return (false, "One or more authors were not found.");
            }

            // Keep old cover image
            var oldCoverImage = book.CoverImage;

            // Update book data
            book.Title = dto.Title;
            book.ISBN = dto.ISBN;
            book.Edition = dto.Edition;
            book.Summary = dto.Summary;
            book.Language = dto.Language;
            book.PublicationYear = dto.PublicationYear;
            book.PublisherId = dto.PublisherId;
            book.CategoryId = dto.CategoryId;

            // Update cover only if a new image was uploaded
            if (dto.CoverImage != null)
            {
                var newCoverImage =
                    await _fileService.SaveBookCoverAsync(dto.CoverImage);

                book.CoverImage = newCoverImage;
            }

            // Update Authors
            _context.BookAuthors.RemoveRange(book.BookAuthors);

            foreach (var authorId in authorIds)
            {
                book.BookAuthors.Add(new BookAuthor
                {
                    BookId = book.Id,
                    AuthorId = authorId
                });
            }

            await _context.SaveChangesAsync();

            // Delete old image after successful DB update
            if (dto.CoverImage != null &&
                !string.IsNullOrWhiteSpace(oldCoverImage))
            {
                _fileService.DeleteBookCover(oldCoverImage);
            }

            return (true, null);
        }

        public async Task<(bool Success, string? Error)>
    DeleteAsync(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return (false, "Book not found.");
            }

            if (book.Status == Models.Enums.BookStatus.Borrowed)
            {
                return (false, "Cannot delete a borrowed book.");
            }

            var hasBorrowingHistory = await _context.Borrowings
                .AnyAsync(b => b.BookId == id);

            if (hasBorrowingHistory)
            {
                return (
                    false,
                    "Cannot delete a book with borrowing history.");
            }

            var coverImage = book.CoverImage;

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            if (!string.IsNullOrWhiteSpace(coverImage))
            {
                _fileService.DeleteBookCover(coverImage);
            }

            return (true, null);
        }
        public async Task<List<BookResponseDto>> SearchAsync(
    string? name,
    int? authorId,
    int? categoryId)
        {
            var query = _context.Books
                .AsNoTracking()
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();

                query = query.Where(b =>
                    b.Title.Contains(name));
            }

            if (authorId.HasValue)
            {
                query = query.Where(b =>
                    b.BookAuthors.Any(
                        ba => ba.AuthorId == authorId.Value));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(b =>
                    b.CategoryId == categoryId.Value);
            }

            var books = await query.ToListAsync();

            return books.Select(b => new BookResponseDto
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Edition = b.Edition,
                Summary = b.Summary,
                Language = b.Language,
                PublicationYear = b.PublicationYear,

                CoverImageUrl =
                    _fileService.GetBookCoverUrl(b.CoverImage),

                Status = b.Status,

                PublisherId = b.PublisherId,
                PublisherName = b.Publisher.Name,

                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name,

                AuthorIds = b.BookAuthors
                    .Select(ba => ba.AuthorId)
                    .ToList(),

                AuthorNames = b.BookAuthors
                    .Select(ba => ba.Author.Name)
                    .ToList()

            }).ToList();
        }


        public async Task<List<BookResponseDto>> GetByStatusAsync(
            BookStatus status)
        {
            var books = await _context.Books
                .AsNoTracking()
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Where(b => b.Status == status)
                .ToListAsync();

            return books.Select(b => new BookResponseDto
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Edition = b.Edition,
                Summary = b.Summary,
                Language = b.Language,
                PublicationYear = b.PublicationYear,

                CoverImageUrl =
                    _fileService.GetBookCoverUrl(b.CoverImage),

                Status = b.Status,

                PublisherId = b.PublisherId,
                PublisherName = b.Publisher.Name,

                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name,

                AuthorIds = b.BookAuthors
                    .Select(ba => ba.AuthorId)
                    .ToList(),

                AuthorNames = b.BookAuthors
                    .Select(ba => ba.Author.Name)
                    .ToList()

            }).ToList();
        }

    }
}
