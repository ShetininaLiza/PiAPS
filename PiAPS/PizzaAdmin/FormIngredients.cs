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
    public partial class FormIngredients : Form
    {
        public FormIngredients()
        {
            InitializeComponent();
        }

        private void добавитьИнгредиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngredient form = new FormIngredient();
            form.ShowDialog();
        }

        private void изменитьИнгредиентToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void удалитьИнгредиентToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormIngredients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        { 
            var list=APIClient.GetRequest<List<IngredientView>>($"api/main/getingredientlist");
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
