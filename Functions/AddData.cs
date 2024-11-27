using System;
using System.Threading.Tasks;
using Bibliotekssystem.Models;

    public class AddData
    {
        private readonly AppDbContext _context;

        public AddData(AppDbContext context)
        {
            _context = context;
        }

        // Lägg till författare
        public async Task AddAuthorAsync(string name, string nationality)
        {
            var author = new Author { Name = name, Nationality = nationality };
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        // Lägg till bok
        public async Task AddBookAsync(string title, DateTime releaseDate)
        {
            var book = new Book { Title = title, ReleaseDate = releaseDate };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        // Lägg till lån
        public async Task AddLoanAsync(int bookId, DateTime loanDate, DateTime? returnDate)
        {
            var loan = new Loan { BookID = bookId, LoanDate = loanDate, ReturnDate = returnDate };
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }
    }

