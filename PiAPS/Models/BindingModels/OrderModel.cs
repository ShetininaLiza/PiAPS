using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BindingModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        //Id client, name pizza
        public virtual Dictionary<string, string> Pizzas { set; get; }
    }
}
