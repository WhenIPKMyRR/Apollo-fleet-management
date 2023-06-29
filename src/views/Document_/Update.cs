namespace Views
{
    public class UpdateDocument : Form
    {
        public Label lblTitle;
        public Label lblType;
        public Label lblValue;
        public Label lblCarId;
        public TextBox txtType;
        public TextBox txtValue;
        public TextBox txtCarId;
        public Button btUdpate;
        public Button btClose;
        public TableLayoutPanel panel;

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
            this.Size = new System.Drawing.Size(300, 380);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar Documento";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblType = new Label();
            this.lblType.Text = "Tipo:";
            this.lblType.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblType.Size = new Size(70, 20);

            this.txtType = new TextBox();
            this.txtType.Location = new Point(33, lblType.Bottom + 5);
            this.txtType.Size = new Size(220, 20);

            this.lblValue = new Label();
            this.lblValue.Text = "Valor:";
            this.lblValue.Location = new Point(33, txtType.Bottom + 10);
            this.lblValue.Size = new Size(70, 20);

            this.txtValue = new TextBox();
            this.txtValue.Location = new Point(33, lblValue.Bottom + 5);
            this.txtValue.Size = new Size(220, 20);

            this.lblCarId = new Label();
            this.lblCarId.Text = "Carro:";
            this.lblCarId.Location = new Point(33, txtValue.Bottom + 10);
            this.lblCarId.Size = new Size(70, 20);

            this.txtCarId = new TextBox();
            this.txtCarId.Location = new Point(33, lblCarId.Bottom + 5);
            this.txtCarId.Size = new Size(220, 20);

            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#0080FF");
            this.panel.ColumnCount = 3;
            this.panel.RowCount = 1;
            this.panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                this.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            this.btUdpate = new Button();
            this.btUdpate.Text = "Editar";
            //this.btUdpate.Location = new Point(90, 180);
            this.btUdpate.Size = new Size(200, 25);
            this.btUdpate.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btUdpate.FlatStyle = FlatStyle.Flat;
            this.btUdpate.FlatAppearance.BorderSize = 0;
            this.btUdpate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btUdpate.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btUdpate.Dock = DockStyle.Fill;
            this.btUdpate.Click += new EventHandler(btUdpate_Click);

            this.btClose = new Button();
            this.btClose.Text = "Fechar";
            //this.btClose.Location = new Point(80, btCrt.Bottom + 10);
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

            this.panel.Controls.Add(btUdpate, 1, 0);
            this.panel.Controls.Add(btClose, 2, 0);

            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
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