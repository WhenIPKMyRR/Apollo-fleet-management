using Models;
using Controllers;

namespace Views
{
    public class ListCar : Form
    {
        ListView listCar;

        private void AddListView(Models.Car car)
        {
            string[]row = 
            {
                car.CarId.ToString(),
                car.Year.ToString(),
                car.Color,
                car.LicensePlate,
                car.BodyworkType,
                car.Price.ToString(),
                car.ChassisCode,
                car.RenavanCode,
                car.FuelType,
                car.TransmissionType,
                car.CarMileage.ToString(),
                car.ModelId.ToString(),
                car.BrandId.ToString()
            };

            ListViewItem item = new ListViewItem(row);
            listCar.Items.Add(item);
        }

        public void RefreshList()
        {
            listCar.Items.Clear();

            IEnumerable<Models.Car> list = Models.Car.ReadAllCars();

            foreach (Models.Car car in list)
            {
                AddListView(car);
            }
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
                throw new Exception($"Select a Car to {(option == Option.Update? "Update" : "Delete")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateCar = new Views.CreateCar();
            CreateCar.Show();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Car car = GetSelectedCar(Option.Update);
                RefreshList();
                var CarUpdateView = new Views.UpdateCar();
                if(CarUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Car successfully updated.");
                }
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
                DialogResult result = MessageBox.Show("Do you want to delete this Car?", "Confirm deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RefreshList();
                }
            }catch (Exception err)
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
            this.Text = "Cars";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false; 

            listCar = new ListView();
            listCar.Size = new Size(680, 400);
            listCar.Location = new Point(50, 50);
            listCar.View = View.Details;
            listCar.Columns.Add("Id");
            listCar.Columns.Add("Year");
            listCar.Columns.Add("Color");
            listCar.Columns.Add("License Plate");
            listCar.Columns.Add("Body Work");
            listCar.Columns.Add("Price");
            listCar.Columns.Add("Chassis Code");
            listCar.Columns.Add("Renavan Code");
            listCar.Columns.Add("Fuel Type");
            listCar.Columns.Add("Transmission Type");
            listCar.Columns.Add("Mileage");
            listCar.Columns.Add("Model");
            listCar.Columns.Add("Brand");
            listCar.Columns[0].Width = 30;
            listCar.Columns[1].Width = 60;
            listCar.Columns[2].Width = 60;
            listCar.Columns[3].Width = 80;
            listCar.Columns[4].Width = 60;
            listCar.Columns[5].Width = 110;
            listCar.Columns[6].Width = 110;
            listCar.Columns[7].Width = 60;
            listCar.Columns[8].Width = 80;
            listCar.Columns[9].Width = 60;
            listCar.Columns[10].Width = 60;
            listCar.Columns[11].Width = 60;
            listCar.FullRowSelect = true;
            this.Controls.Add(listCar);

            RefreshList();

            Button btCrt = new Button();
            btCrt.Text = "Add";
            btCrt.Size = new Size(100, 30);
            btCrt.Location = new Point(50, 330);
            btCrt.Click += new EventHandler(btCrt_Click);
            this.Controls.Add(btCrt);

            Button btUpdate = new Button();
            btUpdate.Text = "Update";
            btUpdate.Size = new Size(100, 30);
            btUpdate.Location = new Point(170, 330);
            btUpdate.Click += new EventHandler(btUdpate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Delete";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(290, 330);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Exit";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(450, 330);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}