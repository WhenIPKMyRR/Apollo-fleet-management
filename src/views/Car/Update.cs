namespace Views
{
    public class UpdateCar : Form
    {
        public Label lblTitle;
        public Label lblYear;
        public Label lblColor;
        public Label lblLicensePlate;
        public Label lblBodyworkType;
        public Label lblPrice;
        public Label lblChassisCode;
        public Label lblRenavanCode;
        public Label lblFuelType;
        public Label lblCarTransmissionType;
        public Label lblCarMileage;
        public Label lblModelId;
        public Label lblBrandId;
        public ComboBox txtYear;
        public TextBox txtColor;
        public TextBox txtLicensePlate;
        public ComboBox txtBodyworkType;
        public TextBox txtPrice;
        public TextBox txtChassisCode;
        public TextBox txtRenavanCode;
        public ComboBox txtFuelType;
        public ComboBox txtCarTransmissionType;
        public TextBox txtCarMileage;
        public TextBox txtModelId;
        public TextBox txtBrandId;
        public Button btUpdate;
        public Button btClose;
        public TableLayoutPanel panel;
        public Models.Car car;

        public void btUdpate_Click(object sender, EventArgs e)
        {
            try 
            {
                int year = int.Parse(txtYear.Text);
                string color = txtColor.Text;
                string licensePlate = txtLicensePlate.Text;
                string bodyworkType = txtBodyworkType.Text;
                decimal price = decimal.Parse(txtPrice.Text);
                string chassisCode = txtChassisCode.Text;
                string renavanCode = txtRenavanCode.Text;
                string fuelType = txtFuelType.Text;
                string carTransmissionType = txtCarTransmissionType.Text;
                int carMileage = int.Parse(txtCarMileage.Text);
                int modelId = int.Parse(txtModelId.Text);
                int brandId = int.Parse(txtBrandId.Text);

                Models.Car.UpdateCar(
                    car.CarId,
                    year,
                    color,
                    licensePlate,
                    bodyworkType,
                    price,
                    chassisCode,
                    renavanCode,
                    fuelType,
                    carTransmissionType,
                    carMileage,
                    modelId,
                    brandId
                );

                MessageBox.Show("Carro editado com sucesso.");
                ClearForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            ListCar CarList = Application.OpenForms.OfType<ListCar>().FirstOrDefault();
            if (CarList != null)
            {
                CarList.RefreshList();
            }
        }

        private void ClearForm()
        {
            txtColor.Clear();
            txtLicensePlate.Clear();
            txtPrice.Clear();
            txtChassisCode.Clear();
            txtRenavanCode.Clear();
            txtCarMileage.Clear();
            txtModelId.Clear();
            txtBrandId.Clear();
        }

        private void ComboBoxAno()
        {
            int anoAtual = DateTime.Now.Year;

            for (int ano = 1980; ano <= anoAtual; ano++)
            {
                txtYear.Items.Add(ano);
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ComboBoxAno();
        }
        public UpdateCar()
        {
            this.Text = "Editar Carro";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(590, 580);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar Carro";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblYear = new Label();
            this.lblYear.Text = "Ano:";
            this.lblYear.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblYear.Size = new Size(70, 20);

            this.txtYear = new ComboBox();
            this.txtYear.Location = new Point(33, lblYear.Bottom + 5);
            this.txtYear.Size = new Size(220, 20);
            ComboBoxAno();
            this.Controls.Add(txtYear);

            this.lblColor = new Label();
            this.lblColor.Text = "Cor:";
            this.lblColor.Location = new Point(320, lblTitle.Bottom + 10);
            this.lblColor.Size = new Size(70, 20);

            this.txtColor = new TextBox();
            this.txtColor.Location = new Point(320, txtYear.Bottom - 23);
            this.txtColor.BorderStyle = BorderStyle.FixedSingle;
            this.txtColor.Size = new Size(220, 20);

            this.lblBodyworkType = new Label();
            this.lblBodyworkType.Text = "Carroceria:";
            this.lblBodyworkType.Location = new Point(33, txtColor.Bottom + 10);
            this.lblBodyworkType.Size = new Size(110, 20);

            this.txtBodyworkType = new ComboBox();
            this.txtBodyworkType.Location = new Point(33, lblBodyworkType.Bottom + 5);
            this.txtBodyworkType.Size = new Size(220, 20);
            this.txtBodyworkType.Items.Add("Conversível");
            this.txtBodyworkType.Items.Add("Coupé");
            this.txtBodyworkType.Items.Add("Hatch");
            this.txtBodyworkType.Items.Add("Picape");
            this.txtBodyworkType.Items.Add("Sedan");
            this.txtBodyworkType.Items.Add("SUV");

            this.lblLicensePlate = new Label();
            this.lblLicensePlate.Text = "Placa:";
            this.lblLicensePlate.Location = new Point(320, lblBodyworkType.Bottom - 20);
            this.lblLicensePlate.Size = new Size(110, 20);

            this.txtLicensePlate = new TextBox();
            this.txtLicensePlate.Location = new Point(320, txtBodyworkType.Bottom - 23);
            this.txtLicensePlate.BorderStyle = BorderStyle.FixedSingle;
            this.txtLicensePlate.Size = new Size(220, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new Point(33, txtBodyworkType.Bottom + 10);
            this.lblPrice.Size = new Size(70, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Text = "R$";
            this.txtPrice.Location = new Point(33, lblPrice.Bottom + 5);
            this.txtPrice.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrice.Size = new Size(220, 20);

            this.lblChassisCode = new Label();
            this.lblChassisCode.Text = "Código do Chassis:";
            this.lblChassisCode.Location = new Point(320, lblPrice.Bottom - 20);
            this.lblChassisCode.Size = new Size(120, 20);

            this.txtChassisCode = new TextBox();
            this.txtChassisCode.Location = new Point(320, txtPrice.Bottom - 23);
            this.txtChassisCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtChassisCode.Size = new Size(220, 20);

            this.lblFuelType = new Label();
            this.lblFuelType.Text = "Combustível";
            this.lblFuelType.Location = new Point(33, txtChassisCode.Bottom + 10);
            this.lblFuelType.Size = new Size(120, 20);

            this.txtFuelType = new ComboBox();
            this.txtFuelType.Location = new Point(33, lblFuelType.Bottom + 5);
            this.txtFuelType.Size = new Size(220, 20);
            this.txtFuelType.Items.Add("Diesel");
            this.txtFuelType.Items.Add("Elétrico");
            this.txtFuelType.Items.Add("Etanol");
            this.txtFuelType.Items.Add("Flex");
            this.txtFuelType.Items.Add("Gasolina");
            this.txtFuelType.Items.Add("Gás");
            this.txtFuelType.Items.Add("Híbrido");

            this.lblRenavanCode = new Label();
            this.lblRenavanCode.Text = "Código do Renavan:";
            this.lblRenavanCode.Location = new Point(320, lblFuelType.Bottom - 20);
            this.lblRenavanCode.Size = new Size(120, 20);

            this.txtRenavanCode = new TextBox();
            this.txtRenavanCode.Location = new Point(320, txtFuelType.Bottom - 23);
            this.txtRenavanCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtRenavanCode.Size = new Size(220, 20);

            this.lblCarTransmissionType = new Label();
            this.lblCarTransmissionType.Text = "Transmissão:";
            this.lblCarTransmissionType.Location = new Point(33, txtFuelType.Bottom + 10);
            this.lblCarTransmissionType.Size = new Size(140, 20);

            this.txtCarTransmissionType = new ComboBox();
            this.txtCarTransmissionType.Location = new Point(33, lblCarTransmissionType.Bottom + 5);
            this.txtCarTransmissionType.Size = new Size(220, 20);
            this.txtCarTransmissionType.Items.Add("Manual");
            this.txtCarTransmissionType.Items.Add("Automático");
            this.txtCarTransmissionType.Items.Add("Automatizado");
            
            this.lblCarMileage = new Label();
            this.lblCarMileage.Text = "Quilometragem:";
            this.lblCarMileage.Location = new Point(320, lblCarTransmissionType.Bottom - 20);
            this.lblCarMileage.Size = new Size(110, 20);

            this.txtCarMileage = new TextBox();
            this.txtCarMileage.Location = new Point(320, txtCarTransmissionType.Bottom - 23);
            this.txtCarMileage.BorderStyle = BorderStyle.FixedSingle;
            this.txtCarMileage.Size = new Size(220, 20);

            this.lblModelId = new Label();
            this.lblModelId.Text = "Modelo:";
            this.lblModelId.Location = new Point(33, txtCarMileage.Bottom + 10);
            this.lblModelId.Size = new Size(70, 20);

            this.txtModelId = new TextBox();
            this.txtModelId.Location = new Point(33, lblModelId.Bottom + 5);
            this.txtModelId.BorderStyle = BorderStyle.FixedSingle;
            this.txtModelId.Size = new Size(220, 20);

            this.lblBrandId = new Label();
            this.lblBrandId.Text = "Marca:";
            this.lblBrandId.Location = new Point(320, lblModelId.Bottom - 20);
            this.lblBrandId.Size = new Size(70, 20);

            this.txtBrandId = new TextBox();
            this.txtBrandId.Location = new Point(320, txtModelId.Bottom - 23);
            this.txtBrandId.BorderStyle = BorderStyle.FixedSingle;
            this.txtBrandId.Size = new Size(220, 20);
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
            this.btUpdate.Click += new EventHandler(btUdpate_Click);

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
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.lblBodyworkType);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblChassisCode);
            this.Controls.Add(this.lblRenavanCode);
            this.Controls.Add(this.lblFuelType);
            this.Controls.Add(this.lblCarTransmissionType);
            this.Controls.Add(this.lblCarMileage);
            this.Controls.Add(this.lblModelId);
            this.Controls.Add(this.lblBrandId);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.txtBodyworkType);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtChassisCode);
            this.Controls.Add(this.txtRenavanCode);
            this.Controls.Add(this.txtFuelType);
            this.Controls.Add(this.txtCarTransmissionType);
            this.Controls.Add(this.txtCarMileage);
            this.Controls.Add(this.txtModelId);
            this.Controls.Add(this.txtBrandId);
        }
    }
}