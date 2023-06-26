using Controllers;

namespace Views
{

    public class CreateClient : Form
    {

        Label titleLabel;
        Label nameLabel;
        TextBox nameBox;
        Label phoneLabel;
        TextBox phoneBox;
        Label addressLabel;
        TextBox addressBox;
        Label documentLabel;
        TextBox documentBox;

        public CreateClient()
        {
            // this.Icon = new Icon("Assets/", 52,52);
            this.Text = "Cadastro de cliente";
            this.Size = new Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ControlBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;

            titleLabel = new Label();
            titleLabel.Text = "Cadastro de cliente";
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 2, 20);
            titleLabel.AutoSize = true;
            this.Controls.Add(titleLabel);
            
            nameLabel = new Label();
            nameLabel.Text = "Nome";
            nameLabel.Location = new ((this.ClientSize.Width - nameLabel.Width) / 3, titleLabel.Bottom + 10);
            nameLabel.AutoSize = true;
            this.Controls.Add(nameLabel);

            nameBox = new TextBox();
            int textBoxWidth = (int)(400 * 0.8);
            nameBox.Location = new Point ((this.ClientSize.Width - nameBox.Width) / 2, nameLabel.Bottom + 5);
            nameBox.Size = new Size(textBoxWidth, 30);
            this.Controls.Add(nameBox);

            phoneLabel = new Label();
            phoneLabel.Text = "Telefone";
            phoneLabel.Location = new ((this.ClientSize.Width - phoneLabel.Width) / 2, nameBox.Bottom + 10);
            phoneLabel.AutoSize = true;
            this.Controls.Add(phoneLabel);

            phoneBox = new TextBox();   
            phoneBox.Location = new Point ((this.ClientSize.Width - phoneBox.Width) / 2, phoneLabel.Bottom + 5);
            phoneBox.Size = new Size(250, 30);
            this.Controls.Add(phoneBox);

            addressLabel = new Label();
            addressLabel.Text = "Endereço";
            addressLabel.Location = new ((this.ClientSize.Width - addressLabel.Width) / 2, phoneBox.Bottom + 10);
            addressLabel.AutoSize = true;
            this.Controls.Add(addressLabel);

            addressBox = new TextBox();
            addressBox.Location = new ((this.ClientSize.Width - addressBox.Width) / 2, addressLabel.Bottom + 5);
            addressBox.Size = new Size(250, 30);
            this.Controls.Add(addressBox);

            documentLabel = new Label();
            documentLabel.Text = "Documento";
            documentLabel.Location = new ((this.ClientSize.Width - documentLabel.Width) / 2, addressBox.Bottom + 10);
            documentLabel.AutoSize = true;
            this.Controls.Add(documentLabel);

            documentBox = new TextBox();
            documentBox.Location = new ((this.ClientSize.Width - documentBox.Width) / 2, documentLabel.Bottom + 5);
            documentBox.Size = new Size(250, 30);
            this.Controls.Add(documentBox);
            

            Button btnCreateClient = new Button();
            btnCreateClient.Text = "Cadastrar";
            btnCreateClient.Location = new ((this.ClientSize.Width - btnCreateClient.Width) / 10, documentBox.Bottom + 30);
            btnCreateClient.AutoSize = true;
            btnCreateClient.Click += (sender, e) =>{
                Controllers.Client.CreateClient(nameBox.Text, phoneBox.Text, addressBox.Text, documentBox.Text);
                this.Close();
            };
            this.Controls.Add(btnCreateClient);

            Button btnCancel = new Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Location = new ((this.ClientSize.Width - btnCancel.Width) / 15, documentBox.Bottom + 30);
            btnCancel.AutoSize = true;
            btnCancel.Click += (sender, e) =>{
                this.Close();
            };
            this.Controls.Add(btnCancel);
            
            



            
        }





    }
}


