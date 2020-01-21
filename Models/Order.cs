using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_Task.Models
{
    public class Order
    {
        public int id {get; set;}
        [Required]
        public int cust_id {get; set;}
        [Required]
        public int deliv_add_id {get; set;}
        [ForeignKey("order_id")]
        public ICollection<OrderItem> orderItems {get; set;}
        
    }
}