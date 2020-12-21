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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void созданиеЛичногоКабинетаДляМенеджераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }

        private void созданиеЛичногоКабинетаДляПиццемейкераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }

        private void каталогПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsers form = new FormUsers();
            form.ShowDialog();
        }

        private void каталогПиццToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPizzas form = new FormPizzas();
            form.ShowDialog();
        }

        private void каталогИнгредиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngredients form = new FormIngredients();
            form.ShowDialog();
        }
    }
}
