using Microsoft.EntityFrameworkCore;

namespace Bibliotekssystem.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<BookToAuthor> BookToAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Anslutningssträng
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BibliotekssystemDb_AE;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurera relationen mellan Book och Author (många-till-många)
            modelBuilder.Entity<BookToAuthor>()
                .HasKey(ba => new { ba.BookID, ba.AuthorID }); // Kombinerad primärnyckel för bryggtabellen BookToAuthor

            modelBuilder.Entity<BookToAuthor>()
                .HasOne(ba => ba.Book) // En rad i BookToAuthor kopplas till en specifik Book
                .WithMany(b => b.BookToAuthors) // En Book kan kopplas till flera rader i BookToAuthor
                .HasForeignKey(ba => ba.BookID); // BookID är främmande nyckel i BookToAuthor

            modelBuilder.Entity<BookToAuthor>()
                .HasOne(ba => ba.Author) // En rad i BookToAuthor kopplas till en specifik Author
                .WithMany(a => a.BookToAuthors) // En Author kan kopplas till flera rader i BookToAuthor
                .HasForeignKey(ba => ba.AuthorID); // AuthorID är främmande nyckel i BookToAuthor

            // Konfigurera relationen mellan Book och Loan (en-till-många)
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book) // Ett lån är kopplat till en specifik Book
                .WithMany(b => b.Loans) // En Book kan ha flera lån
                .HasForeignKey(l => l.BookID); // BookID är främmande nyckel i Loan

        }
    }
}
