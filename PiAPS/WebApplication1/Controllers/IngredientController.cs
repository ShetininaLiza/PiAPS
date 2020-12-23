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
    [Route("api/ingredient/[action]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientLogic _ingredient;

        public IngredientController(IIngredientLogic ingredient)
        {
            _ingredient = ingredient;
        }
        
        [HttpGet]
        public List<IngredientView> Read() => _ingredient.Read(null).ToList(); //Convert(rec)).ToList();
        [HttpPost]
        public void Create(IngredientModel model) => _ingredient.CreateOrUpdate(model);
        [HttpPost]
        public void Update(IngredientModel model) => _ingredient.CreateOrUpdate(model);
        [HttpPost]
        public void Delete(IngredientModel model) => _ingredient.Delete(model);
    }
}
