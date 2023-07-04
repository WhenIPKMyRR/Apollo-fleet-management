namespace Views
{ 
    public class UpdateSale : Form

    {
        public Label lblTitle;
        public Label lblDate;
        public Label lblCarId;
        public Label lblClientId;
        public Label lblSellerId;
        public TextBox txtDate;
        public TextBox txtCarId;
        public TextBox txtClientId;
        public TextBox txtSellerId;
        public Button btUpdate;
        public Button btClose;
        public TableLayoutPanel panel;

        public Models.Sale sale;

        public void btUpdate_Click(object sender, EventArgs e)
        {
            Models.Sale saleUpdate = this.sale;
            Controllers.Sale.UpdateSale(
                saleUpdate.SaleId,
                saleUpdate.CarId,
                saleUpdate.ClientId,
                saleUpdate.SellerId
            );
            
            ListSale SaleList = Application.OpenForms.OfType<ListSale>().FirstOrDefault();
            if (SaleList != null)
            {
                SaleList.RefreshList();
            }
            this.Close();
        }

        public UpdateSale(Models.Sale sale)
        {
            this.sale = sale;

            this.Text = "Edição";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 450);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar Venda";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblDate = new Label();
            this.lblDate.Text = "Data:";
            this.lblDate.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblDate.Size = new Size(70, 20);

            this.txtDate = new TextBox();
            this.txtDate.Location = new Point(33, lblDate.Bottom + 5);
            this.txtDate.BorderStyle = BorderStyle.FixedSingle;
            this.txtDate.Size = new Size(220, 20);

            this.lblCarId = new Label();
            this.lblCarId.Text = "Carro:";
            this.lblCarId.Location = new Point(33, txtDate.Bottom + 10);
            this.lblCarId.Size = new Size(70, 20);

            this.txtCarId = new TextBox();
            this.txtCarId.Location = new Point(33, lblCarId.Bottom + 5);
            this.txtCarId.BorderStyle = BorderStyle.FixedSingle;
            this.txtCarId.Size = new Size(220, 20);

            this.lblClientId = new Label();
            this.lblClientId.Text = "Cliente:";
            this.lblClientId.Location = new Point(33, txtCarId.Bottom + 10);
            this.lblClientId.Size = new Size(70, 20);

            this.txtClientId = new TextBox();
            this.txtClientId.Location = new Point(33, lblClientId.Bottom + 5);
            this.txtClientId.BorderStyle = BorderStyle.FixedSingle;
            this.txtClientId.Size = new Size(220, 20);

            this.lblSellerId = new Label();
            this.lblSellerId.Text = "Vendedor:";
            this.lblSellerId.Location = new Point(33, txtClientId.Bottom + 10);
            this.lblSellerId.Size = new Size(70, 20);

            this.txtSellerId = new TextBox();
            this.txtSellerId.Location = new Point(33, lblSellerId.Bottom + 5);
            this.txtSellerId.BorderStyle = BorderStyle.FixedSingle;
            this.txtSellerId.Size = new Size(220, 20);
            
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

            this.btUpdate = new Button();
            this.btUpdate.Text = "Editar";
            //this.btUpdate.Location = new Point(90, 180);
            this.btUpdate.Size = new Size(200, 25);
            this.btUpdate.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btUpdate.FlatStyle = FlatStyle.Flat;
            this.btUpdate.FlatAppearance.BorderSize = 0;
            this.btUpdate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btUpdate.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btUpdate.Dock = DockStyle.Fill;
            this.btUpdate.Click += new EventHandler(btUpdate_Click);

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

            this.panel.Controls.Add(btUpdate, 1, 0);
            this.panel.Controls.Add(btClose, 2, 0);

            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblCarId);
            this.Controls.Add(txtCarId);
            this.Controls.Add(lblClientId);
            this.Controls.Add(txtClientId);
            this.Controls.Add(lblSellerId);
            this.Controls.Add(txtSellerId);
        }
    }
}