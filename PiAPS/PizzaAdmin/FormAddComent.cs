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
    public partial class FormAddComent : Form
    {
        public int Id { get { return id; } set { id = value; } }
        private int id;

        public FormAddComent()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var user = APIClient.GetRequest<List<UserView>>($"api/user/read").FirstOrDefault(rec => rec.Id == id);
            APIClient.PostRequest($"api/user/register", new UserModel()
            {
                FIO = textBoxFIO.Text,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,//ConvertToRole(comboBoxRole.Text),
                Comment = textBoxComment.Text,
            });
            MessageBox.Show("Готово");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCensel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormAddComent_Load(object sender, EventArgs e)
        {
            var user = APIClient.GetRequest<List<UserView>>($"api/user/read").FirstOrDefault(rec => rec.Id == id);
            textBoxFIO.Text = user.FIO;
            textBoxRole.Text = user.Role.ToString();
        }
    }
}
