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
    [Route("deliv_add")]
    public class DeliveryAddressController : ControllerBase
    {

        private TaskDbContext _context;

        public DeliveryAddressController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.DeliveryAddresses.Include("orders.orderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var deliv_add  = _context.DeliveryAddresses.Include("orders.orderItems").FirstOrDefault(e => e.id==id);
            
            if(deliv_add==null)
            {
                return NotFound(new {status= HttpStatusCode.NotFound, message="Delivery address not found"});
            }
            return Ok(deliv_add);
        }

        [HttpPost]
        public DeliveryAddress AddDeliveryAddress(DeliveryAddress deliv_add)
        {
            _context.DeliveryAddresses.Add(deliv_add);
            _context.SaveChanges();
            return deliv_add;
        }

        [HttpPut("{id}")]
        public DeliveryAddress EditDeliveryAddress(int id, DeliveryAddress deliv_add)
        {
            var item = _context.DeliveryAddresses.Include("orders.orderItems").FirstOrDefault(e => e.id==id);
            item.name = deliv_add.name;
            item.address = deliv_add.address;
            _context.SaveChanges();
            return deliv_add;
        }

        [HttpDelete("{id}")]
        public int DeleteDeliveryAddress(int id)
        {
            return id;
        }
    }
}
