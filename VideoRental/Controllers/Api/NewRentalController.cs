using Microsoft.AspNetCore.Mvc;
using WebMvcPruebaMosh.Data;
using WebMvcPruebaMosh.DTOs;
using WebMvcPruebaMosh.Models;

namespace WebMvcPruebaMosh.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class NewRentalController : ControllerBase
    {
        private ApplicationDbContext _context;
        public NewRentalController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult CreateNewRental(NewRentalDTO newRental)
        {
            
            var customerInDB = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var moviesSelected = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();


            foreach (var movie in moviesSelected)
            {

                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customerInDB,
                    Movies = movie,
                    DateRented = DateTime.Now

                };

                _context.Rental.Add(rental);
                
            }
            _context.SaveChanges(); 
            return Ok();
        }
    }
}
