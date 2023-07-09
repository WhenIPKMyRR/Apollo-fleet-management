using Models;
using Controllers;

namespace Views
{
    public class ListDocument : Form
    {
        ListView listDocument;
        private void AddListView(Models.Document document)
        {
            Models.Car car = Controllers.Car.ReadCarById(document.CarId);
            Models.Model model = Controllers.Model.ReadModelById(car.ModelId);
            string[]row = 
            {
                document.DocumentId.ToString(),
                document.Type,
                document.Value,
                model.Name
            };

            ListViewItem item = new ListViewItem(row);
            listDocument.Items.Add(item);
        }

        public void RefreshList()
        {
            listDocument.Items.Clear();

            IEnumerable<Models.Document> list = Models.Document.ReadAllDocument();

            foreach (Models.Document document in list)
            {
                AddListView(document);
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateDocument = new Views.CreateDocument();
            CreateDocument.Show();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Document document = GetSelectedDocument(Option.Update);
                RefreshList();
                var DocumentUpdateView = new Views.UpdateDocument(document);
                if(DocumentUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Documento editado com sucesso.");
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
                Models.Document document = GetSelectedDocument(Option.Delete);
                if (MessageBox.Show("Tem certeza?", "Deletar Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Models.Document.DeleteDocument(document.DocumentId);
                    RefreshList();
                }
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

        public Models.Document GetSelectedDocument(Option option)
        {
            if (listDocument.SelectedItems.Count > 0)
            {
                int selectedDocumentId = int.Parse(listDocument.SelectedItems[0].Text);
                return Models.Document.ReadByIdDocument(selectedDocumentId);
            }
            else
            {
                throw new System.Exception($"Selecione um documento para {(option == Option.Update ? "editar" : "deletar")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListDocument()
        {
            this.Text = "Documentos";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false; 
            this.BackColor = ColorTranslator.FromHtml("#F8F8F8");

            listDocument = new ListView();
            listDocument.Size = new Size(680, 260);
            listDocument.Location = new Point(50, 50);
            listDocument.BackColor = ColorTranslator.FromHtml("#ffffff");
            listDocument.Font = new Font("Arial", 10, FontStyle.Regular);
            listDocument.ForeColor = ColorTranslator.FromHtml("#242424");
            listDocument.View = View.Details;
            listDocument.Columns.Add("Id");
            listDocument.Columns.Add("Tipo");
            listDocument.Columns.Add("Valor");
            listDocument.Columns.Add("Carro");
            listDocument.Columns[0].Width = 30;
            listDocument.Columns[1].Width = 100;
            listDocument.Columns[2].Width = 120;
            listDocument.Columns[3].Width = 200;
            listDocument.FullRowSelect = true;
            this.Controls.Add(listDocument);

            RefreshList();

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            panel.AutoSize = true;
            // panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
            // btCrt.Location = new Point(50, 330);
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
            //btUpdate.Location = new Point(170, 330);
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
            // btDelete.Location = new Point(290, 330);
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
            // btClose.Location = new Point(410, 330);
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