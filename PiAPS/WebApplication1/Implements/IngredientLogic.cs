using Models.BindingModels;
using Models.Interfaces;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Implements
{
    public class IngredientLogic : IIngredientLogic
    {
        public void CreateOrUpdate(IngredientModel model)
        {
            using (var context = new PizzaDatabase())
            {
                Ingredient element = context.Ingredients.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Ingredients.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Ingredient();
                    context.Ingredients.Add(element);
                }

                element.Name = model.Name;
                element.Count = model.Count;
                element.Unit = model.Unit;
                context.SaveChanges();
            }
        }

        public void Delete(IngredientModel model)
        {
            using (var context = new PizzaDatabase())
            {
                Ingredient element = context.Ingredients.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Ingredients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<IngredientView> Read(IngredientModel model)
        {
            using (var context = new PizzaDatabase())
            {
                return context.Ingredients
               .Where(rec => model == null || rec.Id == model.Id)
               .Select(rec => new IngredientView
               {
                   Id = rec.Id,
                   Name = rec.Name,
                   Count=rec.Count,
                   Unit=rec.Unit
               })
               .ToList();
            }
        }
    }
}
