using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public string Unit { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<Proportion> Proportions { set; get; }
    }
}
