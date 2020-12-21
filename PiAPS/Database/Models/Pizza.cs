using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Weigth { get; set; }
        
        [ForeignKey("PizzaId")]
        public virtual List<PizzaOrder> PizzaOrders { get; set; }
        public virtual List<Proportion> Proportions { get; set; }
    }
}
