using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public Client Client { get; set; }
        
        [ForeignKey("OrderId")]
        public virtual List<PizzaOrder> PizzaOrders { set; get; }
    }
}
