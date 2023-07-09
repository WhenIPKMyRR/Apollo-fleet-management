namespace Views
{
    public class UpdateModel : Form
    {
        public Label lblTitle;
        public Label lblName;
        public Label lblBrandId;
        public TextBox txtName;
        public TextBox txtBrandId;
        public Button btUdpate;
        public Button btClose;
        public TableLayoutPanel panel;

        public Models.Model model;

        public void btUdpate_Click(object sender, EventArgs e)
        {
            Models.Model modelUpdate = this.model;
            Controllers.Model.UpdateModel(
                modelUpdate.ModelId,
                modelUpdate.Name,
                modelUpdate.BrandId
            );
            
            ListModel ModelList = Application.OpenForms.OfType<ListModel>().FirstOrDefault();
            if (ModelList != null)
            {
                ModelList.RefreshList();
            }
            this.Close();
        }

        public UpdateModel(Models.Model model)
        {
            this.model = model;

            this.Text = "Edição";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = ColorTranslator.FromHtml("#f8f8f8");
            this.Size = new System.Drawing.Size(300, 350);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar Modelo";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblName.Size = new Size(70, 20);

            this.txtName = new TextBox();
            this.txtName.Text = model.Name;
            this.txtName.Location = new Point(33, lblName.Bottom + 5);
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Size = new Size(220, 20);

            this.lblBrandId = new Label();
            this.lblBrandId.Text = "Marca:";
            this.lblBrandId.Location = new Point(33, txtName.Bottom + 10);
            this.lblBrandId.Size = new Size(70, 20);

            this.txtBrandId = new TextBox();
            this.txtBrandId.Text = model.BrandId.ToString();
            this.txtBrandId.Location = new Point(33, lblBrandId.Bottom + 5);
            this.txtBrandId.BorderStyle = BorderStyle.FixedSingle;
            this.txtBrandId.Size = new Size(220, 20);

            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#58ACFA");
            this.panel.ColumnCount = 4;
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
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblBrandId);
            this.Controls.Add(txtBrandId);
        }
    }
}