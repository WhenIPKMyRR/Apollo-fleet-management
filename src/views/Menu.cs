// using 

namespace Views
{

    public class Menu : Form
    {
        public static void menu()
        {
            Form menu = new Form();
            menu.Text = "Apollo Fleet Management";
            menu.Size = new Size(400, 400);
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.BackColor = Color.WhiteSmoke;
            menu.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            Label titleLabel = new Label();
            titleLabel.Text = "Apollo Fleet Management";
            titleLabel.Location = new Point((menu.ClientSize.Width - titleLabel.Width) / 2, 20);
            titleLabel.AutoSize = true;
            menu.Controls.Add(titleLabel);

            Button clientButton = new Button();
            clientButton.Text = "Clientes";
            clientButton.Location = new Point((menu.ClientSize.Width - clientButton.Width) / 2, titleLabel.Bottom + 10);
            clientButton.AutoSize = true;
            clientButton.Click += (sender, e) => 
            {
                var createClient = new CreateClient();
                createClient.ShowDialog();
                menu.Show();

            };
            menu.Controls.Add(clientButton);

            menu.ShowDialog();

        }

        
    }

}