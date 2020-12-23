using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BindingModels;
using Models.Interfaces;
using Models.ViewModels;

namespace WebApplication.Controllers
{
    [Route("api/main/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IPizzaLogic _pizza;
        
        public MainController(IPizzaLogic pizza)
        {
            _pizza = pizza;
        }
        [HttpGet]
        public List<PizzaView> Read() => _pizza.Read(null).ToList(); //Convert(rec)).ToList();
        [HttpPost]
        public void Create(PizzaModel model)
        {
            Console.WriteLine("Main count: " + model.Ingredients.Count);
            foreach (var i in model.Ingredients)
            {
                Console.WriteLine("Main: " + i.Key + ", " + i.Value.Item1 + ", " + i.Value.Item2);
            }
            _pizza.CreateOrUpdate(model);
        }
        [HttpPost]
        public void Update(PizzaModel model) => _pizza.CreateOrUpdate(model);
        [HttpPost]
        public void Delete(PizzaModel model) => _pizza.Delete(model);
    }
}
