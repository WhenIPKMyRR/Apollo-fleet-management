// using 

namespace Views
{

    public class Menu : Form
    {
        private static PictureBox pictureBox1;
        private static Label nameLabel;
        private static TextBox nameTextBox; 
        private static Label passwordLabel;
        private static TextBox passwordTextBox;
        private static TableLayoutPanel buttonsLayoutpanel;
        private static Panel panel;
        private static Button btnToMainScreen;
        private static Button btnExit;
        public static bool AcessAdmin {get; set;}



        public static bool IsUserExisting()
        {
            string name = nameTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
                Models.Seller seller = Controllers.Seller.Login(name, password);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static void IsUserAdmin()
        {
            string name = nameTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
                Models.Seller seller = Controllers.Seller.Login(name, password);
                if(seller.IsAdm)
                {
                   AcessAdmin = true;
                }
                else
                {
                    AcessAdmin = false;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public static void menu()
        {

            Form menu = new Form();
            menu.Text = "Seja Bem-vindo";
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.MaximizeBox = true;
            menu.MinimizeBox = true;
            menu.ShowIcon = false;
            menu.ShowInTaskbar = true;
            menu.WindowState = FormWindowState.Maximized;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.Bounds = Screen.PrimaryScreen.Bounds;
            menu.ControlBox = true;
            menu.BackColor = ColorTranslator.FromHtml("#E0E6ED");



            Panel panel = new Panel();
            panel.Size = new Size(350, 500);
            panel.Location = new Point((menu.ClientSize.Width - panel.Width) / 2, (menu.ClientSize.Height - panel.Height) / 2);
            panel.BackColor = ColorTranslator.FromHtml("#ffffff"); 
            panel.BorderStyle = BorderStyle.FixedSingle;
            menu.Controls.Add(panel);


            
            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(350, 180); 
            pictureBox1.Location = new Point((panel.ClientSize.Width - pictureBox1.Width) / 2, 20); 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; 
            pictureBox1.Padding = new Padding(0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.BorderStyle = BorderStyle.None;
            panel.Controls.Add(pictureBox1);


            string imageLogo = "Assets/logo.png";
            Image imagem = Image.FromFile(imageLogo);
            pictureBox1.Image = imagem;


            nameLabel = new Label();
            nameLabel.Text = "Email:";
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point((panel.ClientSize.Width - nameLabel.Width) / 4, pictureBox1.Bottom + 30);
            panel.Controls.Add(nameLabel);

            nameTextBox = new TextBox();
            nameTextBox.Multiline = true; 
            nameTextBox.ScrollBars = ScrollBars.None; 
            nameTextBox.Size = new Size(213, 35); 
            nameTextBox.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            nameTextBox.Location = new Point((panel.ClientSize.Width - nameTextBox.Width) / 2, nameLabel.Bottom + 3);
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(nameTextBox);

            passwordLabel = new Label();
            passwordLabel.Text = "Senha:";
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point((panel.ClientSize.Width - passwordLabel.Width) / 4, nameTextBox.Bottom + 10);
            panel.Controls.Add(passwordLabel);

            passwordTextBox = new TextBox();
            passwordTextBox.Multiline = true; 
            passwordTextBox.ScrollBars = ScrollBars.None; 
            passwordTextBox.Size = new Size(213, 35); 
            passwordTextBox.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            passwordTextBox.Location = new Point((panel.ClientSize.Width - passwordTextBox.Width) / 2, passwordLabel.Bottom + 3);
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.PasswordChar = '*';
            panel.Controls.Add(passwordTextBox);

            buttonsLayoutpanel = new TableLayoutPanel();
            buttonsLayoutpanel.Dock = DockStyle.Bottom;
            buttonsLayoutpanel.AutoSize = true;
            buttonsLayoutpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsLayoutpanel.Padding = new Padding(10, 0, 10, 50);
            buttonsLayoutpanel.BackColor = ColorTranslator.FromHtml("#ffffff");
            buttonsLayoutpanel.ColumnCount = 4;
            buttonsLayoutpanel.RowCount = 1;
            buttonsLayoutpanel.ColumnStyles.Clear();

            for (int i = 0; i < buttonsLayoutpanel.ColumnCount; i++)
            {
                buttonsLayoutpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            btnToMainScreen = new Button();
            btnToMainScreen.Text = "Entrar";
            btnToMainScreen.BackColor = ColorTranslator.FromHtml("#f8f8f8");
            btnToMainScreen.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnToMainScreen.Size = new Size(110, 35);
            btnToMainScreen.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnToMainScreen.FlatStyle = FlatStyle.Flat;
            btnToMainScreen.FlatAppearance.BorderSize = 1;
            btnToMainScreen.Dock = DockStyle.Fill;
            btnToMainScreen.Click += (sender, e) =>
            {
                if (IsUserExisting())
                {
                    menu.Hide();
                    IsUserAdmin();
                    InitialScreen initialScreen = new InitialScreen();
                    initialScreen.ShowDialog();
                    menu.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Você não está cadastrado",
                        "Cadastro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
               
            };

            btnExit = new Button();
            btnExit.Text = "Sair";
            btnExit.BackColor = ColorTranslator.FromHtml("#f8f8f8");
            btnExit.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnExit.Size = new Size(110, 35);
            btnExit.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 1;
            btnExit.Click += (sender, e) =>
            {
                // ConfirmReserve();
                menu.Close();
            };

            buttonsLayoutpanel.Controls.Add(btnToMainScreen, 1, 0);
            buttonsLayoutpanel.Controls.Add(btnExit, 2, 0);

            panel.Controls.Add(pictureBox1);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(nameTextBox);
            panel.Controls.Add(passwordLabel);
            panel.Controls.Add(passwordTextBox);
            panel.Controls.Add(buttonsLayoutpanel);

            menu.Controls.Add(panel);

            menu.ShowDialog();

        }

        
    }

}