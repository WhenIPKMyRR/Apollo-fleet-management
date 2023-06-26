namespace Views
{
    public class UpdateCar : Form
    {
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
            this.Text = "Update Car";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(400, 650);

            this.lblYear = new Label();
            this.lblYear.Text = "Year";
            this.lblYear.Location = new Point(10, 40);
            this.lblYear.Size = new Size(50, 20);

            this.txtYear = new TextBox();
            this.txtYear.Location = new Point(80, 40);
            this.txtYear.Size = new Size(150, 20);

            this.lblColor = new Label();
            this.lblColor.Text = "Color";
            this.lblColor.Location = new Point(10, 70);
            this.lblColor.Size = new Size(50, 20);

            this.txtColor = new TextBox();
            this.txtColor.Location = new Point(80, 70);
            this.txtColor.Size = new Size(150, 20);

            this.lblLicensePlate = new Label();
            this.lblLicensePlate.Text = "Licence Plate";
            this.lblLicensePlate.Location = new Point(10, 110);
            this.lblLicensePlate.Size = new Size(50, 20);

            this.txtLicensePlate = new TextBox();
            this.txtLicensePlate.Location = new Point(80, 110);
            this.txtLicensePlate.Size = new Size(150, 20);

            this.lblBodyworkType = new Label();
            this.lblBodyworkType.Text = "Body Work";
            this.lblBodyworkType.Location = new Point(10, 140);
            this.lblBodyworkType.Size = new Size(50, 20);

            this.txtBodyworkType = new TextBox();
            this.txtBodyworkType.Location = new Point(80, 140);
            this.txtBodyworkType.Size = new Size(150, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Price";
            this.lblPrice.Location = new Point(10, 180);
            this.lblPrice.Size = new Size(50, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Location = new Point(80, 180);
            this.txtPrice.Size = new Size(150, 20);

            this.lblChassisCode = new Label();
            this.lblChassisCode.Text = "Chasis Code";
            this.lblChassisCode.Location = new Point(10, 220);
            this.lblChassisCode.Size = new Size(50, 20);

            this.txtChassisCode = new TextBox();
            this.txtChassisCode.Location = new Point(80, 220);
            this.txtChassisCode.Size = new Size(150, 20);

            this.lblRenavanCode = new Label();
            this.lblRenavanCode.Text = "Renavam Code";
            this.lblRenavanCode.Location = new Point(10, 260);
            this.lblRenavanCode.Size = new Size(50, 20);

            this.txtRenavanCode = new TextBox();
            this.txtRenavanCode.Location = new Point(80, 260);
            this.txtRenavanCode.Size = new Size(150, 20);

            this.lblFuelType = new Label();
            this.lblFuelType.Text = "Fuel Type";
            this.lblFuelType.Location = new Point(10, 300);
            this.lblFuelType.Size = new Size(50, 20);

            this.txtFuelType = new TextBox();
            this.txtFuelType.Location = new Point(80, 300);
            this.txtFuelType.Size = new Size(150, 20);

            this.lblCarTransmissionType = new Label();
            this.lblCarTransmissionType.Text = "Transmission Type";
            this.lblCarTransmissionType.Location = new Point(10, 340);
            this.lblCarTransmissionType.Size = new Size(50, 20);

            this.txtCarTransmissionType = new TextBox();
            this.txtCarTransmissionType.Location = new Point(80, 340);
            this.txtCarTransmissionType.Size = new Size(150, 20);

            this.lblCarMileage = new Label();
            this.lblCarMileage.Text = "Car Mileage";
            this.lblCarMileage.Location = new Point(10, 380);
            this.lblCarMileage.Size = new Size(50, 20);

            this.txtCarMileage = new TextBox();
            this.txtCarMileage.Location = new Point(80, 380);
            this.txtCarMileage.Size = new Size(150, 20);

            this.lblModelId = new Label();
            this.lblModelId.Text = "Model";
            this.lblModelId.Location = new Point(10, 420);
            this.lblModelId.Size = new Size(50, 20);

            this.txtModelId = new TextBox();
            this.txtModelId.Location = new Point(80, 420);
            this.txtModelId.Size = new Size(150, 20);

            this.lblBrandId = new Label();
            this.lblBrandId.Text = "Brand";
            this.lblBrandId.Location = new Point(10, 460);
            this.lblBrandId.Size = new Size(50, 20);

            this.txtBrandId = new TextBox();
            this.txtBrandId.Location = new Point(80, 460);
            this.txtBrandId.Size = new Size(150, 20);

            this.btUpdate = new Button();
            this.btUpdate.Location = new Point(10, 550);
            this.btUpdate.Size = new Size(100, 20);
            this.btUpdate.Click += new EventHandler(this.btUdpate_Click);

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