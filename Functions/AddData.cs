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

    // Lägg till bok och koppla till författare
    public async Task AddBookAsync(string title, DateTime releaseDate, int authorId)
    {
        var book = new Book { Title = title, ReleaseDate = releaseDate };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        // Koppla bok till författare
        var bookToAuthor = new BookToAuthor { BookID = book.BookID, AuthorID = authorId };
        _context.BookToAuthors.Add(bookToAuthor);
        await _context.SaveChangesAsync();
    }


    // Lägg till lån
    public async Task AddLoanAsync(int bookId, DateTime loanDate, DateTime? returnDate)
    {
        var loan = new Loan { BookID = bookId, LoanDate = loanDate, ReturnDate = returnDate };
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
    }

    // Lägg till författare till en bok
    public async Task AddAuthorToBookAsync(int bookId, int authorId)
    {
        // Kontrollera att både boken och författaren finns
        var book = await _context.Books.FindAsync(bookId);
        var author = await _context.Authors.FindAsync(authorId);

        if (book != null && author != null)
        {
            // Skapa kopplingen mellan bok och författare
            var bookToAuthor = new BookToAuthor { BookID = bookId, AuthorID = authorId };
            _context.BookToAuthors.Add(bookToAuthor);
            await _context.SaveChangesAsync();
            Console.WriteLine("Författare kopplad till boken.");
        }
        else
        {
            Console.WriteLine("Bok eller författare kunde inte hittas.");
        }
    }


}