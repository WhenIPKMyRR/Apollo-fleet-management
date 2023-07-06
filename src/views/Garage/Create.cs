namespace Views
{
    public class CreateGarage : Form
    {
        public Label lblTitle;
        public Label lblName;
        public Label lblAddress;
        public Label lblPhoneNumber;
        public TextBox txtName;
        public TextBox txtAddress;
        public TextBox txtPhoneNumber;
        public Button btCrt;
        public Button btClose;
        public TableLayoutPanel panel;

        public void btCrt_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string address = txtAddress.Text;
                string phoneNumber = txtPhoneNumber.Text;

                Models.Garage.CreateGarage(
                    name,
                    address,
                    phoneNumber
                );

                MessageBox.Show("Garagem cadastrada com sucesso.");
                ClearForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            ListGarage GarageList = Application.OpenForms.OfType<ListGarage>().FirstOrDefault();
            if (GarageList == null)
            {
                GarageList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();
        }

        public CreateGarage()
        {
            this.Text = "Cadastro";
            this.Size = new Size(300, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            Color color = ColorTranslator .FromHtml("#F8F8F8");

            this.lblTitle = new Label();
            this.lblTitle.Text = "Cadastro de Garagem";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(55, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblName.Size = new Size(70, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new Point(33, lblName.Bottom + 5);
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Size = new Size(220, 20);

            this.lblAddress = new Label();
            this.lblAddress.Text = "Endereço:";
            this.lblAddress.Location = new Point(33, txtName.Bottom + 10);
            this.lblAddress.Size = new Size(70, 20);

            this.txtAddress = new TextBox();
            this.txtAddress.Location = new Point(33, lblAddress.Bottom + 5);
            this.txtAddress.BorderStyle = BorderStyle.FixedSingle;
            this.txtAddress.Size = new Size(220, 20);

            this.lblPhoneNumber = new Label();
            this.lblPhoneNumber.Text = "Telefone:";
            this.lblPhoneNumber.Location = new Point(33, txtAddress.Bottom + 10);
            this.lblPhoneNumber.Size = new Size(70, 20);

            this.txtPhoneNumber = new TextBox();
            this.txtPhoneNumber.Location = new Point(33, lblPhoneNumber.Bottom + 5);
            this.txtPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            this.txtPhoneNumber.Size = new Size(220, 20);

            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            this.panel.ColumnCount = 3;
            this.panel.RowCount = 1;
            this.panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                this.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            this.btCrt = new Button();
            this.btCrt.Text = "Adicionar";
            //this.btCrt.Location = new Point(80, panel.Bottom + 10);
            this.btCrt.Size = new Size(200, 25);
            this.btCrt.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btCrt.FlatStyle = FlatStyle.Flat;
            this.btCrt.FlatAppearance.BorderSize = 0;
            this.btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btCrt.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btCrt.Dock = DockStyle.Fill;
            this.btCrt.Click += new EventHandler(btCrt_Click);

            this.btClose = new Button();
            this.btClose.Text = "Fechar";
            //this.btClose.Location = new Point(80, btCrt.Bottom + 10);
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
            
            this.panel.Controls.Add(btCrt, 1, 0);
            this.panel.Controls.Add(btClose, 2, 0);

            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(lblPhoneNumber);
            this.Controls.Add(txtPhoneNumber);
        }
    }
}