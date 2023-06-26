namespace Views
{
    public class CreateBrand : Form
    {
        public Label lblName;
        public ComboBox comboBoxName;
        public Button btCrt;

        public void btCrt_Click(object sender, EventArgs e)
        {

            Controllers.Brand.CreateBrand(
                comboBoxName.Text
            );

            MessageBox.Show("Brand created successfully");
            
            ListBrand BrandList = Application.OpenForms.OfType<ListBrand>().FirstOrDefault();
            if(BrandList == null)
            {
                BrandList.RefreshList();
            }
            this.Close();
        }

        public CreateBrand()
        {
            this.Text = "Add Brand";
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

            this.btCrt = new Button();
            this.btCrt.Location = new Point(10, 90);
            this.btCrt.Size = new Size(100, 20);
            this.btCrt.Click += btCrt_Click;

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.btCrt);
        }
    }
}