namespace Views
{
    public class ListModel : Form
    {
        ListView listModel;

        private void AddListView(Models.Model model)
        {
            string[]row = 
            {
                model.ModelId.ToString(),
                model.Name,
                model.BrandId.ToString()
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
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Model model = GetSelectedModel(Option.Update);
                RefreshList();
                var ModelUpdateView = new Views.UpdateModel(model);
                if(ModelUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Modelo editado com sucesso.");
                }
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
                    RefreshList();
                    MessageBox.Show("Modelo deletado com sucesso.");
                }
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
            this.Size = new System.Drawing.Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = ColorTranslator.FromHtml("#f8f8f8");

            listModel = new ListView();
            listModel.Size = new Size(700, 300);
            listModel.Location = new Point(50, 50);
            listModel.View = View.Details;
            listModel.Columns.Add("Id");
            listModel.Columns.Add("Nome");
            listModel.Columns.Add("Marca");
            listModel.Columns[0].Width = 30;
            listModel.Columns[1].Width = 150;
            listModel.Columns[2].Width = 150;
            listModel.FullRowSelect = true;
            this.Controls.Add(listModel);

            RefreshList();

            Button btCrt = new Button();
            btCrt.Text = "Adicionar";
            btCrt.Size = new Size(100, 30);
            btCrt.Location = new Point(50, 330);
            btCrt.Click += new EventHandler(btCrt_Click);
            this.Controls.Add(btCrt);

            Button btUpdate = new Button();
            btUpdate.Text = "Editar";
            btUpdate.Size = new Size(100, 30);
            btUpdate.Location = new Point(170, 330);
            btUpdate.Click += new EventHandler(btUdpate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Deletar";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(290, 330);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Sair";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(450, 330);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}