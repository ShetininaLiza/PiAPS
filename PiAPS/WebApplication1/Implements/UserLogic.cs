using Models;
using Models.Interfaces;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Implements
{
    public class UserLogic : IUserLogic
    {
        public void CreateOrUpdate(UserModel model)
        {
            using (var context = new PizzaDatabase())
            {
                User user = context.Users.FirstOrDefault(rec => rec.Login == model.Login && rec.Role==model.Role && rec.Id != model.Id);
                if (user != null)
                {
                    throw new Exception("Уже есть такой пользователь");
                }
                if (model.Id.HasValue)
                {
                    user = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
                    if (user == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    user = new User();
                    context.Users.Add(user);
                }
                user.FIO = model.FIO;
                user.Email = model.Email;
                user.Comment = model.Comment;
                user.Role = model.Role;
                user.Login = model.Login;
                user.Password = model.Password;
                context.SaveChanges();
            }
        }

        public void Delete(UserModel model)
        {
            using (var context = new PizzaDatabase())
            {
                User user = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<UserView> Read(UserModel model)
        {
            using (var context = new PizzaDatabase())
            {
                return context.Users
                .Where(rec => model == null || rec.Id == model.Id ||
                rec.Login == model.Login && rec.Password == model.Password)
                .Select(rec => new UserView
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Email=rec.Email,
                    Login = rec.Login,
                    Password = rec.Password,
                    Comment=rec.Comment,
                    Role=rec.Role
                })
                .ToList();
            }
        }
    }
}
