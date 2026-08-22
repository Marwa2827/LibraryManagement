using LibraryManagement.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Publisher> Publishers => Set<Publisher>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Borrowing> Borrowings => Set<Borrowing>();
        public DbSet<UserActivityLog> UserActivityLogs
            => Set<UserActivityLog>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // BookAuthor - Composite Primary Key
            builder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            // Book -> Publisher
            builder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Book -> Category
            builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // BookAuthor -> Book
            builder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // BookAuthor -> Author
            builder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Category -> Parent Category
            builder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Member -> Borrowing
            builder.Entity<Borrowing>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Borrowings)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            // Book -> Borrowing
            builder.Entity<Borrowing>()
                .HasOne(b => b.Book)
                .WithMany(book => book.Borrowings)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Borrowing (BorrowedBy)
            builder.Entity<Borrowing>()
                .HasOne(b => b.BorrowedByUser)
                .WithMany(u => u.BorrowingsMade)
                .HasForeignKey(b => b.BorrowedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Borrowing (ReturnedBy)
            builder.Entity<Borrowing>()
                .HasOne(b => b.ReturnedByUser)
                .WithMany(u => u.ReturnsMade)
                .HasForeignKey(b => b.ReturnedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Activity Logs
            builder.Entity<UserActivityLog>()
                .HasOne(log => log.User)
                .WithMany(u => u.ActivityLogs)
                .HasForeignKey(log => log.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Member Code
            builder.Entity<Member>()
                .HasIndex(m => m.MemberCode)
                .IsUnique();

            // Unique ISBN
            builder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();
        }
    }
}
