using Microsoft.EntityFrameworkCore;
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
    public class PizzaLogic : IPizzaLogic
    {
        public void CreateOrUpdate(PizzaModel model)
        {
            using (var context = new PizzaDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pizza element = context.Pizzas.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть пицца с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Pizzas.FirstOrDefault(rec => rec.Id == model.Id);

                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Pizza();
                            context.Pizzas.Add(element);
                        }
                        element.Name = model.Name;
                        element.Weigth = model.Weigth;
                        context.SaveChanges();
                        
                        if (model.Id.HasValue)
                        {
                            var shipComponents = context.Proportions.Where(rec => rec.PizzaId == model.Id.Value).ToList();
                            context.Proportions.RemoveRange(shipComponents.Where(rec => !model.Ingredients.ContainsKey(rec.Id.ToString())).ToList());
                            context.SaveChanges();
                            foreach (var updateComponent in shipComponents)
                            {
                                updateComponent.PizzaId = model.Id.Value;
                                updateComponent.IngredientId=
                                    context.Ingredients.FirstOrDefault(rec=>rec.Name==
                                    model.Ingredients[updateComponent.PizzaId.ToString()].Item1).Id;
                            }
                            element.Proportions = shipComponents;
                            context.SaveChanges();
                        }
                        Console.WriteLine("Ingredients: " + model.Ingredients.Count);
                        foreach (var pc in model.Ingredients)
                        {
                            Console.WriteLine("pc.Value.Item1: " + pc.Value.Item1);
                            int id = context.Ingredients.FirstOrDefault(rec => rec.Name == pc.Value.Item1).Id;
                            context.Proportions.Add(new Proportion
                            {
                                PizzaId = element.Id,
                                IngredientId = id,
                                Weight = Convert.ToInt32(pc.Value.Item2),
                                Pizza = context.Pizzas.FirstOrDefault(rec => rec.Id == element.Id),
                                Ingredient = context.Ingredients.FirstOrDefault(rec => rec.Id == id)
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(PizzaModel model)
        {
            using (var context = new PizzaDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Proportions.RemoveRange(context.Proportions.Where(rec => rec.PizzaId == model.Id));
                        Pizza element = context.Pizzas.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Pizzas.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<PizzaView> Read(PizzaModel model)
        {
            using (var context = new PizzaDatabase())
            {
                return context.Pizzas
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new PizzaView
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Weigth = rec.Weigth,
                    Ingredients = context.Proportions
                .Include(recPC => recPC.Ingredient)
                .Where(recPC => recPC.PizzaId == rec.Id)
                .ToDictionary(recPC => recPC.PizzaId.ToString(), recPC =>
                (recPC.Ingredient.Name, recPC.Ingredient.Count.ToString()))
                })
                .ToList();
            }
        }
    }
}
