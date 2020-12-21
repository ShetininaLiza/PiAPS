using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BindingModels
{
    public class PizzaModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int Weigth { get; set;}

        //id pizza, name & count ingredient
        public Dictionary<string, (string, string)> Ingredients { get; set; }
    }
}
