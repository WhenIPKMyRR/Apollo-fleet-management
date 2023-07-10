using Models;
using Controllers;

namespace Views
{
    public class UpdateBrand : Form
    {
        public Label lblTitle;
        public Label lblName;
        public TextBox comboBoxName;
        public Button btUdpate;
        public Button btClose;
        public TableLayoutPanel panel;

        public Models.Brand brand;
        public void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = comboBoxName.Text;

                Controllers.Brand.UpdateBrand(
                    brand.BrandId,
                    name
                );

                MessageBox.Show("Marca editada com sucesso!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            ListBrand BrandList = Application.OpenForms.OfType<ListBrand>().FirstOrDefault();
            if (BrandList != null)
            {
                BrandList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            comboBoxName.Text = "";
        }
        public UpdateBrand(Models.Brand brand)
        {
            this.brand = brand;

            this.Text = "Editar marca";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 300);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Cadastro de Marca";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblName.Size = new Size(70, 20);

            this.comboBoxName = new TextBox();
            this.comboBoxName.Text = brand.Name;
            this.comboBoxName.Location = new Point(33, lblName.Bottom + 5);
            this.comboBoxName.BorderStyle = BorderStyle.FixedSingle;
            this.comboBoxName.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.comboBoxName.Size = new Size(220, 50);



            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            this.panel.ColumnCount = 4;
            this.panel.RowCount = 1;
            this.panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                this.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            this.btUdpate = new Button();
            this.btUdpate.Text = "Adicionar";
            this.btUdpate.Size = new Size(200, 25);
            this.btUdpate.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btUdpate.FlatStyle = FlatStyle.Flat;
            this.btUdpate.FlatAppearance.BorderSize = 0;
            this.btUdpate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btUdpate.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btUdpate.Dock = DockStyle.Fill;
            this.btUdpate.Click += new EventHandler(btUdpate_Click);

            this.btClose = new Button();
            this.btClose.Text = "Fechar";
            this.btClose.Size = new Size(200, 25);
            this.btClose.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btClose.FlatStyle = FlatStyle.Flat;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btClose.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btClose.Dock = DockStyle.Fill;
            this.btClose.Click += (sender, s) =>
            {
                this.Close();
            };
            
            this.panel.Controls.Add(btUdpate, 1, 0);
            this.panel.Controls.Add(btClose, 2, 0);

            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.comboBoxName);
        }
    }
}