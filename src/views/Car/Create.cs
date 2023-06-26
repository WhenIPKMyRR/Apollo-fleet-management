// namespace Views
// {
//     public class Create : Form
//     {
//         public Label lblYear;
// //      public Label lblColor;
// //      public Label lblLicensePlate;
// //      public Label lblBodyworkType;
// //      public Label lblPrice;
// //      public Label lblChassisCode;
// //      public Label lblRenavanCode;
// //      public Label lblFuelType;
// //      public Label lblCarTransmissionType;
// //      public Label lblCarMileage;
// //      public Label lblIdModel;
// //      public Label lblIdBrand;
// //      public TextBox txtYear;
// //      public TextBox txtColor;
// //      public TextBox txtLicensePlate;
// //      public TextBox txtBodyworkType;
// //      public TextBox txtPrice;
// //      public TextBox txtChassisCode;
// //      public TextBox txtRenavanCode;
// //      public TextBox txtFuelType;
// //      public TextBox txtCarTransmissionType;
// //      public TextBox txtCarMileage;
// //      public TextBox txtIdModel;
// //      public TextBox txtIdBrand;

//         public Button btCrt;

//         public void btCrt_Click(object sender, EventArgs e)
//         {
//             if
//             (
//                 txtYear.Text == "" ||
//                 txtColor.Text == "" ||
//                 txtLicensePlate.Text == "" ||
//                 txtBodyworkType.Text == "" ||
//                 txtPrice.Text == "" ||
//                 txtChassisCode.Text == "" ||
//                 txtRenavamCode.Text == "" ||
//                 txtFuelType.Text == "" ||
//                 txtCarTransmissionType.Text == "" ||
//                 txtCarMileage.Text == "" ||
//                 txtIdModel.Text == "" ||
//                 txtIdBrand.Text == ""
//             )

//             {
//                 MessageBox.Show("Please fill all the fields");
//                 return;
//             }
//             else
//             {

//             }
//         }
//     }

//     public Create()
//     {
//         this.Text = "Create Car";
//         this.StartPosition = FormStartPosition.CenterScreen;
//         this.FormBorderStyle = FormBorderStyle.FixedSingle;
//         this.MaximizeBox = false;
//         this.MinimizeBox = false;
//         this.ShowIcon = false;
//         this.ShowInTaskbar = false;
//         this.Size = new System.Drawing.Size(280, 360);

//         this.lblYear = new Label();
// //      this.lblYear.Text = "Year";
// //      this.lblYear.Location = new Point(10, 40);
// //      this.lblYear.Size = new Size(50, 20);

// //      this.txtYear = new TextBox();
// //      this.txtYear.Location = new Point(80, 40);
// //      this.txtYear.Size = new Size(150, 20);

// //      this.lblColor = new Label();
// //      this.lblColor.Text = "Color";
// //      this.lblColor.Location = new Point(10, 70);
// //      this.lblColor.Size = new Size(50, 20);

// //      this.txtColor = new TextBox();
// //      this.txtColor.Location = new Point(80, 70);
// //      this.txtColor.Size = new Size(150, 20);

// //      this.lblLicensePlate = new Label();
// //      this.lblLicensePlate.Text = "Licence Plate";
// //      this.lblLicensePlate.Location = new Point(10, 110);
// //      this.lblLicensePlate.Size = new Size(50, 20);

// //      this.txtLicensePlate = new TextBox();
// //      this.txtLicensePlate.Location = new Point(80, 110);
// //      this.txtLicensePlate.Size = new Size(150, 20);

// //      this.lblBodyworkType = new Label();
// //      this.lblBodyworkType.Text = "Body Work";
// //      this.lblBodyworkType.Location = new Point(10, 140);
// //      this.lblBodyworkType.Size = new Size(50, 20);

// //      this.txtBodyworkType = new TextBox();
// //      this.txtBodyworkType.Location = new Point(80, 140);
// //      this.txtBodyworkType.Size = new Size(150, 20);

// //      this.lblPrice = new Label();
// //      this.lblPrice.Text = "Price";
// //      this.lblPrice.Location = new Point(10, 180);
// //      this.lblPrice.Size = new Point(50, 20);

// //      this.txtPrice = new TextBox();
// //      this.txtPrice.Location = new Point(80, 180);
// //      this.txtPrice.Size = new Size(150, 20);

// //      this.lblChassisCode = new Label();
// //      this.lblChassisCode.Text = "Chasis Code";
// //      this.lblChassisCode.Location = new Point(10, 220);
// //      this.lblChassisCode.Size = new Size(50, 20);

// //      this.txtChassisCode = new TextBox();
// //      this.txtChassisCode.Location = new Point(80, 220);
// //      this.txtChassisCode.Size = new Size(150, 20);

// //      this.lblRenavanCode = new Label();
// //      this.lblRenavanCode.Text = "Renavam Code";
// //      this.lblRenavanCode.Location = new Point(10, 260);
// //      this.lblRenavanCode.Size = new Size(50, 20);

// //      this.txtRenavanCode = new TextBox();
// //      this.txtRenavanCode.Location = new Point(80, 260);
// //      this.txtRenavanCode.Size = new Size(150, 20);

// //      this.lblFuelType = new Label();
// //      this.lblFuelType.Text = "Fuel Type";
// //      this.lblFuelType.Location = new Point(10, 300);
// //      this.lblFuelType.Size = new Size(50, 20);

// //      this.txtFuelType = new TextBox();
// //      this.txtFuelType.Location = new Point(80, 300);
// //      this.txtFuelType.Size = new Size(150, 20);

// //      this.lblCarTransmissionType = new Label();
// //      this.lblCarTransmissionType.Text = "Transmission Type";
// //      this.lblCarTransmissionType.Location = new Point(10, 340);
// //      this.lblCarTransmissionType.Size = new Size(50, 20);

// //      this.txtCarTransmissionType = TextBox();
// //      this.txtCarTransmissionType.Location = new Point(80, 340);
// //      this.txtCarTransmissionType.Size = new Size(150, 20);

// //      this.lblCarMileage = new Label();
// //      this.lblCarMileage.Text = "Car Mileage";
// //      this.lblCarMileage.Location = new Point(10, 380);
// //      this.lblCarMileage.Size = new Size(50, 20);

// //      this.txtCarMileage = new TextBox();
// //      this.txtCarMileage.Location = new Point(80, 380);
// //      this.txtCarMileage.Size = new Size(150, 20);

// //      this.lblIdModel = new Label();
// //      this.lblIdModel.Text = "Model";
// //      this.lblIdModel.Location = new Point(10, 420);
// //      this.lblIdModel.Size = new Size(50, 20);

// //      this.txtIdModel = new TextBox();
// //      this.txtIdModel.Location = new Point(80, 420);
// //      this.txtIdModel.Size = new Size(150, 20);

// //      this.lblIdBrand = new Label();
// //      this.lblIdBrand.Text = "Brand";
// //      this.lblIdBrand.Location = new Point(10, 460);
// //      this.lblIdBrand.Size = new Size(50, 20);

// //      this.txtIdBrand = new TextBox();
// //      this.txtIdBrand.Location = new Point(80, 460);
// //      this.txtIdBrand.Size = new Size(150, 20);
//     }
// }