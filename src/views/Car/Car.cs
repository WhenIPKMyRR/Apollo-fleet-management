using Models;
using Controllers;

namespace Views
{
    public class ListCar : Form
    {
        ListView listCar;
        public TableLayoutPanel tableFilters;
        public Label lblBrand;
        public Label lblModel;
        public Label lblGarage;
        public Label lblYear;
        public Label lblEstado;
        public ComboBox cbBrand;
        public ComboBox cbModel;
        public ComboBox cbGarage;
        public ComboBox cbEstado;
        public Button btnFilter;


        public static List<Models.Model> GetModelsToComboBox(){
            List<Models.Model> models = new List<Models.Model>();
            models.Add(new Models.Model{ ModelId=0 , Name=""});
            foreach(Models.Model model in Controllers.Model.ReadAllModels()){
                if((model.ModelId != 0) && (model.Name != null)){
                    models.Add(model);
                }
            }

            return models;
        } 

        public static List<Models.Brand> GetBrandsToComboBox()
        {
            List<Models.Brand> brands = new List<Models.Brand>();

            brands.Add(new Models.Brand { BrandId = 0, Name = "" });

            foreach (Models.Brand brand in Models.Brand.ReadAllBrands())
            {
                if ((brand.BrandId != 0) && (brand.Name != null))
                {
                    brands.Add(brand);
                }
            }

            return brands;
        }

// Faça o mesmo para GetModelsToComboBox e GetGaragesToComboBox


        public static List<Models.Garage> GetGaragesToComboBox(){
            List<Models.Garage> garages = new List<Models.Garage>();
            garages.Add(new Models.Garage{ GarageId=0 , Name=""});

            foreach(Models.Garage garage in Controllers.Garage.ReadAllGarages()){
                if((garage.GarageId != 0) && (garage.Name != null)){
                    garages.Add(garage);
                }
            }

            return garages;
        } 

        public static List<KeyValuePair<bool?, string>> GetStatusToComboBox()
        {
            List<KeyValuePair<bool?, string>> status = new List<KeyValuePair<bool?, string>>();

            status.Add(new KeyValuePair<bool?, string>(null, ""));

            status.Add(new KeyValuePair<bool?, string>(false, "Seminovo"));
            status.Add(new KeyValuePair<bool?, string>(true, "Usado"));

            return status;
        }



        private void btnFilter_Click(object sender, EventArgs e)
        {
            int selectedBrandId = ((Models.Brand)cbBrand.SelectedItem)?.BrandId ?? 0;
            int selectedModelId = ((Models.Model)cbModel.SelectedItem)?.ModelId ?? 0;
            int selectedGarageId = ((Models.Garage)cbGarage.SelectedItem)?.GarageId ?? 0;
            bool? selectedStatus = ((KeyValuePair<bool?, string>)cbEstado.SelectedItem).Key;

            if (selectedStatus == null)
                selectedStatus = null;

            List<Models.Car> filteredCars = Controllers.Car.ReadAllCars()
                .Where(car =>
                    (selectedBrandId == 0 || car.BrandId == selectedBrandId) &&
                    (selectedModelId == 0 || car.ModelId == selectedModelId) &&
                    (selectedGarageId == 0 || car.GarageId == selectedGarageId) &&
                    (selectedStatus == null || car.IsUsed == selectedStatus)
                )
                .ToList();

            UpdateCarListView(filteredCars);
        }


        private void UpdateCarListView(List<Models.Car> cars)
        {
            listCar.Items.Clear();

            foreach (Models.Car car in cars)
            {
                ListViewItem item = new ListViewItem(new[]
                {
                    car.CarId.ToString(),
                    GetBrandName(car.BrandId),
                    GetModelName(car.ModelId),
                    car.Year.ToString(),
                    car.Color,
                    car.LicensePlate,
                    car.BodyworkType,
                    car.Price.ToString("N2"),
                    car.FuelType,
                    car.TransmissionType,
                    car.CarMileage.ToString(),
                    GetGarageName(car.GarageId),
                    car.IsUsed ? "Usado" : "Seminovo",
                    car.ChassisCode,
                    car.RenavanCode
                });

                bool isSalled = false;

                foreach(Models.Sale sale in Controllers.Sale.ReadAllSale())
                {
                    if(sale.CarId == car.CarId)
                    {
                        isSalled = true;
                    }
                }

                if(!isSalled)
                {
                    listCar.Items.Add(item);
                }

            }
        }

        private string GetBrandName(int brandId)
        {
            Models.Brand brand = Controllers.Brand.ReadBrandById(brandId);
            return brand?.Name ?? string.Empty;
        }

        private string GetModelName(int modelId)
        {
            Models.Model model = Controllers.Model.ReadModelById(modelId);
            return model?.Name ?? string.Empty;
        }

        private string GetGarageName(int garageId)
        {
            Models.Garage garage = Controllers.Garage.ReadGarageById(garageId);
            return garage?.Name ?? string.Empty;
        }



        public void RefreshList()
        {
            listCar.Items.Clear();

            IEnumerable<Models.Car> list = Models.Car.ReadAllCars();
            List<Models.Car> listCars = new List<Models.Car>();

            foreach (Models.Car car in list)
            {
                listCars.Add(car);
            }
            
            UpdateCarListView(listCars);

        }

        public Models.Car GetSelectedCar(Option option)
        {
            if(listCar.SelectedItems.Count > 0)
            {
                int selectedCarId = int.Parse(listCar.SelectedItems[0].Text);
                return Models.Car.ReadByIdCar(selectedCarId);
            }
            else
            {
                throw new Exception($"Seleciona um carro para {(option == Option.Update? "editar" : "deletar")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateCar = new Views.CreateCar();
            CreateCar.Show();
            RefreshList();

        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Car car = GetSelectedCar(Option.Update);
                var CarUpdateView = new Views.UpdateCar(car);
                if(CarUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Carro editado com sucesso.");
                }

                RefreshList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Car car = GetSelectedCar(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza?", "Deletar Carro", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Models.Document renavanToDelete = Controllers.Document.ReadDocumentByValue(car.RenavanCode);
                    Models.Document chassisToDelete = Controllers.Document.ReadDocumentByValue(car.ChassisCode);

                    Controllers.Car.DeleteCar(car.CarId);
                    Controllers.Document.DeleteDocumentByValue(renavanToDelete.Value);
                    Controllers.Document.DeleteDocumentByValue(chassisToDelete.Value);
                }

                RefreshList();
            }
            catch (Exception err)
            {
                if(err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListCar()
        {
            this.Text = "Carros";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = ColorTranslator.FromHtml("#f8f8f8");

            tableFilters = new TableLayoutPanel();
            tableFilters.Size = new Size(880, 40);
            tableFilters.Location = new Point(50, 30);
            tableFilters.Font = new Font("Arial", 10, FontStyle.Regular);
            tableFilters.ForeColor = ColorTranslator.FromHtml("#242424");
            tableFilters.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableFilters.RowCount = 3;
            tableFilters.ColumnCount = 5;
            tableFilters.AutoSize = true;
            Controls.Add(tableFilters);

            lblBrand = new Label();
            lblBrand.Text = "Marca";
            lblBrand.Font = new Font("Arial", 10, FontStyle.Regular);
            lblBrand.ForeColor = ColorTranslator.FromHtml("#242424");
            lblBrand.AutoSize = true;
            tableFilters.Controls.Add(lblBrand, 0, 0);

            cbBrand = new ComboBox();
            cbBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBrand.Font = new Font("Arial", 10, FontStyle.Regular);
            cbBrand.ForeColor = ColorTranslator.FromHtml("#242424");
            cbBrand.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            cbBrand.FlatStyle = FlatStyle.Flat;
            cbBrand.Size = new Size(170, 30);
            cbBrand.Items.Add(0);
            cbBrand.ValueMember = "BrandId";
            cbBrand.DisplayMember = "Name";
            cbBrand.DataSource = GetBrandsToComboBox();
            if (cbBrand.Items.Count > 0)
            {
                cbBrand.SelectedIndex = 0;
            }            
            tableFilters.Controls.Add(cbBrand, 0, 1);

            lblModel = new Label();
            lblModel.Text = "Modelo";
            lblModel.Font = new Font("Arial", 10, FontStyle.Regular);
            lblModel.ForeColor = ColorTranslator.FromHtml("#242424");
            lblModel.AutoSize = true;
            tableFilters.Controls.Add(lblModel, 1, 0);

            cbModel = new ComboBox();
            cbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModel.Font = new Font("Arial", 10, FontStyle.Regular);
            cbModel.ForeColor = ColorTranslator.FromHtml("#242424");
            cbModel.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            cbModel.FlatStyle = FlatStyle.Flat;
            cbModel.Size = new Size(170, 30);
            cbModel.Items.Add(0);
            cbModel.ValueMember = "ModelId";
            cbModel.DisplayMember = "Name";
            cbModel.DataSource = GetModelsToComboBox();
            if (cbModel.Items.Count > 0)
            {
                cbModel.SelectedIndex = 0;
            }
            tableFilters.Controls.Add(cbModel, 1, 1);

            lblGarage = new Label();
            lblGarage.Text = "Garagem";
            lblGarage.Font = new Font("Arial", 10, FontStyle.Regular);
            lblGarage.ForeColor = ColorTranslator.FromHtml("#242424");
            lblGarage.AutoSize = true;
            tableFilters.Controls.Add(lblGarage, 2, 0);

            cbGarage = new ComboBox();
            cbGarage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGarage.Font = new Font("Arial", 10, FontStyle.Regular);
            cbGarage.ForeColor = ColorTranslator.FromHtml("#242424");
            cbGarage.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            cbGarage.FlatStyle = FlatStyle.Flat;
            cbGarage.Size = new Size(170, 30);
            cbGarage.Items.Add(0);
            cbGarage.ValueMember = "GarageId";
            cbGarage.DisplayMember = "Name";
            cbGarage.DataSource = GetGaragesToComboBox();
            if (cbGarage.Items.Count > 0)
            {
                cbGarage.SelectedIndex = 0;
            }
            tableFilters.Controls.Add(cbGarage, 2, 1);
            

            lblEstado = new Label();
            lblEstado.Text = "Estado";
            lblEstado.Font = new Font("Arial", 10, FontStyle.Regular);
            lblEstado.ForeColor = ColorTranslator.FromHtml("#242424");
            lblEstado.AutoSize = true;
            tableFilters.Controls.Add(lblEstado, 3, 0);

            cbEstado = new ComboBox();
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.Font = new Font("Arial", 10, FontStyle.Regular);
            cbEstado.BackColor =  ColorTranslator.FromHtml("#E0E6ED");
            cbEstado.FlatStyle = FlatStyle.Flat;
            cbEstado.ForeColor = ColorTranslator.FromHtml("#242424");
            cbEstado.Size = new Size(170, 30);
            cbEstado.Items.Add("");
            cbEstado.ValueMember = "Key";
            cbEstado.DisplayMember = "Value";
            cbEstado.DataSource = GetStatusToComboBox();
            if (cbEstado.Items.Count > 0)
            {
                cbEstado.SelectedIndex = 0;
            }
            tableFilters.Controls.Add(cbEstado, 3, 1); 


          
            btnFilter = new Button();
            btnFilter.Text = "Filtrar";
            btnFilter.Font = new Font("Arial", 10, FontStyle.Regular);
            btnFilter.Size = new Size(150, 20);
            btnFilter.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnFilter.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnFilter.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Dock = DockStyle.Fill;;
            btnFilter.Margin = new Padding(20, 0, 0, 0);
            btnFilter.Click += new EventHandler(btnFilter_Click);
            tableFilters.Controls.Add(btnFilter, 4, 1);






            listCar = new ListView();
            listCar.Size = new Size(880, 380);
            listCar.Location = new Point(50, 100);
            listCar.BackColor = ColorTranslator.FromHtml("#ffffff");
            listCar.Font = new Font("Arial", 10, FontStyle.Regular);
            listCar.ForeColor = ColorTranslator.FromHtml("#242424");
            listCar.FullRowSelect = true;
            listCar.AllowColumnReorder = true;
            listCar.BorderStyle = BorderStyle.FixedSingle;  
            listCar.MultiSelect = true;
            listCar.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listCar.View = View.Details;
            listCar.Columns.Add("Id");
            listCar.Columns.Add("Marca");
            listCar.Columns.Add("Modelo");
            listCar.Columns.Add("Ano");
            listCar.Columns.Add("Cor");
            listCar.Columns.Add("Placa");
            listCar.Columns.Add("Carroceria");
            listCar.Columns.Add("Preço");
            listCar.Columns.Add("Combustível");
            listCar.Columns.Add("Transmissão");
            listCar.Columns.Add("Quilometragem");
            listCar.Columns.Add("Garagem");
            listCar.Columns.Add("Estado");
            listCar.Columns.Add("Código do chassi");
            listCar.Columns.Add("Código renavan");

            listCar.Columns[0].Width = 30;
            listCar.Columns[1].Width = 120;
            listCar.Columns[2].Width = 120;
            listCar.Columns[3].Width = 60;
            listCar.Columns[4].Width = 120;
            listCar.Columns[5].Width = 80;
            listCar.Columns[6].Width = 80;
            listCar.Columns[7].Width = 100;
            listCar.Columns[8].Width = 100;
            listCar.Columns[9].Width = 100;
            listCar.Columns[10].Width = 80;
            listCar.Columns[11].Width = 120;
            listCar.Columns[12].Width = 80;
            listCar.Columns[13].Width = 120;
            listCar.Columns[14].Width = 120;
            listCar.FullRowSelect = true;
            this.Controls.Add(listCar);

            RefreshList();

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            panel.AutoSize = true;
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            panel.ColumnCount = 8;
            panel.RowCount = 1;
            panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            Button btCrt = new Button();
            btCrt.Text = "Adicionar";
            btCrt.Size = new Size(30, 30);
            btCrt.Font = new Font("Roboto", 8, FontStyle.Regular);
            btCrt.FlatStyle = FlatStyle.Flat;
            btCrt.FlatAppearance.BorderSize = 0;
            btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btCrt.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btCrt.Dock = DockStyle.Fill;
            btCrt.Click += new EventHandler(btCrt_Click);
            
            Button btUpdate = new Button();
            btUpdate.Text = "Editar";
            btUpdate.Size = new Size(30, 30);
            btUpdate.Font = new Font("Roboto", 8, FontStyle.Regular);
            btUpdate.FlatStyle = FlatStyle.Flat;
            btUpdate.FlatAppearance.BorderSize = 0;
            btUpdate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btUpdate.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btUpdate.Dock = DockStyle.Fill;
            btUpdate.Click += new EventHandler(btUdpate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Deletar";
            btDelete.Size = new Size(30, 30);
            btDelete.Font = new Font("Roboto", 8, FontStyle.Regular);
            btDelete.FlatStyle = FlatStyle.Flat;
            btDelete.FlatAppearance.BorderSize = 0;
            btDelete.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btDelete.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btDelete.Dock = DockStyle.Fill;
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Voltar";
            btClose.Size = new Size(30, 30);
            btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btClose.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btClose.Font = new Font("Roboto", 8, FontStyle.Regular);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.FlatAppearance.BorderSize = 0;
            btClose.Dock = DockStyle.Fill;
            btClose.Click += (sender, s) =>
            {
                this.Close();
            };
            
            panel.Controls.Add(btCrt, 2, 0);
            panel.Controls.Add(btUpdate, 3, 0);
            panel.Controls.Add(btDelete, 4, 0);
            panel.Controls.Add(btClose, 5, 0); 
            this.Controls.Add(panel);
        }
    }
}