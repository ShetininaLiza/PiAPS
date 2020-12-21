using Models.ViewModels;
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
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
            Program.Admin = null;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }

        private void buttonAvtoriz_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    Program.Admin = APIClient.GetRequest<UserView>($"api/user/login?login={textBoxLogin.Text}" + $"&password={textBoxPassword.Text}");
                    Console.WriteLine(Program.Admin);
                    if (Program.Admin == null)
                    {
                        MessageBox.Show("Нет такого пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
