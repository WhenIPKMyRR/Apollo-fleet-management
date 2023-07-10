using Models;
using Controllers;

namespace Views
{
    public class ListGarage : Form
    {
        ListView listGarage;

        private void AddListView_Click(Models.Garage garage)
        {
            string[] row = 
            {
                garage.GarageId.ToString(),
                garage.Name,
                garage.Address,
                garage.PhoneNumber
            };

            ListViewItem item = new ListViewItem(row);
            listGarage.Items.Add(item);
        }

        public void RefreshList()
        {
            listGarage.Items.Clear();

            IEnumerable<Models.Garage> list = Models.Garage.ReadAllGarages();

            foreach (Models.Garage garage in list)
            {
                AddListView_Click(garage);
            }
        }

        public Models.Garage GetSelectedGarage(Option option)
        {
            if(listGarage.SelectedItems.Count > 0)
            {
                int selectedGarageId = int.Parse(listGarage.SelectedItems[0].Text);
                return Models.Garage.ReadGarageById(selectedGarageId);
            }
            else 
            {
                throw new Exception($"Selecione uma garagem para {(option == Option.Update? "editar" : "deletar")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateGarage = new Views.CreateGarage();
            CreateGarage.ShowDialog();

            RefreshList();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Garage garage = GetSelectedGarage(Option.Update);
                var UpdateGarage = new Views.UpdateGarage(garage);
                UpdateGarage.ShowDialog();

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
                Models.Garage garage = GetSelectedGarage(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza ?", "Deletar garagem", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Models.Garage.DeleteGarage(garage.GarageId);
                    MessageBox.Show("Garagem deletada com sucesso.");
                    RefreshList();
                }
            }catch(Exception err)
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

        public ListGarage()
        {
            this.Text = "Garagem";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = ColorTranslator.FromHtml("#F8F8F8");

            listGarage = new ListView();
            listGarage.Size = new Size(680, 260);
            listGarage.Location = new Point(50, 50);
            listGarage.BackColor = ColorTranslator.FromHtml("#ffffff");
            listGarage.Font = new Font("Arial", 10, FontStyle.Regular);
            listGarage.ForeColor = ColorTranslator.FromHtml("#242424");
            listGarage.FullRowSelect = true;
            listGarage.AllowColumnReorder = true;
            listGarage.BorderStyle = BorderStyle.FixedSingle;  
            listGarage.MultiSelect = true;
            listGarage.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listGarage.View = View.Details;
            listGarage.Columns.Add("Id");
            listGarage.Columns.Add("Nome");
            listGarage.Columns.Add("Endereço");
            listGarage.Columns.Add("Telefone");
            listGarage.Columns[0].Width = 30;
            listGarage.Columns[1].Width = 150;
            listGarage.Columns[2].Width = 200;
            listGarage.Columns[3].Width = 150;
            listGarage.FullRowSelect = true;
            this.Controls.Add(listGarage);

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