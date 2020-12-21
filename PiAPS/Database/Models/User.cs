using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Roles Role { get; set; }
        public string Comment { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { set; get; }
        
        [ForeignKey("PizzamakerId")]
        public virtual List<PizzaOrder> PizzaOrders { set; get; }
    }
}
