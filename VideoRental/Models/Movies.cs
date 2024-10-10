using System.ComponentModel.DataAnnotations;

namespace WebMvcPruebaMosh.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public Genre? Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public short GenreId { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Available Since")]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Available Movies")]
        [RangeMovieStock]
        public short NumbersInStock { get; set; }

    }
}
