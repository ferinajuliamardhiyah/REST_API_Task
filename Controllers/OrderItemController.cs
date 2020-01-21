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
    [Route("order_item")]
    public class OrderItemController : ControllerBase
    {

        private TaskDbContext _context;

        public OrderItemController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.OrderItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderItem(int id)
        {
            var order_item  = _context.OrderItems.FirstOrDefault(e => e.id==id);
            
            if(order_item==null)
            {
                return NotFound(new {status= HttpStatusCode.NotFound, message="Order item not found"});
            }
            return Ok(order_item);
        }

        [HttpPost]
        public OrderItem AddOrderItem(OrderItem order_item)
        {
            _context.OrderItems.Add(order_item);
            _context.SaveChanges();
            return order_item;
        }

        [HttpPut("{id}")]
        public OrderItem EditOrderItem(int id, OrderItem order_item)
        {
            var item = _context.OrderItems.FirstOrDefault(e => e.id==id);
            item.quantity = order_item.quantity;
            _context.SaveChanges();
            return order_item;
        }

        [HttpDelete("{id}")]
        public int DeleteOrderItem(int id)
        {
            return id;
        }
    }
}
