using Models.Interfaces;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PizzaAdmin
{
    static class Program
    {
        public static UserView Admin { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APIClient.Connect();
            if (APIClient.GetContact() == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form = new FormEnter();
                form.ShowDialog();
                if (Admin != null)
                {
                    Application.Run(new FormMain());
                }
            }
        }
        /*
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IPizzaLogic, PizzaLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientLogic, IngredientLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
        */
    }
}
