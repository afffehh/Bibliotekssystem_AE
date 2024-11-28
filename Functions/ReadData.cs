using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore;

public class ReadData
{
    private readonly AppDbContext _context;

    public ReadData(AppDbContext context)
    {
        _context = context;
    }

    // Läs alla författare
    public async Task ReadAllAuthorsAsync()
    {
        var authors = await _context.Authors.ToListAsync();
        foreach (var author in authors)
        {
            Console.WriteLine($"Författare: {author.Name}, Nationalitet: {author.Nationality}");
        }
    }

    // Läs alla böcker
    public async Task ReadAllBooksAsync()
    {
        var books = await _context.Books.ToListAsync();
        foreach (var book in books)
        {
            Console.WriteLine($"Bok: {book.Title}, Utgivningsdatum: {book.ReleaseDate.ToShortDateString()}");
        }
    }

    // Läs alla lån
    public async Task ReadAllLoansAsync()
    {
        var loans = await _context.Loans.ToListAsync();
        foreach (var loan in loans)
        {
            Console.WriteLine($"Lån: Bok-ID {loan.BookID}, Lånedatum: {loan.LoanDate.ToShortDateString()}, Återlämning: {loan.ReturnDate?.ToShortDateString() ?? "Ej återlämnad"}");
        }
    }

    // Lista alla böcker tillsammans med deras författare
    public async Task ListBooksWithAuthorsAsync()
    {
        var booksWithAuthors = await _context.Books
            .Include(b => b.BookToAuthors)          // Inkluderar relationerna med BookToAuthor
            .ThenInclude(ba => ba.Author)           // Inkluderar Author via BookToAuthor
            .ToListAsync();

        foreach (var book in booksWithAuthors)
        {
            Console.WriteLine($"Bok: {book.Title} (Utgiven: {book.ReleaseDate.ToShortDateString()})");
            Console.WriteLine("Författare:");

            // Loopa genom alla författare som är kopplade till boken
            foreach (var bookToAuthor in book.BookToAuthors)
            {
                Console.WriteLine($"- {bookToAuthor.Author.Name} ({bookToAuthor.Author.Nationality})");
            }
            Console.WriteLine();
        }
    }


    // Lista alla lånade böcker och deras återlämningsdatum
    public async Task ListLoanedBooksAsync()
    {
        var loanedBooks = await _context.Loans
            .Include(l => l.Book) // Hämtar den relaterade boken för varje lån
            .ToListAsync();

        foreach (var loan in loanedBooks)
        {
            Console.WriteLine($"Bok: {loan.Book.Title} (Lånedatum: {loan.LoanDate.ToShortDateString()})");
            if (loan.ReturnDate.HasValue)
            {
                Console.WriteLine($"Återlämnad: {loan.ReturnDate.Value.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Återlämning ej gjord än.");
            }
            Console.WriteLine();
        }
    }


}
