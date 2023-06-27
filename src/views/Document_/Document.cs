using Models;
using Controllers;

namespace Views
{
    public class ListDocument : Form
    {
        ListView listDocument;
        private void AddListView(Models.Document document)
        {
            string[]row = 
            {
                document.DocumentId.ToString(),
                document.Type,
                document.Value,
                document.CarId.ToString()
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
                    MessageBox.Show("Document succesfully edited.");
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
                if (MessageBox.Show("Are you sure?", "Delete Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                throw new System.Exception($"Select a Document to {(option == Option.Update ? "update" : "delete")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListDocument()
        {
            this.Text = "Documents";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            listDocument = new ListView();
            listDocument.Size = new Size(680, 260);
            listDocument.Location = new Point(50, 50);
            listDocument.View = View.Details;
            listDocument.Columns.Add("Id");
            listDocument.Columns.Add("Type");
            listDocument.Columns.Add("Value");
            listDocument.Columns.Add("Car");
            listDocument.Columns[0].Width = 30;
            listDocument.Columns[1].Width = 100;
            listDocument.Columns[2].Width = 100;
            listDocument.Columns[3].Width = 100;
            listDocument.FullRowSelect = true;
            this.Controls.Add(listDocument);

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