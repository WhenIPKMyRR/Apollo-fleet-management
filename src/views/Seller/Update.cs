namespace Views
{
    public class UpdateSeller : Form
    {
        public Label lblTitle;
        public Label lblName;
        public Label lblEmail;
        public Label lblTelephone;
        public Label lblRegistration;
        public TextBox txtName;
        public TextBox txtEmail;
        public TextBox txtTelephone;
        public TextBox txtRegistration;
        public Button btUdpate;
        public Button btClose;
        public TableLayoutPanel panel;

        public Models.Seller seller;

        public void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string email = txtEmail.Text;
                string telephone = txtTelephone.Text;
                int registration = Convert.ToInt32(txtRegistration.Text);

                Controllers.Seller.UpdateSeller(
                    seller.SellerId,
                    name,
                    email,
                    telephone,
                    registration
                );

                MessageBox.Show("Vendedor editado com sucesso!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            ListSeller SellerList = Application.OpenForms.OfType<ListSeller>().FirstOrDefault();
            if (SellerList != null)
            {
                SellerList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtRegistration.Clear();
        }

        public UpdateSeller(Models.Seller seller)
        {
            this.seller = seller;

            this.Text = "Edição";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false; 
            this.Size = new System.Drawing.Size(300, 450);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar Vendedor";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblName.Size = new Size(70, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new Point(33, lblName.Bottom + 5);
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Size = new Size(220, 20);

            this.lblEmail = new Label();
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(33, txtName.Bottom + 10);
            this.lblEmail.Size = new Size(70, 20);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(33, lblEmail.Bottom + 5);
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            this.txtEmail.Size = new Size(220, 20);

            this.lblTelephone = new Label();
            this.lblTelephone.Text = "Telefone:";
            this.lblTelephone.Location = new Point(33, txtEmail.Bottom + 10);
            this.lblTelephone.Size = new Size(70, 20);

            this.txtTelephone = new TextBox();
            this.txtTelephone.Location = new Point(33, lblTelephone.Bottom + 5);
            this.txtTelephone.BorderStyle = BorderStyle.FixedSingle;
            this.txtTelephone.Size = new Size(220, 20);

            this.lblRegistration = new Label();
            this.lblRegistration.Text = "Matrícula:";
            this.lblRegistration.Location = new Point(33, txtTelephone.Bottom + 10);
            this.lblRegistration.Size = new Size(70, 20);

            this.txtRegistration = new TextBox();
            this.txtRegistration.Location = new Point(33, lblRegistration.Bottom + 5);
            this.txtRegistration.BorderStyle = BorderStyle.FixedSingle;
            this.txtRegistration.Size = new Size(220, 20);

            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#58ACFA");
            this.panel.ColumnCount = 3;
            this.panel.RowCount = 1;
            this.panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                this.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            this.btUdpate = new Button();
            this.btUdpate.Text = "Editar";
            //this.btUdpate.Location = new Point(90, 180);
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

            this.panel.Controls.Add(btUdpate, 1, 0);
            this.panel.Controls.Add(btClose, 2, 0);

            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblTelephone);
            this.Controls.Add(txtTelephone);
            this.Controls.Add(lblRegistration);
            this.Controls.Add(txtRegistration);
        }
    }
}