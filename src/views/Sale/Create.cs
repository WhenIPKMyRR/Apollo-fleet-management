using Models;
using Controllers;

namespace Views
{
    public class ListSale : Form
    {
        ListView listSale;

        private void AddListView(Models.Sale sale)
        {
            string[] row = 
            {
                sale.SaleId.ToString(),
                sale.CarId.ToString(),
                sale.ClientId.ToString(),
                sale.SellerId.ToString(),
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
                throw new Exception($"Selecione uma opção {(option == Option.Update? "Atualizar" : "Deletar")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateSale = new Views.CreateSale();
            CreateSale.Show();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Sale sale = GetSelectedSale(Option.Update);
                var UpdateSale = new Views.UpdateSale(sale);
                UpdateSale.ShowDialog();
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
                    RefreshList();
                    MessageBox.Show("Venda deletada com sucesso.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ListSale()
        {
            Text = "Listar Vendas";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;

            listSale = new ListView();
            listSale.Size = new Size(780, 500);
            listSale.Location = new Point(10, 10);
            listSale.View = View.Details;
            listSale.FullRowSelect = true;
            listSale.Columns.Add("Id", -2, HorizontalAlignment.Center);
            listSale.Columns.Add("Data", -2, HorizontalAlignment.Center);
            listSale.Columns.Add("Carro", -2, HorizontalAlignment.Center);
            listSale.Columns.Add("Cliente", -2, HorizontalAlignment.Center);
            listSale.Columns.Add("Vendedor", -2, HorizontalAlignment.Center);
            this.Controls.Add(listSale);

            RefreshList();

            Button btCrt = new Button();
            btCrt.Text = "Adicionar";
            btCrt.Location = new Point(10, 520);
            btCrt.Click += new EventHandler(btCrt_Click);
            this.Controls.Add(btCrt);

            Button btUdpate = new Button();
            btUdpate.Text = "Editar";
            btUdpate.Location = new Point(90, 520);
            btUdpate.Click += new EventHandler(btUdpate_Click);
            this.Controls.Add(btUdpate);

            Button btDelete = new Button();
            btDelete.Text = "Deletar";
            btDelete.Location = new Point(170, 520);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btExit = new Button();
            btExit.Text = "Sair";
            btExit.Location = new Point(250, 520);
            btExit.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btExit);
        }   
    }
}