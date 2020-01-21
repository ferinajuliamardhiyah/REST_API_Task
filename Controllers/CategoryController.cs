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
    [Route("category")]
    public class CategoryController : ControllerBase
    {

        private TaskDbContext _context;

        public CategoryController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Categories.Include("products"));
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category  = _context.Categories.Include("products").FirstOrDefault(e => e.id==id);
            
            if(category==null)
            {
                return NotFound(new {status= HttpStatusCode.NotFound, message="Category not found"});
            }
            return Ok(category);
        }

        [HttpPost]
        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        [HttpPut("{id}")]
        public Category EditCategory(int id, Category category)
        {
            var item = _context.Categories.FirstOrDefault(e => e.id==id);
            item.name = category.name;
            _context.SaveChanges();
            return category;
        }

        [HttpDelete("{id}")]
        public int DeleteCategory(int id)
        {
            return id;
        }
    }
}
