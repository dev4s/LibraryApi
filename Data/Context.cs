using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book1", Author = "Author1", ISBN = "1234567890", Status = BookStatus.OnTheShelf },
                new Book { Id = 2, Title = "Book2", Author = "Author2", ISBN = "0987654321", Status = BookStatus.OnTheShelf },
                new Book { Id = 3, Title = "Book3", Author = "Author3", ISBN = "1122334455", Status = BookStatus.OnTheShelf }
            );
        }
    }
}
