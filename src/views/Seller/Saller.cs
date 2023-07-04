namespace Views
{
    public class ListSeller : Form
    {
        ListView listSeller;

        private void AddListView(Models.Seller seller)
        {
            string[]row = 
            {
                seller.SellerId.ToString(),
                seller.Name,
                seller.Email,
                seller.Telephone,
                seller.Registration.ToString()
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
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Seller seller = GetSelectedSeller(Option.Update);
                RefreshList();
                var SellerUpdateView = new Views.UpdateSeller(seller);
                if(SellerUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Vendedor editado com sucesso.");
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
                Models.Seller seller = GetSelectedSeller(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza?", "Deletar Vendedor", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Models.Seller.DeleteSeller(seller.SellerId);
                    RefreshList();
                    MessageBox.Show("Vendedor deletado com sucesso.");
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

            listSeller = new ListView();
            listSeller.Size = new Size(700, 300);
            listSeller.Location = new Point(50, 50);
            listSeller.View = View.Details;
            listSeller.Columns.Add("Id");
            listSeller.Columns.Add("Nome");
            listSeller.Columns.Add("Email");
            listSeller.Columns.Add("Telefone");
            listSeller.Columns.Add("Matrícula");
            listSeller.Columns[0].Width = 30;
            listSeller.Columns[1].Width = 100;
            listSeller.Columns[2].Width = 100;
            listSeller.Columns[3].Width = 100;
            listSeller.Columns[4].Width = 100;
            listSeller.FullRowSelect = true;
            this.Controls.Add(listSeller);

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