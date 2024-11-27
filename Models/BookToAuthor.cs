using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotekssystem.Models
{
    public class BookToAuthor
    {
        [Key] // Del av en sammansatt primärnyckel
        [ForeignKey("Book")]
        public int BookID { get; set; }

        [Key]
        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        // Navigeringsegenskaper
        public Book Book { get; set; } // Koppling till Book
        public Author Author { get; set; } // Koppling till Author
    }
}
