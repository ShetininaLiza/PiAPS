using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IUserLogic
    {
        List<UserView> Read(UserModel model);
        void CreateOrUpdate(UserModel model);
        void Delete(UserModel model);
    }
}
