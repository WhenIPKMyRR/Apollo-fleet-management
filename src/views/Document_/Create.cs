namespace Views
{
    public class CreateDocument : Form
    {
        public Label lblTitle;
        public Label lblType;
        public Label lblValue;
        public Label lblCarId;
        public TextBox txtType;
        public TextBox txtValue;
        public TextBox txtCarId;
        public Button btCrt;
        public Button btClose;
        public TableLayoutPanel panel;

        public void btCrt_Click(object sender, EventArgs e)
        {
            Controllers.Document.CreateDocument(
                txtType.Text,
                txtValue.Text,
                Convert.ToInt32(txtCarId.Text)
            );

            MessageBox.Show("Documento cadastrado com sucesso.");
            
            ListDocument ListDocument = Application.OpenForms.OfType<ListDocument>().FirstOrDefault();
            if(ListDocument == null)
            {
                ListDocument.RefreshList();
            }
            this.Close();
        }

        public CreateDocument()
        {
            this.Text = "Cadastro";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 380);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Cadastro de Documento";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(45, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblType = new Label();
            this.lblType.Text = "Tipo:";
            this.lblType.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblType.Size = new Size(70, 20);

            this.txtType = new TextBox();
            this.txtType.Location = new Point(33, lblType.Bottom + 5);
            this.txtType.BorderStyle = BorderStyle.FixedSingle;
            this.txtType.Size = new Size(220, 20);

            this.lblValue = new Label();
            this.lblValue.Text = "Valor:";
            this.lblValue.Location = new Point(33, txtType.Bottom + 10);
            this.lblValue.Size = new Size(70, 20);

            this.txtValue = new TextBox();
            this.txtValue.Location = new Point(33, lblValue.Bottom + 5);
            this.txtValue.BorderStyle = BorderStyle.FixedSingle;
            this.txtValue.Size = new Size(220, 20);

            this.lblCarId = new Label();
            this.lblCarId.Text = "Carro:";
            this.lblCarId.Location = new Point(33, txtValue.Bottom + 10);
            this.lblCarId.Size = new Size(70, 20);

            this.txtCarId = new TextBox();
            this.txtCarId.Location = new Point(33, lblCarId.Bottom + 5);
            this.txtCarId.BorderStyle = BorderStyle.FixedSingle;
            this.txtCarId.Size = new Size(220, 20);

            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#58ACFA");
            this.panel.ColumnCount = 3;
            this.panel.RowCount = 1;
            this.panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                this.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            this.btCrt = new Button();
            this.btCrt.Text = "Editar";
            //this.btCrt.Location = new Point(90, 180);
            this.btCrt.Size = new Size(200, 25);
            this.btCrt.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btCrt.FlatStyle = FlatStyle.Flat;
            this.btCrt.FlatAppearance.BorderSize = 0;
            this.btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btCrt.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btCrt.Dock = DockStyle.Fill;
            this.btCrt.Click += new EventHandler(btCrt_Click);

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

            this.panel.Controls.Add(btCrt, 1, 0);
            this.panel.Controls.Add(btClose, 2, 0);

            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblCarId);
            this.Controls.Add(this.txtCarId);
        }   
    }
}