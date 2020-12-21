using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int PizzamakerId { get; set; }
        public string Status { get; set; }
        
        public Order Order { get; set; }
        public User Pizzamaker { get; set; }
        public Pizza Pizza { get; set; }
    }
}
