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
    public partial class FormIngredients : Form
    {
        public FormIngredients()
        {
            InitializeComponent();
        }

        private void добавитьИнгредиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngredient form = new FormIngredient();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void изменитьИнгредиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormIngredient form = new FormIngredient();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void удалитьИнгредиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        APIClient.PostRequest($"api/ingredient/delete", new IngredientModel
                        {
                            Id = id
                        });
                        //logic.Delete(new UserModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        
        private void FormIngredients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        { 
            var list= APIClient.GetRequest<List<IngredientView>>($"api/ingredient/read");
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
