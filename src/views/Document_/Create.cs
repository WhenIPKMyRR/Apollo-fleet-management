namespace Views
{
    public class CreateDocument : Form
    {
        public Label lblType;
        public Label lblValue;
        public Label lblCarId;
        public TextBox txtType;
        public TextBox txtValue;
        public TextBox txtCarId;
        public Button btCrt;

        public void btCrt_Click(object sender, EventArgs e)
        {
            Controllers.Document.CreateDocument(
                txtType.Text,
                txtValue.Text,
                Convert.ToInt32(txtCarId.Text)
            );

            MessageBox.Show("Document created successfully");
            
            ListDocument ListDocument = Application.OpenForms.OfType<ListDocument>().FirstOrDefault();
            if(ListDocument == null)
            {
                ListDocument.RefreshList();
            }
            this.Close();
        }

        public CreateDocument()
        {
            this.Text = "Update Document";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblType = new Label();
            this.lblType.Text = "Type";
            this.lblType.Location = new Point(10, 40);
            this.lblType.Size = new Size(50, 20);

            this.txtType = new TextBox();
            this.txtType.Location = new Point(80, 40);
            this.txtType.Size = new Size(150, 20);

            this.lblValue = new Label();
            this.lblValue.Text = "Value";
            this.lblValue.Location = new Point(10, 70);
            this.lblValue.Size = new Size(50, 20);

            this.txtValue = new TextBox();
            this.txtValue.Location = new Point(80, 70);
            this.txtValue.Size = new Size(150, 20);

            this.lblCarId = new Label();
            this.lblCarId.Text = "Car";
            this.lblCarId.Location = new Point(10, 110);
            this.lblCarId.Size = new Size(50, 20);

            this.txtCarId = new TextBox();
            this.txtCarId.Location = new Point(80, 110);                 
            this.txtCarId.Size = new Size(150, 20);

            this.btCrt = new Button();
            this.btCrt.Text = "Add";
            this.btCrt.Location = new Point(80, 160);
            this.btCrt.Size = new Size(150, 25);
            this.btCrt.Click += new EventHandler(btCrt_Click);

            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblCarId);
            this.Controls.Add(this.txtCarId);
            this.Controls.Add(this.btCrt);
        }   
    }
}