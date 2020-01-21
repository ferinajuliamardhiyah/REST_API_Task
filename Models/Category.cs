using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_Task.Models
{
    public class Category
    {
        public int id {get; set;}
        public string name {get; set;}
        [ForeignKey("order_id")]
        public ICollection<Product> products {get; set;}
        
        
    }
}