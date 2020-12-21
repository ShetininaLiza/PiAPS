using Models;
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
    public partial class FormUser : Form
    {
        public int Id { get { return id; } set { id = value; } }
        private int id;

        public FormUser()
        {
            InitializeComponent();
        }
        private Roles ConvertToRole(string name)
        {
            foreach (Roles fruit in Enum.GetValues(typeof(Roles)))
            {
                if (fruit.ToString() == name)
                {
                    return fruit;
                }
            }
            return 0;
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            var user = APIClient.GetRequest<List<UserView>>($"api/user/read").FirstOrDefault(rec=>rec.Id==id);
            textBoxFIO.Text = user.FIO;
            textBoxEmail.Text = user.Email;
            textBoxLogin.Text = user.Login;
            textBoxPassword.Text = user.Password;
            textBoxRole.Text = user.Role.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            APIClient.PostRequest($"api/user/register",new UserModel()
            {
                FIO = textBoxFIO.Text,
                Email = textBoxEmail.Text,
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                Role = ConvertToRole(textBoxRole.Text),
            });
            MessageBox.Show("Готово");
            DialogResult =DialogResult.OK;
            Close();
        }

        private void buttonCensel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
