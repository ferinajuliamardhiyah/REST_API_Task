using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_Task.Models
{
    public class LoginAuth
    {
        public int id {get; set;}
        [Required]
        public int customer_id {get; set;}
        [Required]
        public string username {get; set;}
        [Required]
        public string password {get; set;}
    }
}