using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure.MappingViews;
using WebMvcPruebaMosh.Data;
using WebMvcPruebaMosh.Models;
using WebMvcPruebaMosh.ViewModels;

namespace WebMvcPruebaMosh.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public IActionResult Index()
        {

            //var customers = _context.Customers.Include("MembershipType").ToList();
            //return View(customers);
            return View(); //using API
        }
        [Route("Customer/Details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            try
            {

                if (!ModelState.IsValid)
                {

                    var viewModel = new CustomerFormViewModel(customer)
                    {
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("CustomerForm", viewModel);
                }
                

                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.LastName = customer.LastName;
                    customerInDb.MembershipTypesId = customer.MembershipTypesId;
                    customerInDb.isSubscribeToNewsletter = customer.isSubscribeToNewsletter;
                    customerInDb.Phone = customer.Phone;
                    customerInDb.Extension = customer.Extension;
                    customerInDb.Birthday = customer.Birthday;

                }   
                _context.SaveChanges();
                return RedirectToAction("Index", "Customer");

            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public IActionResult Edit(int id) 
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);

        }
    }
}
