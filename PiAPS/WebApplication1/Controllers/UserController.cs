using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Interfaces;
using Models.ViewModels;

namespace WebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _logic;
        public UserController(IUserLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public UserView Login(string login, string password) => _logic.Read(new UserModel { Login = login, Password = password })?[0];

        [HttpPost]
        public void Register([FromBody]UserModel model)
        {
            _logic.CreateOrUpdate(model);
        }
        
        [HttpPost]
        public void UpdateData(UserModel model) => _logic.CreateOrUpdate(model);
        
        [HttpGet]
        public List<UserView> Read() => _logic.Read(null);
        [HttpPost]
        public void DeleteUser(UserModel model) => _logic.Delete(model);
    }
}
