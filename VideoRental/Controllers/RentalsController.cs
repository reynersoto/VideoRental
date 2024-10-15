using Microsoft.AspNetCore.Mvc;
using WebMvcPruebaMosh.Data;

namespace WebMvcPruebaMosh.Controllers
{
    public class RentalsController : Controller
    {

        private ApplicationDbContext _context;
        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IActionResult New()
        {
            return View();
        }
    }
}
