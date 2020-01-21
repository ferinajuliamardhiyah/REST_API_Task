using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_Task.Models
{
    public class OrderItem
    {
        public int id {get; set;}
        [Required]
        public int order_id {get; set;}
        [Required]
        public int product_id {get; set;}
        public int quantity {get; set;}
    }
}