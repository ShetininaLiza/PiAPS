namespace PizzaAdmin
{
    partial class FormIngredients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьИнгредиентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьИнгредиентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьИнгредиентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьИнгредиентToolStripMenuItem,
            this.изменитьИнгредиентToolStripMenuItem,
            this.удалитьИнгредиентToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьИнгредиентToolStripMenuItem
            // 
            this.добавитьИнгредиентToolStripMenuItem.Name = "добавитьИнгредиентToolStripMenuItem";
            this.добавитьИнгредиентToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.добавитьИнгредиентToolStripMenuItem.Text = "Добавить ингредиент";
            this.добавитьИнгредиентToolStripMenuItem.Click += new System.EventHandler(this.добавитьИнгредиентToolStripMenuItem_Click);
            // 
            // изменитьИнгредиентToolStripMenuItem
            // 
            this.изменитьИнгредиентToolStripMenuItem.Name = "изменитьИнгредиентToolStripMenuItem";
            this.изменитьИнгредиентToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.изменитьИнгредиентToolStripMenuItem.Text = "Изменить ингредиент";
            this.изменитьИнгредиентToolStripMenuItem.Click += new System.EventHandler(this.изменитьИнгредиентToolStripMenuItem_Click);
            // 
            // удалитьИнгредиентToolStripMenuItem
            // 
            this.удалитьИнгредиентToolStripMenuItem.Name = "удалитьИнгредиентToolStripMenuItem";
            this.удалитьИнгредиентToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.удалитьИнгредиентToolStripMenuItem.Text = "Удалить ингредиент";
            this.удалитьИнгредиентToolStripMenuItem.Click += new System.EventHandler(this.удалитьИнгредиентToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(775, 410);
            this.dataGridView.TabIndex = 1;
            // 
            // FormIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormIngredients";
            this.Text = "FormIngredients";
            this.Load += new System.EventHandler(this.FormIngredients_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьИнгредиентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьИнгредиентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьИнгредиентToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}