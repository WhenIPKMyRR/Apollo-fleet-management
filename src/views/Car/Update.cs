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
        public ComboBox txtModelId;
        public ComboBox txtBrandId;
        public Label lblGarageId;
        public ComboBox txtGarageId;
        public Label lblIsUsed;
        public RadioButton radioIsUsed;
        public RadioButton radioIsNotUsed;
        public Button btUpdate;
        public Button btClose;
        public TableLayoutPanel panel;
        public Models.Car car;



        public static List<Models.Model> GetModelsToComboBox(){
            List<Models.Model> models = new List<Models.Model>();
            foreach(Models.Model model in Controllers.Model.ReadAllModels()){
                if((model.ModelId != 0) && (model.Name != null)){
                    models.Add(model);
                }
            }

            return models;
        } 

        public static List<Models.Brand> GetBrandsToComboBox(){
            List<Models.Brand> brands = new List<Models.Brand>();
            foreach(Models.Brand brand in Models.Brand.ReadAllBrands()){
                if((brand.BrandId != 0) && (brand.Name != null)){
                    brands.Add(brand);
                }
            }

            return brands;
        } 

        public static List<Models.Garage> GetGaragesToComboBox(){
            List<Models.Garage> garages = new List<Models.Garage>();
            foreach(Models.Garage garage in Controllers.Garage.ReadAllGarages()){
                if((garage.GarageId != 0) && (garage.Name != null)){
                    garages.Add(garage);
                }
            }

            return garages;
        } 


        public void btUdpate_Click(object sender, EventArgs e)
        {
            try 
            {
                int year = int.Parse(txtYear.Text);
                string color = txtColor.Text;
                string licensePlate = txtLicensePlate.Text;
                string bodyworkType = txtBodyworkType.Text;
                int price = Convert.ToInt32(txtPrice.Text);
                string chassisCode = txtChassisCode.Text;
                string renavanCode = txtRenavanCode.Text;
                string fuelType = txtFuelType.Text;
                string carTransmissionType = txtCarTransmissionType.Text;
                int carMileage = int.Parse(txtCarMileage.Text);
                bool IsUsed = radioIsUsed.Checked;
                int modelId = Convert.ToInt32(txtModelId.SelectedValue);
                int brandId = Convert.ToInt32(txtBrandId.SelectedValue);
                int garageId = Convert.ToInt32(txtGarageId.SelectedValue);

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
                    IsUsed,
                    modelId,
                    brandId,
                    garageId
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
        public UpdateCar(Models.Car car)
        {
            this.car = car;

             this.Text = "Edição";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(590, 620);
            this.BackColor = ColorTranslator.FromHtml("#f8f8f8");

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar Carro";
            this.lblTitle.Font = new Font("Segoe UI", 15, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(190, 30);
            this.lblTitle.Size = new Size(250, 40);


            this.lblYear = new Label();
            this.lblYear.Text = "Ano:";
            this.lblYear.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblYear.Size = new Size(70, 20);

            this.txtYear = new ComboBox();
            this.txtYear.Text = car.Year.ToString();
            this.txtYear.Location = new Point(33, lblYear.Bottom + 5);
            this.txtYear.Size = new Size(220, 20);
            this.txtYear.Font = new Font("Arial", 10, FontStyle.Regular);
            this.txtYear.ForeColor = ColorTranslator.FromHtml("#242424");
            this.txtYear.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            this.txtYear.FlatStyle = FlatStyle.Flat;
            ComboBoxAno();
            this.Controls.Add(txtYear);

            this.lblColor = new Label();
            this.lblColor.Text = "Cor:";
            this.lblColor.Location = new Point(320, lblTitle.Bottom + 10);
            this.lblColor.Size = new Size(70, 20);

            this.txtColor = new TextBox();
            this.txtColor.Text = car.Color;
            this.txtColor.Location = new Point(320, txtYear.Bottom - 23);
            this.txtColor.BorderStyle = BorderStyle.FixedSingle;
            this.txtColor.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.txtColor.Size = new Size(220, 20);

            this.lblBodyworkType = new Label();
            this.lblBodyworkType.Text = "Carroceria:";
            this.lblBodyworkType.Location = new Point(33, txtColor.Bottom + 10);
            this.lblBodyworkType.Size = new Size(110, 20);

            this.txtBodyworkType = new ComboBox();
            this.txtBodyworkType.Text = car.BodyworkType;
            this.txtBodyworkType.Location = new Point(33, lblBodyworkType.Bottom + 5);
            this.txtBodyworkType.Font = new Font("Arial", 10, FontStyle.Regular);
            this.txtBodyworkType.ForeColor = ColorTranslator.FromHtml("#242424");
            this.txtBodyworkType.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            this.txtBodyworkType.FlatStyle = FlatStyle.Flat;
            this.txtBodyworkType.Size = new Size(220, 20);
            this.txtBodyworkType.Items.Add("Conversível");
            this.txtBodyworkType.Items.Add("Coupé");
            this.txtBodyworkType.Items.Add("Hatch");
            this.txtBodyworkType.Items.Add("Picape");
            this.txtBodyworkType.Items.Add("Sedan");
            this.txtBodyworkType.Items.Add("SUV");
            this.txtBodyworkType.Items.Add("Van");
            this.txtBodyworkType.Items.Add("Wagon");
            

            this.lblLicensePlate = new Label();
            this.lblLicensePlate.Text = "Placa:";
            this.lblLicensePlate.Location = new Point(320, lblBodyworkType.Bottom - 20);
            this.lblLicensePlate.Size = new Size(110, 20);

            this.txtLicensePlate = new TextBox();
            this.txtLicensePlate.Text = car.LicensePlate;
            this.txtLicensePlate.BorderStyle = BorderStyle.FixedSingle;
            this.txtLicensePlate.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.txtLicensePlate.Location = new Point(320, lblLicensePlate.Bottom + 5);
            this.txtLicensePlate.Size = new System.Drawing.Size(220, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new Point(33, txtBodyworkType.Bottom + 10);
            this.lblPrice.Size = new Size(70, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Text = car.Price.ToString();
            this.txtPrice.Location = new Point(33, lblPrice.Bottom + 5);
            this.txtPrice.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrice.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.txtPrice.Size = new Size(220, 20);


            this.lblChassisCode = new Label();
            this.lblChassisCode.Text = "Código do Chassis:";
            this.lblChassisCode.Location = new Point(320, lblPrice.Bottom - 20);
            this.lblChassisCode.Size = new Size(120, 20);

            this.txtChassisCode = new TextBox();
            this.txtChassisCode.Text = car.ChassisCode;
            this.txtChassisCode.Location = new Point(320, txtPrice.Bottom - 23);
            this.txtChassisCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtChassisCode.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.txtChassisCode.Size = new Size(220, 20);

            this.lblFuelType = new Label();
            this.lblFuelType.Text = "Combustível";
            this.lblFuelType.Location = new Point(33, txtChassisCode.Bottom + 10);
            this.lblFuelType.Size = new Size(120, 20);

            this.txtFuelType = new ComboBox();
            this.txtFuelType.Text = car.FuelType;
            this.txtFuelType.Location = new Point(33, lblFuelType.Bottom + 5);
            this.txtFuelType.Size = new Size(220, 20);
            this.txtFuelType.ForeColor = ColorTranslator.FromHtml("#242424");
            this.txtFuelType.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            this.txtFuelType.FlatStyle = FlatStyle.Flat;
            this.txtFuelType.Items.Add("Álcool");
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
            this.txtRenavanCode.Text = car.RenavanCode;
            this.txtRenavanCode.Location = new Point(320, txtFuelType.Bottom - 23);
            this.txtRenavanCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtRenavanCode.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.txtRenavanCode.Size = new Size(220, 20);

            this.lblCarTransmissionType = new Label();
            this.lblCarTransmissionType.Text = "Transmissão:";
            this.lblCarTransmissionType.Location = new Point(33, txtFuelType.Bottom + 10);
            this.lblCarTransmissionType.Size = new Size(140, 20);

            this.txtCarTransmissionType = new ComboBox();
            this.txtCarTransmissionType.Text = car.TransmissionType;
            this.txtCarTransmissionType.Location = new Point(33, lblCarTransmissionType.Bottom + 5);
            this.txtCarTransmissionType.ForeColor = ColorTranslator.FromHtml("#242424");
            this.txtCarTransmissionType.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            this.txtCarTransmissionType.FlatStyle = FlatStyle.Flat;
            this.txtCarTransmissionType.Size = new Size(220, 20);
            this.txtCarTransmissionType.Items.Add("Manual");
            this.txtCarTransmissionType.Items.Add("Automático");
            this.txtCarTransmissionType.Items.Add("Automatizado");
            
            this.lblCarMileage = new Label();
            this.lblCarMileage.Text = "Quilometragem:";
            this.lblCarMileage.Location = new Point(320, lblCarTransmissionType.Bottom - 20);
            this.lblCarMileage.Size = new Size(110, 20);

            this.txtCarMileage = new TextBox();
            this.txtCarMileage.Text = car.CarMileage.ToString();
            this.txtCarMileage.Location = new Point(320, txtCarTransmissionType.Bottom - 23);
            this.txtCarMileage.BorderStyle = BorderStyle.FixedSingle;
            this.txtCarMileage.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.txtCarMileage.Size = new Size(220, 20);

                        
            this.lblModelId = new Label();
            this.lblModelId.Text = "Modelo:";
            this.lblModelId.Location = new Point(33, txtCarMileage.Bottom + 10);
            this.lblModelId.Size = new Size(70, 20);

            this.txtModelId = new ComboBox();
            this.txtModelId.Text = car.ModelId.ToString();
            this.txtModelId.Location = new Point(33, lblModelId.Bottom + 5);
            this.txtModelId.Size = new Size(220, 20);
            this.txtModelId.ForeColor = ColorTranslator.FromHtml("#242424");
            this.txtModelId.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            this.txtModelId.FlatStyle = FlatStyle.Flat;
            this.txtModelId.ValueMember = "ModelId";
            this.txtModelId.DisplayMember = "Name";
            this.txtModelId.DataSource = GetModelsToComboBox();
            if (txtModelId.Items.Count > 0)
            {
                txtModelId.SelectedIndex = 0;
            }
            this.txtModelId.Size = new Size(220, 20);

            this.lblBrandId = new Label();
            this.lblBrandId.Text = "Marca:";
            this.lblBrandId.Location = new Point(320, lblModelId.Bottom - 20);
            this.lblBrandId.Size = new Size(70, 20);

            this.txtBrandId = new ComboBox();
            this.txtBrandId.Text = car.BrandId.ToString();
            this.txtBrandId.Location = new Point(320, txtModelId.Bottom - 23);
            this.txtBrandId.ForeColor = ColorTranslator.FromHtml("#242424");
            this.txtBrandId.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            this.txtBrandId.FlatStyle = FlatStyle.Flat;
            this.txtBrandId.ValueMember = "BrandId";
            this.txtBrandId.DisplayMember = "Name";
            this.txtBrandId.DataSource = GetBrandsToComboBox();
            if (txtBrandId.Items.Count > 0)
            {
                txtBrandId.SelectedIndex = 0;
            }
            this.txtBrandId.Size = new Size(220, 20);

            this.lblGarageId = new Label();
            this.lblGarageId.Text = "Garagem:";
            this.lblGarageId.Location = new Point(32, txtBrandId.Bottom + 20);
            this.lblGarageId.Size = new Size(70, 20);

            this.txtGarageId = new ComboBox();
            this.txtGarageId.Text = car.GarageId.ToString();
            this.txtGarageId.Location = new Point(32, lblGarageId.Bottom + 5);
            this.txtGarageId.ForeColor = ColorTranslator.FromHtml("#242424");
            this.txtGarageId.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            this.txtGarageId.FlatStyle = FlatStyle.Flat;
            this.txtGarageId.ValueMember = "GarageId";
            this.txtGarageId.DisplayMember = "Name";
            this.txtGarageId.DataSource = GetGaragesToComboBox();
            if (txtGarageId.Items.Count > 0)
            {
                txtGarageId.SelectedIndex = 0;
            }
            this.txtGarageId.Size = new Size(220, 20);

            this.lblIsUsed = new Label();
            this.lblIsUsed.Text = "Estado:";
            this.lblIsUsed.Location = new Point(320, txtBrandId.Bottom + 20);
            this.lblIsUsed.Size = new Size(70, 20);

            this.radioIsUsed = new RadioButton();
            this.radioIsUsed.Location = new Point(320, lblIsUsed.Bottom + 5);
            this.radioIsUsed.Size = new Size(90, 20);
            this.radioIsUsed.FlatStyle = FlatStyle.Flat;
            this.radioIsUsed.Text = "Seminovo";
            if (!car.IsUsed)
            {
                this.radioIsUsed.Checked = true;
            }


            this.radioIsNotUsed = new RadioButton();
            this.radioIsNotUsed.Location = new Point(420, lblIsUsed.Bottom + 5);
            this.radioIsNotUsed.Size = new Size(90, 20);
            this.radioIsNotUsed.FlatStyle = FlatStyle.Flat;
            this.radioIsNotUsed.Text = "Usado";
            if (car.IsUsed)
            {
                this.radioIsNotUsed.Checked = true;
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

            for (int i = 0; i < panel.ColumnCount; i++)
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
            this.btUpdate.Click += new EventHandler(btUdpate_Click);

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
            
            this.panel.Controls.Add(btUpdate, 2, 0);
            this.panel.Controls.Add(btClose, 3, 0);

            this.Controls.Add(lblModelId);
            this.Controls.Add(txtModelId);
            this.Controls.Add(lblBrandId);
            this.Controls.Add(txtBrandId);
            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblYear);
            this.Controls.Add(txtYear);
            this.Controls.Add(lblColor);
            this.Controls.Add(txtColor);
            this.Controls.Add(lblLicensePlate);
            this.Controls.Add(txtLicensePlate);
            this.Controls.Add(lblBodyworkType);
            this.Controls.Add(txtBodyworkType);
            this.Controls.Add(lblPrice);
            this.Controls.Add(txtPrice);
            this.Controls.Add(lblChassisCode);
            this.Controls.Add(txtChassisCode);
            this.Controls.Add(lblRenavanCode);
            this.Controls.Add(txtRenavanCode);
            this.Controls.Add(lblFuelType);
            this.Controls.Add(txtFuelType);
            this.Controls.Add(lblCarTransmissionType);
            this.Controls.Add(txtCarTransmissionType);
            this.Controls.Add(lblCarMileage);
            this.Controls.Add(txtCarMileage);
            this.Controls.Add(lblGarageId);
            this.Controls.Add(txtGarageId);
            this.Controls.Add(lblIsUsed);
            this.Controls.Add(radioIsUsed);
            this.Controls.Add(radioIsNotUsed);
        }
    }
}