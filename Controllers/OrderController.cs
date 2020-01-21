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
    [Route("order")]
    public class OrderController : ControllerBase
    {

        private TaskDbContext _context;

        public OrderController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Orders.Include("orderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order  = _context.Orders.Include("orderItems").FirstOrDefault(e => e.id==id);
            
            if(order==null)
            {
                return NotFound(new {status= HttpStatusCode.NotFound, message="Order not found"});
            }
            return Ok(order);
        }

        [HttpPost]
        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        [HttpPut("{id}")]
        public Order EditOrder(int id, Order order)
        {
            var item = _context.Orders.FirstOrDefault(e => e.id==id);
            item.deliv_add_id = order.deliv_add_id;
            _context.SaveChanges();
            return order;
        }

        [HttpDelete("{id}")]
        public int DeleteOrder(int id)
        {
            return id;
        }
    }
}
