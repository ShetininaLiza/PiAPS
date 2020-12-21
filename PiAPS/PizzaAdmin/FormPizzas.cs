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
    public partial class FormPizzas : Form
    {
        public FormPizzas()
        {
            InitializeComponent();
        }

        private void создатьПиццуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreatePizza form = new FormCreatePizza();
            form.ShowDialog();
        }

        private void изменитьДанныеПиццыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormCreatePizza form = new FormCreatePizza();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void удалитьПиццуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        APIClient.PostRequest($"api/main/deletepizza", new PizzaModel
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

        private void FormPizzas_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list=APIClient.GetRequest<List<PizzaView>>($"api/main/getpizzalist");
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
