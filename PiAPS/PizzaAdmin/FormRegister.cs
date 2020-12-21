using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaAdmin
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            comboBoxRole.Items.Add(Roles.Администратор);
            comboBoxRole.Items.Add(Roles.Менеджер);
            comboBoxRole.Items.Add(Roles.Пиццемейкер);
        }

        private Roles ConvertToRole(string name)
        {
            foreach (Roles fruit in Enum.GetValues(typeof(Roles)))
            {
                if(fruit.ToString()==name)
                {
                    return fruit;
                }
            }
            return 0;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                APIClient.PostRequest("api/user/register", new UserModel()
                {
                    FIO=textBoxFIO.Text,
                    Email=textBoxEmail.Text,
                    Login=textBoxLogin.Text,
                    Password=textBoxPassword.Text,
                    Role=ConvertToRole(comboBoxRole.Text),
                }) ;
                    
                MessageBox.Show("Регистрация прошла успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
