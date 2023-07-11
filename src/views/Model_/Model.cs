namespace Views
{
    public class ListModel : Form
    {
        ListView listModel;

        private void AddListView(Models.Model model)
        {
            Models.Brand brand = Controllers.Brand.ReadBrandById(model.BrandId);

            string[]row = 
            {
                model.ModelId.ToString(),
                model.Name,
                brand.Name
            };

            ListViewItem item = new ListViewItem(row);
            listModel.Items.Add(item);
        }

        public void RefreshList()
        {
            listModel.Items.Clear();

            IEnumerable<Models.Model> list = Models.Model.ReadAllModel();

            foreach (Models.Model model in list)
            {
                AddListView(model);
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateModel = new Views.CreateModel();
            CreateModel.Show();

            RefreshList();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Model model = GetSelectedModel(Option.Update);
                var ModelUpdateView = new Views.UpdateModel(model);
                if(ModelUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Modelo editado com sucesso.");
                }

                RefreshList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Model model = GetSelectedModel(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza?", "Deletar Modelo", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Controllers.Model.DeleteModel(model.ModelId);
                    MessageBox.Show("Modelo deletado com sucesso.");
                }

                RefreshList();
            }
            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private Models.Model GetSelectedModel(Option option)
        {
            if(listModel.SelectedItems.Count > 0)
            {
                int selectedModelId = int.Parse(listModel.SelectedItems[0].Text);
                return Models.Model.ReadByIdModel(selectedModelId);
            }
            else
            {
                throw new Exception($"Selecione um modelo para {(option == Option.Update ? "editar" : "deletar")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListModel()
        {
            this.Text = "Modelos";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = ColorTranslator.FromHtml("#F8F8F8");

            listModel = new ListView();
            listModel.Size = new Size(680, 260);
            listModel.Location = new Point(50, 50);
            listModel.BackColor = ColorTranslator.FromHtml("#ffffff");
            listModel.Font = new Font("Arial", 10, FontStyle.Regular);
            listModel.ForeColor = ColorTranslator.FromHtml("#242424");
            listModel.FullRowSelect = true;
            listModel.AllowColumnReorder = true;
            listModel.BorderStyle = BorderStyle.FixedSingle;  
            listModel.MultiSelect = true;
            listModel.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listModel.View = View.Details;
            listModel.Columns.Add("Id");
            listModel.Columns.Add("Nome");
            listModel.Columns.Add("Marca");
            listModel.Columns[0].Width = 30;
            listModel.Columns[1].Width = 180;
            listModel.Columns[2].Width = 180;
            listModel.FullRowSelect = true;
            this.Controls.Add(listModel);

             RefreshList();

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            panel.AutoSize = true;
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            panel.ColumnCount = 8;
            panel.RowCount = 1;
            panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            Button btCrt = new Button();
            btCrt.Text = "Adicionar";
            btCrt.Size = new Size(30, 30);
            // btCrt.Location = new Point(50, 330);
            btCrt.Font = new Font("Roboto", 8, FontStyle.Regular);
            btCrt.FlatStyle = FlatStyle.Flat;
            btCrt.FlatAppearance.BorderSize = 0;
            btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btCrt.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btCrt.Dock = DockStyle.Fill;
            btCrt.Click += new EventHandler(btCrt_Click);
            
            Button btUpdate = new Button();
            btUpdate.Text = "Editar";
            btUpdate.Size = new Size(30, 30);
            //btUpdate.Location = new Point(170, 330);
            btUpdate.Font = new Font("Roboto", 8, FontStyle.Regular);
            btUpdate.FlatStyle = FlatStyle.Flat;
            btUpdate.FlatAppearance.BorderSize = 0;
            btUpdate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btUpdate.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btUpdate.Dock = DockStyle.Fill;
            btUpdate.Click += new EventHandler(btUdpate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Deletar";
            btDelete.Size = new Size(30, 30);
            // btDelete.Location = new Point(290, 330);
            btDelete.Font = new Font("Roboto", 8, FontStyle.Regular);
            btDelete.FlatStyle = FlatStyle.Flat;
            btDelete.FlatAppearance.BorderSize = 0;
            btDelete.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btDelete.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btDelete.Dock = DockStyle.Fill;
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Voltar";
            btClose.Size = new Size(30, 30);
            // btClose.Location = new Point(410, 330);
            btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btClose.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btClose.Font = new Font("Roboto", 8, FontStyle.Regular);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.FlatAppearance.BorderSize = 0;
            btClose.Dock = DockStyle.Fill;
            btClose.Click += (sender, s) =>
            {
                this.Close();
            };
            
            panel.Controls.Add(btCrt, 2, 0);
            panel.Controls.Add(btUpdate, 3, 0);
            panel.Controls.Add(btDelete, 4, 0);
            panel.Controls.Add(btClose, 5, 0); 
            this.Controls.Add(panel);
        }
    }
}