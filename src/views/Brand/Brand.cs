using Models;
using Controllers;

namespace Views
{
    public enum Option {Update, Delete}
    public class ListBrand : Form
    {
        ListView listBrand;
        private void AddListView(Models.Brand brand)
        {
            string[]row = 
            {
                brand.BrandId.ToString(),
                brand.Name
            };

            ListViewItem item = new ListViewItem(row);
            listBrand.Items.Add(item);
        }

        public void RefreshList()
        {
            listBrand.Items.Clear();

            IEnumerable<Models.Brand> list = Models.Brand.ReadAllBrands();

            foreach (Models.Brand brand in list)
            {
                AddListView(brand);
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateBrand = new Views.CreateBrand();
            CreateBrand.Show();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Brand brand = GetSelectedBrand(Option.Update);
                RefreshList();
                var BrandUpdateView = new Views.UpdateBrand(brand);
                if(BrandUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Marca editada com sucesso.");
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
                Models.Brand brand = GetSelectedBrand(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza?", "Deletar Marca", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Models.Brand.DeleteBrand(brand.BrandId);
                    RefreshList();
                }
            }
            catch(Exception err)
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

        public Models.Brand GetSelectedBrand(Option option)
        {
            if(listBrand.SelectedItems.Count > 0)
            {
                int selectedBrandId = int.Parse(listBrand.SelectedItems[0].Text);
                return Models.Brand.ReadBrandById(selectedBrandId);
            }
            else
            {
                throw new Exception($"Selecione uma marca para {(option == Option.Update? "editar" : "deletar" )}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListBrand()
        {
            this.Text = "Marcas";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false; 

            listBrand = new ListView();
            listBrand.Size = new Size(680, 260);
            listBrand.Location = new Point(50, 50);
            listBrand.View = View.Details;
            listBrand.Columns.Add("Id");
            listBrand.Columns.Add("Nome");
            listBrand.Columns[0].Width = 30;
            listBrand.Columns[1].Width = 100;
            listBrand.FullRowSelect = true;
            this.Controls.Add(listBrand);

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