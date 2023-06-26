using Models;
using Controllers;

namespace Views
{
    public class UpdateBrand : Form
    {
        public Label lblName;
        public ComboBox comboBoxName;
        public Button btUdpate;

        public Models.Brand brand;
        public void btUdpate_Click(object sender, EventArgs e)
        {
            Models.Brand brandUpdate = this.brand;
            Controllers.Brand.UpdateBrand(
                brandUpdate.BrandId,
                brandUpdate.Name
            );
            
            ListBrand BrandList = Application.OpenForms.OfType<ListBrand>().FirstOrDefault();
            if (BrandList != null)
            {
                BrandList.RefreshList();
            }
            this.Close();
        }
        public UpdateBrand(Models.Brand brand)
        {
            this.brand = brand;

            this.Text = "Update Car";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblName = new Label();
            this.lblName.Text = "Name";
            this.lblName.Location = new Point(10, 40);
            this.lblName.Size = new Size(50, 20);

            this.comboBoxName = new ComboBox();
            this.comboBoxName.Location = new Point(80, 40);
            this.comboBoxName.Size = new Size(150, 20);
            this.comboBoxName.Items.Add("Audi");
            this.comboBoxName.Items.Add("BMW");
            this.comboBoxName.Items.Add("Porsche");
            this.comboBoxName.Items.Add("Mercedes-Benz");
            this.comboBoxName.Items.Add("Volvo");
            this.comboBoxName.Items.Add("Land Rover");
            this.comboBoxName.Items.Add("Volkswagen");
            this.comboBoxName.Items.Add("Chevrolet");
            this.comboBoxName.Items.Add("Fiat");
            this.comboBoxName.Items.Add("Ford");
            this.comboBoxName.Items.Add("Toyota");
            this.comboBoxName.Items.Add("Nissan");
            this.comboBoxName.Items.Add("Honda");
            this.comboBoxName.Items.Add("Hyundai");
            this.comboBoxName.Items.Add("Mitsubishi");
            this.comboBoxName.Items.Add("Jeep");
            this.comboBoxName.Items.Add("CAOA Chery");
            this.comboBoxName.Items.Add("Renault");
            this.comboBoxName.Items.Add("Peugeot");
            this.comboBoxName.Items.Add("Citroën");

            this.btUdpate = new Button();
            this.btUdpate.Text = "Update";
            this.btUdpate.Location = new Point(70, 90);
            this.btUdpate.Size = new Size(100, 30);
            this.btUdpate.Click += new EventHandler(btUdpate_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.btUdpate);
        }
    }
}