using Models.BindingModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IIngredientLogic
    {
        List<IngredientView> Read(IngredientModel model);
        void CreateOrUpdate(IngredientModel model);
        void Delete(IngredientModel model);
    }
}
