using Models.BindingModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IPizzaLogic
    {
        List<PizzaView> Read(PizzaModel model);
        void CreateOrUpdate(PizzaModel model);
        void Delete(PizzaModel model);
    }
}
