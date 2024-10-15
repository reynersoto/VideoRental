using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using WebMvcPruebaMosh.DTOs;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using WebMvcPruebaMosh.Data;
using WebMvcPruebaMosh.Models;

namespace WebMvcPruebaMosh.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomersController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomersController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        //GET api/customers
        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult GetCustomers(string query = null) 
        {
            IEnumerable<Customer> customersQuery = _context.Customers
                .Include(c => c.MembershipTypes);


            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query) || c.LastName.Contains(query));

            var customersDtos = customersQuery
                .ToList()
                .Select(_mapper.Map<Customer, CustomerDTO>);
                


            return Ok(customersDtos);
        }
        //GET api/customers/1
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }
        //POST api/customers
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult CreateCustomer(CustomerDTO customerDTO) 
        {

            if (!ModelState.IsValid) 
                return BadRequest();

            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.Host+Request.Path.Value + customer.Id), customerDTO);
        }
        //PUT api/customers/1
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid) 
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault( c => c.Id == id);

            if (customerInDb == null) 
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerDto.Id = id;
            customerInDb.Id = id;
            _mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();

        }
        //DELETE api/customers/1
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges(); 

        }
            
    }
}
