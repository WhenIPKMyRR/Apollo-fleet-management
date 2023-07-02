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
        public TextBox txtYear;
        public TextBox txtColor;
        public TextBox txtLicensePlate;
        public TextBox txtBodyworkType;
        public TextBox txtPrice;
        public TextBox txtChassisCode;
        public TextBox txtRenavanCode;
        public TextBox txtFuelType;
        public TextBox txtCarTransmissionType;
        public TextBox txtCarMileage;
        public TextBox txtModelId;
        public TextBox txtBrandId;
        public Button btUpdate;
        public Button btClose;
        public TableLayoutPanel panel;
        public Models.Car car;

        public void btUdpate_Click(object sender, EventArgs e)
        {
            Models.Car carToUpdate = this.car;
            Controllers.Car.UpdateCar(
                carToUpdate.CarId,
                carToUpdate.Year,
                carToUpdate.Color,
                carToUpdate.LicensePlate,
                carToUpdate.BodyworkType,
                carToUpdate.Price,
                carToUpdate.ChassisCode,
                carToUpdate.RenavanCode,
                carToUpdate.FuelType,
                carToUpdate.TransmissionType,
                carToUpdate.CarMileage,
                carToUpdate.ModelId,
                carToUpdate.BrandId
            );

            ListCar CarList = Application.OpenForms.OfType<ListCar>().FirstOrDefault();
            if (CarList == null)
            {
                CarList.RefreshList();
            }
            this.Close();
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
            this.Size = new System.Drawing.Size(300, 900);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar Carro";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblYear = new Label();
            this.lblYear.Text = "Ano:";
            this.lblYear.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblYear.Size = new Size(70, 20);

            this.txtYear = new TextBox();
            this.txtYear.Location = new Point(33, lblYear.Bottom + 5);
            this.txtYear.BorderStyle = BorderStyle.FixedSingle;
            this.txtYear.Size = new Size(220, 20);

            this.lblColor = new Label();
            this.lblColor.Text = "Cor:";
            this.lblColor.Location = new Point(33, txtYear.Bottom + 10);
            this.lblColor.Size = new Size(70, 20);

            this.txtColor = new TextBox();
            this.txtColor.Location = new Point(33, lblColor.Bottom + 5);
            this.txtColor.BorderStyle = BorderStyle.FixedSingle;
            this.txtColor.Size = new Size(220, 20);

            this.lblLicensePlate = new Label();
            this.lblLicensePlate.Text = "Placa:";
            this.lblLicensePlate.Location = new Point(33, txtColor.Bottom + 10);
            this.lblLicensePlate.Size = new Size(110, 20);

            this.txtLicensePlate = new TextBox();
            this.txtLicensePlate.Location = new Point(33, lblLicensePlate.Bottom + 5);
            this.txtLicensePlate.BorderStyle = BorderStyle.FixedSingle;
            this.txtLicensePlate.Size = new Size(220, 20);

            this.lblBodyworkType = new Label();
            this.lblBodyworkType.Text = "Carroceria:";
            this.lblBodyworkType.Location = new Point(33, txtLicensePlate.Bottom + 10);
            this.lblBodyworkType.Size = new Size(100, 20);

            this.txtBodyworkType = new TextBox();
            this.txtBodyworkType.Location = new Point(33, lblBodyworkType.Bottom + 5);
            this.txtBodyworkType.BorderStyle = BorderStyle.FixedSingle;
            this.txtBodyworkType.Size = new Size(220, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new Point(33, txtBodyworkType.Bottom + 10);
            this.lblPrice.Size = new Size(70, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Location = new Point(33, lblPrice.Bottom + 5);
            this.txtPrice.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrice.Size = new Size(220, 20);

            this.lblChassisCode = new Label();
            this.lblChassisCode.Text = "Código do chassis:";
            this.lblChassisCode.Location = new Point(33, txtPrice.Bottom + 10);
            this.lblChassisCode.Size = new Size(120, 20);

            this.txtChassisCode = new TextBox();
            this.txtChassisCode.Location = new Point(33, lblChassisCode.Bottom + 5);
            this.txtChassisCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtChassisCode.Size = new Size(220, 20);

            this.lblRenavanCode = new Label();
            this.lblRenavanCode.Text = "Código renavan:";
            this.lblRenavanCode.Location = new Point(33, txtChassisCode.Bottom + 10);
            this.lblRenavanCode.Size = new Size(120, 20);

            this.txtRenavanCode = new TextBox();
            this.txtRenavanCode.Location = new Point(33, lblRenavanCode.Bottom + 5);
            this.txtRenavanCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtRenavanCode.Size = new Size(220, 20);

            this.lblFuelType = new Label();
            this.lblFuelType.Text = "Combustível:";
            this.lblFuelType.Location = new Point(33, txtRenavanCode.Bottom + 10);
            this.lblFuelType.Size = new Size(100, 20);

            this.txtFuelType = new TextBox();
            this.txtFuelType.Location = new Point(33, lblFuelType.Bottom + 5);
            this.txtFuelType.BorderStyle = BorderStyle.FixedSingle;
            this.txtFuelType.Size = new Size(220, 20);

            this.lblCarTransmissionType = new Label();
            this.lblCarTransmissionType.Text = "Transmissão:";
            this.lblCarTransmissionType.Location = new Point(33, txtFuelType.Bottom + 10);
            this.lblCarTransmissionType.Size = new Size(140, 20);

            this.txtCarTransmissionType = new TextBox();
            this.txtCarTransmissionType.Location = new Point(33, lblCarTransmissionType.Bottom + 5);
            this.txtCarTransmissionType.BorderStyle = BorderStyle.FixedSingle;
            this.txtCarTransmissionType.Size = new Size(220, 20);

            this.lblCarMileage = new Label();
            this.lblCarMileage.Text = "Quilometragem:";
            this.lblCarMileage.Location = new Point(33, txtCarTransmissionType.Bottom + 10);
            this.lblCarMileage.Size = new Size(110, 20);

            this.txtCarMileage = new TextBox();
            this.txtCarMileage.Location = new Point(33, lblCarMileage.Bottom + 5);
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
            this.lblBrandId.Location = new Point(33, txtModelId.Bottom + 10);
            this.lblBrandId.Size = new Size(70, 20);

            this.txtBrandId = new TextBox();
            this.txtBrandId.Location = new Point(33, lblBrandId.Bottom + 5);
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