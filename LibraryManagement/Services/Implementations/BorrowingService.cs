using LibraryManagement.Data;
using LibraryManagement.DTOs.Borrowings;
using LibraryManagement.Models.Enums;
using LibraryManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Implementations
{
    public class BorrowingService : IBorrowingService
    {
        private readonly ApplicationDbContext _context;

        public BorrowingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BorrowingResponseDto>> GetAllAsync()
        {
            return await _context.Borrowings
                .AsNoTracking()
                .Include(b => b.Book)
                .Include(b => b.Member)
                .Include(b => b.BorrowedByUser)
                .Include(b => b.ReturnedByUser)
                .Select(b => new BorrowingResponseDto
                {
                    Id = b.Id,

                    BookId = b.BookId,
                    BookTitle = b.Book.Title,
                    ISBN = b.Book.ISBN,

                    MemberId = b.MemberId,
                    MemberCode = b.Member.MemberCode,
                    MemberName = b.Member.FullName,

                    BorrowedByUserId = b.BorrowedByUserId,
                    BorrowedByUserName = b.BorrowedByUser.FullName,

                    BorrowedAt = b.BorrowedAt,
                    DueDate = b.DueDate,

                    ReturnedAt = b.ReturnedAt,

                    ReturnedByUserId = b.ReturnedByUserId,
                    ReturnedByUserName =
                        b.ReturnedByUser != null
                            ? b.ReturnedByUser.FullName
                            : null,

                    Status = b.Status
                })
                .ToListAsync();
        }

        public async Task<BorrowingResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Borrowings
                .AsNoTracking()
                .Where(b => b.Id == id)
                .Select(b => new BorrowingResponseDto
                {
                    Id = b.Id,

                    BookId = b.BookId,
                    BookTitle = b.Book.Title,
                    ISBN = b.Book.ISBN,

                    MemberId = b.MemberId,
                    MemberCode = b.Member.MemberCode,
                    MemberName = b.Member.FullName,

                    BorrowedByUserId = b.BorrowedByUserId,
                    BorrowedByUserName = b.BorrowedByUser.FullName,

                    BorrowedAt = b.BorrowedAt,
                    DueDate = b.DueDate,

                    ReturnedAt = b.ReturnedAt,

                    ReturnedByUserId = b.ReturnedByUserId,
                    ReturnedByUserName =
                        b.ReturnedByUser != null
                            ? b.ReturnedByUser.FullName
                            : null,

                    Status = b.Status
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string? Error, BorrowingResponseDto? Borrowing)>
            BorrowAsync(
                CreateBorrowingDto dto,
                int userId)
        {
            // 1. Check user
            var userExists = await _context.Users
                .AnyAsync(u =>
                    u.Id == userId &&
                    u.IsActive);

            if (!userExists)
            {
                return (
                    false,
                    "Borrowing user was not found or is inactive.",
                    null);
            }

            // 2. Check member
            var member = await _context.Members
                .FirstOrDefaultAsync(m =>
                    m.Id == dto.MemberId);

            if (member == null)
            {
                return (
                    false,
                    "Member not found.",
                    null);
            }

            if (!member.IsActive)
            {
                return (
                    false,
                    "Member is inactive.",
                    null);
            }

            // 3. Check book
            var book = await _context.Books
                .FirstOrDefaultAsync(b =>
                    b.Id == dto.BookId);

            if (book == null)
            {
                return (
                    false,
                    "Book not found.",
                    null);
            }

            // 4. Check book availability
            if (book.Status != BookStatus.Available)
            {
                return (
                    false,
                    "Book is currently borrowed.",
                    null);
            }

            // 5. Validate DueDate
            var now = DateTime.UtcNow;

            if (dto.DueDate <= now)
            {
                return (
                    false,
                    "Due date must be in the future.",
                    null);
            }

            // 6. Extra protection against duplicate active borrowing
            var activeBorrowingExists =
                await _context.Borrowings.AnyAsync(b =>
                    b.BookId == dto.BookId &&
                    b.Status == BorrowingStatus.Borrowed);

            if (activeBorrowingExists)
            {
                return (
                    false,
                    "Book already has an active borrowing.",
                    null);
            }

            // 7. Create borrowing
            var borrowing = new Models.Entities.Borrowing
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                BorrowedByUserId = userId,
                BorrowedAt = now,
                DueDate = dto.DueDate,
                Status = BorrowingStatus.Borrowed
            };

            // 8. Update book status
            book.Status = BookStatus.Borrowed;

            _context.Borrowings.Add(borrowing);

            await _context.SaveChangesAsync();

            return (
                true,
                null,
                await GetByIdAsync(borrowing.Id));
        }

        public async Task<(bool Success, string? Error)>
            ReturnAsync(
                int borrowingId,
                int userId)
        {
            // 1. Check user
            var userExists = await _context.Users
                .AnyAsync(u =>
                    u.Id == userId &&
                    u.IsActive);

            if (!userExists)
            {
                return (
                    false,
                    "Returning user was not found or is inactive.");
            }

            // 2. Get borrowing
            var borrowing = await _context.Borrowings
                .Include(b => b.Book)
                .FirstOrDefaultAsync(b =>
                    b.Id == borrowingId);

            if (borrowing == null)
            {
                return (false, "Borrowing record not found.");
            }

            // 3. Check status
            if (borrowing.Status == BorrowingStatus.Returned)
            {
                return (
                    false,
                    "This borrowing has already been returned.");
            }

            // 4. Return book
            borrowing.ReturnedAt = DateTime.UtcNow;
            borrowing.ReturnedByUserId = userId;
            borrowing.Status = BorrowingStatus.Returned;

            // 5. Make book available again
            borrowing.Book.Status = BookStatus.Available;

            await _context.SaveChangesAsync();

            return (true, null);
        }
    }
}
