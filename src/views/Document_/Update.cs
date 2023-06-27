namespace Views
{
    public class UpdateDocument : Form
    {
        public Label lblType;
        public Label lblValue;
        public Label lblCarId;
        public TextBox txtType;
        public TextBox txtValue;
        public TextBox txtCarId;
        public Button btUdpate;

        public Models.Document document;
        public void btUdpate_Click(object sender, EventArgs e)
        {
            Models.Document documentUpdate = this.document;
            Controllers.Document.UpdateDocument(
                documentUpdate.DocumentId,
                documentUpdate.Type,
                documentUpdate.Value,
                documentUpdate.CarId
            );

            ListDocument DocumentList = Application.OpenForms.OfType<ListDocument>().FirstOrDefault();
            if (DocumentList != null)
            {
                DocumentList.RefreshList();
            }
            this.Close();
        }

        public UpdateDocument(Models.Document document)
        {
            this.document = document;

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
            this.lblCarId.Text = "CarId";
            this.lblCarId.Location = new Point(10, 100);
            this.lblCarId.Size = new Size(50, 20);

            this.txtCarId = new TextBox();
            this.txtCarId.Location = new Point(80, 100);
            this.txtCarId.Size = new Size(150, 20);

            this.btUdpate = new Button();
            this.btUdpate.Text = "Update";
            this.btUdpate.Location = new Point(80, 130);
            this.btUdpate.Size = new Size(150, 25);
            this.btUdpate.Click += new EventHandler(this.btUdpate_Click);

            this.Controls.Add(lblType);
            this.Controls.Add(txtType);
            this.Controls.Add(lblValue);
            this.Controls.Add(txtValue);
            this.Controls.Add(lblCarId);
            this.Controls.Add(txtCarId);
            this.Controls.Add(btUdpate);
        }
    }
}