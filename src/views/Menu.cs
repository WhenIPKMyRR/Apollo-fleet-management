// using 

namespace Views
{

    public class Menu : Form
    {
        public static void menu()
        {
            Form menu = new Form();
            menu.Text = "Apollo Fleet Management";
            menu.Size = new Size(500, 400);
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

            Button carButton = new Button();
            carButton.Text = "Carros";
            carButton.Location = new Point((menu.ClientSize.Width - carButton.Width) / 2, clientButton.Bottom + 20);
            carButton.AutoSize = true;
            carButton.Click += (sender, e) => 
            {
                var createCar = new CreateCar();
                createCar.ShowDialog();
                menu.Show();

            };

            Button brandButton = new Button();
            brandButton.Text = "Marcas";
            brandButton.Location = new Point((menu.ClientSize.Width - brandButton.Width) / 2, carButton.Bottom + 20);
            brandButton.AutoSize = true;
            brandButton.Click += (sender, e) => 
            {
                var createBrand = new CreateBrand();
                createBrand.ShowDialog();
                menu.Show();

            };

            Button documentButton = new Button();
            documentButton.Text = "Documentos";
            documentButton.Location = new Point((menu.ClientSize.Width - documentButton.Width) / 2, brandButton.Bottom + 20);
            documentButton.AutoSize = true;
            documentButton.Click += (sender, e) => 
            {
                var createDocument = new CreateDocument();
                createDocument.ShowDialog();
                menu.Show();

            };
            
            menu.Controls.Add(clientButton);
            menu.Controls.Add(carButton);
            menu.Controls.Add(brandButton);
            menu.Controls.Add(documentButton);

            menu.ShowDialog();

        }

        
    }

}