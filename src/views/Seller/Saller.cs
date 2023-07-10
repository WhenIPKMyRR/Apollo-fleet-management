namespace Views
{
    public class ListSeller : Form
    {
        ListView listSeller;

        private void AddListView(Models.Seller seller)
        {
            string positionEmployee = seller.IsAdm ? "Administrador" : "Vendedor";

            string[]row = 
            {
                seller.SellerId.ToString(),
                seller.Name,
                seller.Email,
                seller.Telephone,
                seller.Registration.ToString(),
                seller.Password,
                positionEmployee
            };

            ListViewItem item = new ListViewItem(row);
            listSeller.Items.Add(item);
        }

        public void RefreshList()
        {
            listSeller.Items.Clear();

            IEnumerable<Models.Seller> list = Models.Seller.ReadAllSeller();

            foreach (Models.Seller seller in list)
            {
                AddListView(seller);
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateSeller = new Views.CreateSeller();
            CreateSeller.Show();

            RefreshList();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Seller seller = GetSelectedSeller(Option.Update);
                var SellerUpdateView = new Views.UpdateSeller(seller);
                if(SellerUpdateView.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Vendedor editado com sucesso.");
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
                Models.Seller seller = GetSelectedSeller(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza?", "Deletar Vendedor", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Models.Seller.DeleteSeller(seller.SellerId);
                    MessageBox.Show("Vendedor deletado com sucesso.");
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

        private Models.Seller GetSelectedSeller(Option option)
        {
            if (listSeller.SelectedItems.Count > 0)
            {
                int selectedSellerId = int.Parse(listSeller.SelectedItems[0].Text);
                return Models.Seller.ReadByIdSeller(selectedSellerId);
            }
            else
            {
                throw new Exception($"Selecione um vendedor para {(option == Option.Update ? "editar" : "deletar")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListSeller()
        {
            this.Text = "Vendedores";
            this.Size = new System.Drawing.Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
           this.BackColor = ColorTranslator.FromHtml("#F8F8F8");

            listSeller = new ListView();
            listSeller.Size = new Size(680, 260);
            listSeller.Location = new Point(50, 50);
            listSeller.BackColor = ColorTranslator.FromHtml("#ffffff");
            listSeller.Font = new Font("Arial", 10, FontStyle.Regular);
            listSeller.ForeColor = ColorTranslator.FromHtml("#242424");
            listSeller.View = View.Details;
            listSeller.Columns.Add("Id");
            listSeller.Columns.Add("Nome");
            listSeller.Columns.Add("Email");
            listSeller.Columns.Add("Telefone");
            listSeller.Columns.Add("Matrícula");
            listSeller.Columns.Add("Senha");
            listSeller.Columns.Add("Posição");
            listSeller.Columns[0].Width = 30;
            listSeller.Columns[1].Width = 200;
            listSeller.Columns[2].Width = 150;
            listSeller.Columns[3].Width = 120;
            listSeller.Columns[4].Width = 120;
            listSeller.Columns[5].Width = 120;
            listSeller.Columns[6].Width = 120;
            listSeller.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listSeller.FullRowSelect = true;
            this.Controls.Add(listSeller);

            RefreshList();   

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            panel.AutoSize = true;
            // panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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