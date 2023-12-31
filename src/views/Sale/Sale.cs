using Models;
using Controllers;

namespace Views
{
    public class ListSale : Form
    {
        ListView listSale;
        Menu menu = new Menu();


        private void AddListView(Models.Sale sale)
        {
            Models.Car car = Controllers.Car.ReadCarById(sale.CarId);
            Models.Model model = Controllers.Model.ReadModelById(car.ModelId);
            Models.Client client = Controllers.Client.ReadClientById(sale.ClientId);
            Models.Seller seller = Controllers.Seller.ReadSellerById(sale.SellerId);

            string[] row = 
            {
                sale.SaleId.ToString(),
                client.Name.ToString(),
                seller.Name.ToString(),
                model.Name.ToString(),
                sale.Date.ToString()
            };

            ListViewItem item = new ListViewItem(row);
            listSale.Items.Add(item);
        }

        public void RefreshList()
        {
            listSale.Items.Clear();

            IEnumerable<Models.Sale> list = Controllers.Sale.ReadAllSale();

            foreach (Models.Sale sale in list)
            {
                AddListView(sale);
            }
        }

        public Models.Sale GetSelectedSale(Option option)
        {
            if(listSale.SelectedItems.Count > 0)
            {
                int selectedSaleId = int.Parse(listSale.SelectedItems[0].Text);
                return Models.Sale.ReadByIdSale(selectedSaleId);
            }
            else
            {
                throw new Exception($"Selecione uma venda para {(option == Option.Update? "editar" : "deletar")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateSale = new Views.CreateSale();
            CreateSale.Show();

            RefreshList();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Sale sale = GetSelectedSale(Option.Update);
                var UpdateSale = new Views.UpdateSale(sale);
                UpdateSale.ShowDialog();

                RefreshList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Sale sale = GetSelectedSale(Option.Delete);
                if(MessageBox.Show("Tem certeza?", "Deletar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Controllers.Sale.DeleteSale(sale.SaleId);
                    MessageBox.Show("Venda deletada com sucesso.");
                }

                RefreshList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ListSale()
        {
            this.Text = "Listar Vendas";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = ColorTranslator.FromHtml("#F8F8F8");

            listSale = new ListView();
            listSale.Size = new Size(680, 260);
            listSale.Location = new Point(50, 50);
            listSale.Font = new Font("Arial", 10, FontStyle.Regular);
            listSale.ForeColor = ColorTranslator.FromHtml("#242424");
            listSale.FullRowSelect = true;
            listSale.AllowColumnReorder = true;
            listSale.BorderStyle = BorderStyle.FixedSingle;  
            listSale.MultiSelect = true;
            listSale.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listSale.View = View.Details;
            listSale.FullRowSelect = true;
            listSale.Columns.Add("Id");
            listSale.Columns.Add("Cliente");
            listSale.Columns.Add("Vendedor");
            listSale.Columns.Add("Carro");
            listSale.Columns.Add("Data");
            listSale.Columns[0].Width = 30;
            listSale.Columns[1].Width = 150;
            listSale.Columns[2].Width = 120;
            listSale.Columns[3].Width = 120;
            listSale.Columns[4].Width = 100;
            this.Controls.Add(listSale);

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
            
            
            if(Menu.AcessAdmin)
            {
                panel.Controls.Add(btCrt, 2, 0);
                panel.Controls.Add(btUpdate, 3, 0);
                panel.Controls.Add(btDelete, 4, 0);
                panel.Controls.Add(btClose, 5, 0); 

            }
            else
            {
                panel.Controls.Add(btCrt, 3, 0);
                panel.Controls.Add(btClose, 4, 0); 
            }
            this.Controls.Add(panel);
        }   
    }
}