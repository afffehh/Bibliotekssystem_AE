using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bibliotekssystem.Models
{
    public class Book
    {
        [Key] // Primärnyckel
        public int BookID { get; set; }

        [Required] // Obligatoriskt fält
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; } // Datum för utgivning

        // Navigeringsegenskaper för relationer
        public ICollection<BookToAuthor> BookToAuthors { get; set; } = new List<BookToAuthor>(); // Många-till-många med Author
        public ICollection<Loan> Loans { get; set; } = new List<Loan>(); // En-till-många med Loan
    }
}
