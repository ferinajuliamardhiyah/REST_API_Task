using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_Task.Models
{
    public class Customer
    {
        public int id {get; set;}
        [Required]
        public string name {get; set;}
        public string address {get; set;}
        [ForeignKey("cust_id")]
        public ICollection<Order> orders {get; set;}
        [ForeignKey("customer_id")]
        public ICollection<LoginAuth> loginAuth {get; set;}
    }
}