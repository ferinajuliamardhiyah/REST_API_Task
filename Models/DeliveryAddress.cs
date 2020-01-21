using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_Task.Models
{
    public class DeliveryAddress
    {
        public int id {get; set;}
        public string name {get; set;}
        [Required]
        public string address {get; set;}
        [ForeignKey("deliv_add_id")]
        public ICollection<Order> orders {get; set;}
        
    }
}