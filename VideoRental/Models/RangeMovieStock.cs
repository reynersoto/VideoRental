using System.ComponentModel.DataAnnotations;

namespace WebMvcPruebaMosh.Models
{
    public class RangeMovieStock : ValidationAttribute
    {


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var movie = (Movies)validationContext.ObjectInstance;

            if (movie.NumbersInStock == null) return new ValidationResult("Numbers in stock are required.");
            if (movie.NumbersInStock > 20 || movie.NumbersInStock <= 0) return new ValidationResult("Value should be between 1 and 20");
            return ValidationResult.Success;
        }
    }
}
