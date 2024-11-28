using System;
using System.Threading.Tasks;
using Bibliotekssystem.Models;

public class UpdateData
{
    private readonly AppDbContext _context;

    public UpdateData(AppDbContext context)
    {
        _context = context;
    }

    // Uppdatera författare
    public async Task UpdateAuthorAsync(int authorId, string newName)
    {
        var author = await _context.Authors.FindAsync(authorId);
        if (author != null)
        {
            author.Name = newName;
            await _context.SaveChangesAsync();
        }
    }

    // Uppdatera bok
    public async Task UpdateBookAsync(int bookId, string newTitle)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book != null)
        {
            book.Title = newTitle;
            await _context.SaveChangesAsync();
        }
    }

    // Uppdatera lån
    public async Task UpdateLoanAsync(int loanId, DateTime returnDate)
    {
        var loan = await _context.Loans.FindAsync(loanId);
        if (loan != null)
        {
            loan.ReturnDate = returnDate;
            await _context.SaveChangesAsync();
        }
    }
}

