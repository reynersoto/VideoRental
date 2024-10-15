using System.ComponentModel.DataAnnotations;
using WebMvcPruebaMosh.Models;

namespace WebMvcPruebaMosh.DTOs
{
    public class MovieDTO
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public Genre? Genre { get; set; }
        [Required]
        public short GenreId { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public short NumbersInStock { get; set; }
        [Required]
        public short NumberAvailable { get; set; }



    }
}
