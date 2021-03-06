﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        [ForeignKey("User")]
        public int PizzamakerId { get; set; }
        [Required]
        public string Status { get; set; }
        
        public Order Order { get; set; }
        public User Pizzamaker { get; set; }
    }
}
