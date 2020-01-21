using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using REST_API_Task.Database;
using REST_API_Task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace REST_API_Task.Controllers
{
    [Authorize]
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {

        private TaskDbContext _context;

        public CustomerController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Customers.Include("orders.orderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer  = _context.Customers.FirstOrDefault(e => e.id==id);
            
            if(customer==null)
            {
                return NotFound(new {status= HttpStatusCode.NotFound, message="Customer not found"});
            }
            return Ok(customer);
        }

        [HttpPost]
        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        [HttpPut("{id}")]
        public Customer EditCustomer(int id, Customer customer)
        {
            var item = _context.Customers.FirstOrDefault(e => e.id==id);
            item.name = customer.name;
            item.address = customer.name;
            _context.SaveChanges();
            return customer;
        }

        [HttpDelete("{id}")]
        public int DeleteCustomer(int id)
        {
            return id;
        }
    }
}
