using Models;
using Controllers;

namespace Views
{
    public class ListClient : Form
    {
        ListView listClient;

        private void AddListView_Click(Models.Client client)
        {
            string[] row = 
            {
                client.ClientId.ToString(),
                client.Name,
                client.Telephone,
                client.Address,
                client.Document
            };

            ListViewItem item = new ListViewItem(row);
            listClient.Items.Add(item);
        }

        public void RefreshList()
        {
            listClient.Items.Clear();

            IEnumerable<Models.Client> list = Models.Client.ReadAllClients();

            foreach (Models.Client client in list)
            {
                AddListView_Click(client);
            }
        }

        public Models.Client GetSelectedClient(Option option)
        {
            if(listClient.SelectedItems.Count > 0)
            {
                int selectedClientId = int.Parse(listClient.SelectedItems[0].Text);
                return Models.Client.ReadByIdClient(selectedClientId);
            }
            else
            {
                throw new Exception($"Select a Client to {(option == Option.Update? "Update" : "Delete")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateClient = new Views.CreateClient();
            CreateClient.ShowDialog();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Client client = GetSelectedClient(Option.Update);
                var UpdateClient = new Views.UpdateClient(client);
                UpdateClient.ShowDialog();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Client client = GetSelectedClient(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza?", "Deletar Cliente", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Models.Client.DeleteClient(client.ClientId);
                    RefreshList();
                    MessageBox.Show("Cliente deletado com sucesso.");
                }
            }catch (Exception err)
            {
                if(err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListClient()
        {
            this.Text = "Clientes";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            Color color = ColorTranslator.FromHtml("#F8F8F8");

            listClient = new ListView();
            listClient.Size = new Size(680, 260);
            listClient.Location = new Point(50, 50);
            listClient.View = View.Details;
            listClient.Columns.Add("Id");
            listClient.Columns.Add("Nome");
            listClient.Columns.Add("Telefone");
            listClient.Columns.Add("Endereço");
            listClient.Columns.Add("Documento");
            listClient.Columns[0].Width = 30;
            listClient.Columns[1].Width = 100;
            listClient.Columns[2].Width = 80;
            listClient.Columns[3].Width = 100;
            listClient.Columns[4].Width = 100;
            listClient.FullRowSelect = true;
            this.Controls.Add(listClient);

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