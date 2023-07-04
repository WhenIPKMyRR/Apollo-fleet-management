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

            Button sellerButton = new Button();
            sellerButton.Text = "Vendedores";
            sellerButton.Location = new Point((menu.ClientSize.Width - sellerButton.Width) / 2, documentButton.Bottom + 20);
            sellerButton.AutoSize = true;
            sellerButton.Click += (sender, e) => 
            {
                var createSeller = new CreateSeller();
                createSeller.ShowDialog();
                menu.Show();

            };

            Button saleButton = new Button();
            saleButton.Text = "Vendas";
            saleButton.Location = new Point((menu.ClientSize.Width - saleButton.Width) / 2, sellerButton.Bottom + 20);
            saleButton.AutoSize = true;
            saleButton.Click += (sender, e) => 
            {
                var createSale = new CreateSale();
                createSale.ShowDialog();
                menu.Show();

            };

            Button initialButton = new Button();
            initialButton.Text = "Clientes";
            initialButton.Location = new Point((menu.ClientSize.Width - initialButton.Width) / 2, saleButton.Bottom + 10);
            initialButton.AutoSize = true;
            initialButton.Click += (sender, e) => 
            {
                var createClient = new InitialScreen();
                createClient.ShowDialog();
                menu.Show();

            };
            
            menu.Controls.Add(clientButton);
            menu.Controls.Add(carButton);
            menu.Controls.Add(brandButton);
            menu.Controls.Add(documentButton);
            menu.Controls.Add(sellerButton);    
            menu.Controls.Add(saleButton);
            menu.Controls.Add(initialButton);

            menu.ShowDialog();

        }

        
    }

}