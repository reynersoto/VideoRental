using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMvcPruebaMosh.DTOs;
using WebMvcPruebaMosh.Models;
using Microsoft.EntityFrameworkCore;
using WebMvcPruebaMosh.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebMvcPruebaMosh.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        [HttpGet]
        public ActionResult GetMovies(string query = null)
        {
            IEnumerable<Movies> movieQuery = _context.Movies
                .Include(g => g.Genre);

            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(c => 
                c.Title.Contains(query) &&
                c.NumberAvailable > 0
                );

            var movieDtos = movieQuery
                .ToList()
                .Select(_mapper.Map<Movies, MovieDTO>);

            return Ok(movieDtos);
        }
        [HttpGet("{id}")]
        public ActionResult GetMovie(int id) 
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null) return NotFound();

            return Ok(_mapper.Map<MovieDTO>(movie));
        }
        [HttpPost]
        [Authorize(Roles = (AppRoles.CanManageMovies))]
        public ActionResult CreateMovie(MovieDTO movieDto) 
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = _mapper.Map<MovieDTO, Movies>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.Host + Request.Path.Value + movie.Id), movieDto);

        }
        [HttpPut("{id}")]
        [Authorize(Roles = (AppRoles.CanManageMovies))]
        public ActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movieInDb = _context.Movies.Single(m  => m.Id == id);

            if (movieInDb == null) return NotFound();

            movieDto.Id = id;
            movieInDb.Id = id;

            _mapper.Map(movieDto,movieInDb);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = (AppRoles.CanManageMovies))]
        public ActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m =>m.Id == id);
            if (movieInDb == null) return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
