using System.ComponentModel.DataAnnotations;
using WebMvcPruebaMosh.Models;

namespace WebMvcPruebaMosh.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        [Key]
        public int? Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public short? GenreId { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
      
        [Required]
        [Display(Name = "Available Copies")]
        [RangeMovieStock]
        public short? NumbersInStock { get; set; }
        public string PageTitle { 
            get {
                    return (Id != 0) ? "Edit Movie" : "New Movie";
                }
        }

        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movies movies)
        {
            Id = movies.Id;
            Title = movies.Title;
            GenreId = movies.GenreId;
            ReleaseDate = movies.ReleaseDate;
            NumbersInStock = movies.NumbersInStock;
        }

    }
}
