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
    public partial class FormCreatePizza : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private Dictionary<string, (string, string)> ingredients;

        public FormCreatePizza()
        {
            InitializeComponent();
            var names=APIClient.GetRequest<List<IngredientView>>($"api/main/getingredientlist").Select(rec => rec.Name).ToArray();
            comboBoxIngredient.Items.AddRange(names);
        }

        private void FormCreatePizza_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = APIClient.GetRequest<List<PizzaView>>($"api/main/getpizzalist").FirstOrDefault(rec => rec.Id == id);
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxWeigth.Text = view.Weigth.ToString();
                        foreach (var i in view.Ingredients)
                        {
                            string st =i.Value.Item1 + " (" + i.Value.Item2 + ") кг;";
                            listBox.Items.Add(st);
                        }
                        //LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                ingredients = new Dictionary<string, (string, string)>();
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                APIClient.PostRequest($"api/main/createpizza", new PizzaModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Weigth = Convert.ToInt32(textBoxWeigth.Text),
                    Ingredients=ingredients
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCensel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            if (textBoxWeigthIngredient.TextLength == 0)
            {
                MessageBox.Show("Заполните вес ингредиента");
            }
            if (comboBoxIngredient.SelectedItem == null)
            {
                MessageBox.Show("Выберите ингредиент");
            }
            if (ingredients.ContainsKey(id.ToString()))
                ingredients[id.ToString()]= (comboBoxIngredient.SelectedItem.ToString(), textBoxWeigthIngredient.Text);
            else
                ingredients.Add(id.ToString(), (comboBoxIngredient.SelectedItem.ToString(), textBoxWeigthIngredient.Text));
            listBox.Items.Add(comboBoxIngredient.SelectedItem.ToString() + ", " + textBoxWeigthIngredient.Text + " кг;");
        }
    }
}
