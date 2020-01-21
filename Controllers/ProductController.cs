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
    [Route("product")]
    public class ProductController : ControllerBase
    {

        private TaskDbContext _context;

        public ProductController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.Include("orderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product  = _context.Products.Include("orderItems").FirstOrDefault(e => e.id==id);
            
            if(product==null)
            {
                return NotFound(new {status= HttpStatusCode.NotFound, message="Product not found"});
            }
            return Ok(product);
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        [HttpPut("{id}")]
        public Product EditProduct(int id, Product product)
        {
            var item = _context.Products.FirstOrDefault(e => e.id==id);
            item.name = product.name;
            item.price = product.price;
            _context.SaveChanges();
            return product;
        }

        [HttpDelete("{id}")]
        public int DeleteProduct(int id)
        {
            return id;
        }
    }
}
