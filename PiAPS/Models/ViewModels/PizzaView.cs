using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class PizzaView
    {
        public int Id { get; set; }

        [DisplayName("Название пицы")]
        public string Name { get; set; }

        [DisplayName("Вес нетто")]
        public int Weigth { get; set; }

        //id pizza, name & weigth ingredient
        public Dictionary<string, (string, string)> Ingredients { get; set; }
    }
}
