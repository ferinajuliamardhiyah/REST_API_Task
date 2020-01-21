using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_Task.Models
{
    public class Product
    {
        public int id {get; set;}
        [Required]
        public int cat_id {get; set;}
        public string name {get; set;}
        public long price {get; set;}
        [ForeignKey("product_id")]
        public ICollection<OrderItem> orderItems {get; set;}
    }
}