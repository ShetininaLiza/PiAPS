using Models.BindingModels;
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
    public partial class FormIngredient : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        
        public FormIngredient()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                APIClient.PostRequest($"api/ingredient/create", new IngredientModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Unit=textBoxUnit.Text
                });
                MessageBox.Show("Готово");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCensel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormIngredient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                var ingredient = APIClient.GetRequest<List<IngredientView>>($"api/ingredient/read")
                    .FirstOrDefault(rec => rec.Id == id);
                textBoxName.Text = ingredient.Name;
                textBoxCount.Text = ingredient.Count.ToString();
                textBoxUnit.Text = ingredient.Unit;
            }
        }
    }
}
