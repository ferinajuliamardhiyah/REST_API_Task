using System;
using Microsoft.EntityFrameworkCore;
using REST_API_Task.Models;

namespace REST_API_Task.Database
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> bebas) :base(bebas){}


        public DbSet<LoginAuth> LoginAuths {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<DeliveryAddress> DeliveryAddresses {get; set;}
        public DbSet<OrderItem> OrderItems {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}

    }
}