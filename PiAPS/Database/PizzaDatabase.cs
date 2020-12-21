using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PizzaDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LIZA\SQLEXPRESS;Initial Catalog=PizzaDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<PizzaOrder> PizzaOrders { set; get; }
        public virtual DbSet<Pizza> Pizzas { set; get; }
        public virtual DbSet<Proportion> Proportions { set; get; }
        public virtual DbSet<Ingredient> Ingredients { set; get; }
    }
}
