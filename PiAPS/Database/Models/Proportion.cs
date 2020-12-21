using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Proportion
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        [Required]
        public int Weight { get; set; }
        
        public Pizza Pizza { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
