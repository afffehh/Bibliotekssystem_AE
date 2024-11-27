using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bibliotekssystem.Models
{
    public class Author
    {
        [Key] // Primärnyckel
        public int AuthorID { get; set; }

        [Required] // Obligatoriskt fält
        public string Name { get; set; }

        public string Nationality { get; set; } // Valfritt fält

        // Navigeringsegenskap för relationen
        public ICollection<BookToAuthor> BookToAuthors { get; set; } = new List<BookToAuthor>(); // Många-till-många med Book
    }
}
