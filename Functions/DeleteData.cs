using System;
using System.Threading.Tasks;
using Bibliotekssystem.Models;

public class DeleteData
{
    private readonly AppDbContext _context;

    public DeleteData(AppDbContext context)
    {
        _context = context;
    }

    // Ta bort författare
    public async Task DeleteAuthorAsync(int authorId)
    {
        var author = await _context.Authors.FindAsync(authorId);
        if (author != null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }

    // Ta bort bok
    public async Task DeleteBookAsync(int bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    // Ta bort lån
    public async Task DeleteLoanAsync(int loanId)
    {
        var loan = await _context.Loans.FindAsync(loanId);
        if (loan != null)
        {
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }



}

