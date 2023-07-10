namespace Views
{ 
    public class UpdateSale : Form

    {
        public Label lblTitle;
        public Label lblDate;
        public Label lblCarId;
        public Label lblClientId;
        public Label lblSellerId;
        public DateTimePicker txtDate;
        public ComboBox txtCarId;
        public ComboBox txtClientId;
        public ComboBox txtSellerId;
        public Button btUpdate;
        public Button btClose;
        public TableLayoutPanel panel;

        public Models.Sale sale;



        public List<KeyValuePair<int, string>> GetModelsCarsToComboBox()
        {
            List<KeyValuePair<int, string>> modelsCars = new List<KeyValuePair<int, string>>();
            
            List<int> soldCarIds = new List<int>();

            foreach (Models.Sale sale in Controllers.Sale.ReadAllSale())
            {
                soldCarIds.Add(sale.CarId);
            }

            foreach (Models.Car car in Controllers.Car.ReadAllCars())
            {
                if (!soldCarIds.Contains(car.CarId))
                {
                    Models.Model modelCar = Controllers.Model.ReadModelById(car.ModelId);
                    modelsCars.Add(new KeyValuePair<int, string>(car.CarId, modelCar.Name));
                }
            }
            
            return modelsCars;
        }


        public static List<Models.Client> GetClientsToComboBox(){
            List<Models.Client> clients = new List<Models.Client>();
            foreach(Models.Client client in Models.Client.ReadAllClients()){
                if((client.ClientId != 0) && (client.Name != null)){
                    clients.Add(client);
                }
            }

            return clients;
        } 

        public static List<Models.Seller> GetSallersToComboBox(){
            List<Models.Seller> sellers = new List<Models.Seller>();
            foreach(Models.Seller seller in Controllers.Seller.ReadAllSeller()){
                if((seller.SellerId != 0) && (seller.Name != null)){
                    sellers.Add(seller);
                }
            }

            return sellers;
        } 


        public void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int carId = Convert.ToInt32(txtCarId.Text);
                int clientId = Convert.ToInt32(txtClientId.Text);
                int sellerId = Convert.ToInt32(txtSellerId.Text);

                Controllers.Sale.UpdateSale(
                    sale.SaleId,
                    carId,
                    clientId,
                    sellerId
                );

                MessageBox.Show("Venda editada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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

            this.Text = "Editar Venda";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 450);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Cadastro de Venda";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblDate = new Label();
            this.lblDate.Text = "Data:";
            this.lblDate.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblDate.Size = new Size(70, 20);

            this.txtDate = new DateTimePicker();
            this.txtDate.Location = new Point(33, lblDate.Bottom + 5);
            this.txtDate.Size = new Size(220, 20);
            txtDate.Format = DateTimePickerFormat.Short;

            this.lblCarId = new Label();
            this.lblCarId.Text = "Carro:";
            this.lblCarId.Location = new Point(33, txtDate.Bottom + 10);
            this.lblCarId.Size = new Size(70, 20);

            this.txtCarId = new ComboBox();
            this.txtCarId.Location = new Point(33, lblCarId.Bottom + 5);
            this.txtCarId.Size = new Size(220, 20);
            this.txtCarId.ValueMember = "Key";
            this.txtCarId.DisplayMember = "Value";
            this.txtCarId.DataSource = GetModelsCarsToComboBox();
            if (txtCarId.Items.Count > 0)
            {
                txtCarId.SelectedIndex = 0;
            }

            this.lblClientId = new Label();
            this.lblClientId.Text = "Cliente:";
            this.lblClientId.Location = new Point(33, txtCarId.Bottom + 10);
            this.lblClientId.Size = new Size(70, 20);
            
            this.txtClientId = new ComboBox();
            this.txtClientId.Location = new Point(33, lblClientId.Bottom + 5);
            this.txtClientId.Size = new Size(220, 20);
            this.txtClientId.ValueMember = "ClientId";
            this.txtClientId.DisplayMember = "Name";
            this.txtClientId.DataSource = GetClientsToComboBox();
            if (txtClientId.Items.Count > 0)
            {
                txtClientId.SelectedIndex = 0;
            }

            this.lblSellerId = new Label();
            this.lblSellerId.Text = "Vendedor:";
            this.lblSellerId.Location = new Point(33, txtClientId.Bottom + 10);
            this.lblSellerId.Size = new Size(70, 20);

            this.txtSellerId = new ComboBox();
            this.txtSellerId.Location = new Point(33, lblSellerId.Bottom + 5);
            this.txtSellerId.Size = new Size(220, 20);
            this.txtSellerId.ValueMember = "SellerId";
            this.txtSellerId.DisplayMember = "Name";
            this.txtSellerId.DataSource = GetSallersToComboBox();
            if (txtSellerId.Items.Count > 0)
            {
                txtSellerId.SelectedIndex = 0;
            }

            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            this.panel.ColumnCount = 4;
            this.panel.RowCount = 1;
            this.panel.ColumnStyles.Clear();

            for (int i = 0; i < 4; i++)
            {
                this.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            this.btUpdate = new Button();
            this.btUpdate.Text = "Adicionar";
            //this.btUpdate.Location = new Point(80, panel.Bottom + 10);
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
            //this.btClose.Location = new Point(80, btUpdate.Bottom + 10);
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
            this.Controls.Add(lblDate);
            this.Controls.Add(txtDate);
            this.Controls.Add(lblCarId);
            this.Controls.Add(txtCarId);
            this.Controls.Add(lblClientId);
            this.Controls.Add(txtClientId);
            this.Controls.Add(lblSellerId);
            this.Controls.Add(txtSellerId);
        }
    }
}