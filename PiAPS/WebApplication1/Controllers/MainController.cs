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
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IPizzaLogic _pizza;
        private readonly IIngredientLogic _ingredient;

        public MainController(IPizzaLogic pizza, IIngredientLogic ingredient)
        {
            _pizza = pizza;
            _ingredient = ingredient;
        }
        [HttpGet]
        public List<PizzaView> GetPizzaList() => _pizza.Read(null).ToList(); //Convert(rec)).ToList();
        [HttpPost]
        public void CreatePizza(PizzaModel model) => _pizza.CreateOrUpdate(model);
        [HttpPost]
        public void UpdatePizza(PizzaModel model) => _pizza.CreateOrUpdate(model);
        [HttpPost]
        public void DeletePizza(PizzaModel model) => _pizza.Delete(model);

        [HttpGet]
        public List<IngredientView> GetIngredientList() => _ingredient.Read(null).ToList(); //Convert(rec)).ToList();
        [HttpGet]
        public IngredientView GetIngredient(int id) => _ingredient.Read(new IngredientModel { Id = id })?[0]; //Convert(_product.Read(new ShipBindingModel { Id = productId })?[0]);
        [HttpPost]
        public void CreateIngredient(IngredientModel model) => _ingredient.CreateOrUpdate(model);
        [HttpPost]
        public void UpdateIngredient(IngredientModel model) => _ingredient.CreateOrUpdate(model);
        [HttpPost]
        public void DeleteIngredient(IngredientModel model) => _ingredient.Delete(model);
    }
}
