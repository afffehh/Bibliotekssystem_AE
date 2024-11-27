using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotekssystem.Models
{
    public class Loan
    {
        [Key] // Primärnyckel
        public int LoanID { get; set; }

        [Required] // Obligatoriskt fält
        [ForeignKey("Book")] // Främmande nyckel
        public int BookID { get; set; }

        [Required] // Obligatoriskt fält
        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; } // Valfritt fält

        // Navigeringsegenskap
        public Book Book { get; set; } // Relation till Book (matchar namnet i Book.cs)
    }
}
