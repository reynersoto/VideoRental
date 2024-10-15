using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure.MappingViews;
using WebMvcPruebaMosh.Data;
using WebMvcPruebaMosh.Models;
using WebMvcPruebaMosh.ViewModels;
using System.Security.Claims;

namespace WebMvcPruebaMosh.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IActionResult Index()
        {
            //var movies = _context.Movies.Include("Genre").ToList();
            //return View(movies);

            if (User.IsInRole(AppRoles.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");//using API
        }
        [Route("Movie/Details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return View(movie);

        }
        [Authorize(Roles =(AppRoles.CanManageMovies))]
        public IActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            return View("MovieForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = (AppRoles.CanManageMovies))]
        public IActionResult Save(Movies movie)
        {
            try
            {

                if(!ModelState.IsValid)
                {
                    var viewModel = new NewMovieViewModel(movie)
                    {
                      Genres = _context.Genres.ToList()
                    };
                    return View("MovieForm", viewModel);

                }
                else 
                {


                    if (movie.Id == 0)
                    {
                        movie.DateAdded = DateTime.Now;
                        movie.NumberAvailable = movie.NumbersInStock;
                        _context.Movies.Add(movie);
                    } 
                    else 
                    {
                        var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                        movieInDb.GenreId = movie.GenreId;
                        movieInDb.Title = movie.Title;
                        movieInDb.ReleaseDate = movie.ReleaseDate;
                        movieInDb.NumbersInStock = movie.NumbersInStock;
                        movieInDb.NumberAvailable = (short)(movie.NumbersInStock - movie.NumberAvailable);
                    }
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Movie");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
        [Authorize(Roles = (AppRoles.CanManageMovies))]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            var viewModel = new NewMovieViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);

        }

    }
}
