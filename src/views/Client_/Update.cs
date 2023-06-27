namespace Views
{
    public class UpdateClient : Form
    {
        public Label lblName;
        public Label lblTelephone;
        public Label lblAddress;
        public Label lblDocument;
        public TextBox txtName;
        public TextBox txtTelephone;
        public TextBox txtAddress;
        public TextBox txtDocument;
        public Button btUpdate;

        public Models.Client client;
        public void btUdpate_Click(object sender, EventArgs e)
        {
            Models.Client clientToUpdate = this.client;
            clientToUpdate.Name = this.txtName.Text;
            clientToUpdate.Telephone = this.txtTelephone.Text;
            clientToUpdate.Address = this.txtAddress.Text;
            clientToUpdate.Document = this.txtDocument.Text;

            Controllers.Client.UpdateClient(
                clientToUpdate.ClientId,
                clientToUpdate.Name,
                clientToUpdate.Telephone,
                clientToUpdate.Address,
                clientToUpdate.Document
            );

            ListClient ClientList = Application.OpenForms.OfType<ListClient>().FirstOrDefault();
            if (ClientList != null)
            {
                ClientList.RefreshList();
            }
            this.Close();
        }


        public UpdateClient(Models.Client client)
        {
            this.client = client;

            this.Text = "Editar Cliente";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new Point(10, 40);
            this.lblName.Size = new Size(50, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new Point(90, 40);
            this.txtName.Size = new Size(150, 20);

            this.lblTelephone = new Label();
            this.lblTelephone.Text = "Telefone:";
            this.lblTelephone.Location = new Point(10, 70);
            this.lblTelephone.Size = new Size(60, 20);

            this.txtTelephone = new TextBox();
            this.txtTelephone.Location = new Point(90, 70);
            this.txtTelephone.Size = new Size(150, 20);

            this.lblAddress = new Label();
            this.lblAddress.Text = "Endereço:";
            this.lblAddress.Location = new Point(10, 100);
            this.lblAddress.Size = new Size(60, 20);

            this.txtAddress = new TextBox();
            this.txtAddress.Location = new Point(90, 100);
            this.txtAddress.Size = new Size(150, 20);

            this.lblDocument = new Label();
            this.lblDocument.Text = "Documento:";
            this.lblDocument.Location = new Point(10, 130);
            this.lblDocument.Size = new Size(60, 20);

            this.txtDocument = new TextBox();
            this.txtDocument.Location = new Point(90, 130);
            this.txtDocument.Size = new Size(150, 20);

            this.btUpdate = new Button();
            this.btUpdate.Text = "Editar";
            this.btUpdate.Location = new Point(90, 180);
            this.btUpdate.Size = new Size(150, 25);
            this.btUpdate.Click += new EventHandler(btUdpate_Click);

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblTelephone);
            this.Controls.Add(txtTelephone);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(lblDocument);
            this.Controls.Add(txtDocument);
            this.Controls.Add(btUpdate);
        }
    }
}