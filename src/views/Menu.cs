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
        private static TableLayoutPanel buttonsLayoutPanel;
        private static Panel Panel;
        private static Button btnToMainScreen;
        private static Button btnExit;



        public static void menu()
        {

            Form menu = new Form();
            // menu.Icon = new Icon("Assets/logoUm.ico", 30, 30);
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
            menu.BackColor = ColorTranslator.FromHtml("#ffffff");


            Panel = new Panel();
            Panel.Size = new Size(350, 500);
            Panel.Location = new Point((menu.ClientSize.Width - Panel.Width) / 2,(menu.ClientSize.Height - Panel.Width) / 2);
            Panel.BackColor = Color.Transparent;
            Panel.BorderStyle = BorderStyle.None;
            menu.Controls.Add(Panel);
            
            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(350, 180); 
            pictureBox1.Location = new Point((menu.ClientSize.Width - pictureBox1.Width) / 2, 20); 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; 
            pictureBox1.Padding = new Padding(0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.BorderStyle = BorderStyle.None;
            Panel.Controls.Add(pictureBox1);


            string imageLogo = "Assets/icon-apollo.png";
            Image imagem = Image.FromFile(imageLogo);
            pictureBox1.Image = imagem;


            nameLabel = new Label();
            nameLabel.Text = "Nome:";
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point((menu.ClientSize.Width - nameLabel.Width) / 4, pictureBox1.Bottom + 30);
            menu.Controls.Add(nameLabel);

            nameTextBox = new TextBox();
            nameTextBox.Multiline = true; 
            nameTextBox.ScrollBars = ScrollBars.None; 
            nameTextBox.Size = new Size(213, 35); 
            nameTextBox.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            nameTextBox.Location = new Point((menu.ClientSize.Width - nameTextBox.Width) / 2, nameLabel.Bottom + 3);
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            menu.Controls.Add(nameTextBox);

            passwordLabel = new Label();
            passwordLabel.Text = "Senha:";
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point((menu.ClientSize.Width - passwordLabel.Width) / 4, nameTextBox.Bottom + 10);
            menu.Controls.Add(passwordLabel);

            passwordTextBox = new TextBox();
            passwordTextBox.Multiline = true; 
            passwordTextBox.ScrollBars = ScrollBars.None; 
            passwordTextBox.Size = new Size(213, 35); 
            passwordTextBox.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            passwordTextBox.Location = new Point((menu.ClientSize.Width - passwordTextBox.Width) / 2, passwordLabel.Bottom + 3);
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.PasswordChar = '*';
            menu.Controls.Add(passwordTextBox);

            buttonsLayoutPanel = new TableLayoutPanel();
            buttonsLayoutPanel.Dock = DockStyle.Bottom;
            buttonsLayoutPanel.AutoSize = true;
            buttonsLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsLayoutPanel.Padding = new Padding(10, 10, 10, 10);
            buttonsLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            buttonsLayoutPanel.ColumnCount = 4;
            buttonsLayoutPanel.RowCount = 1;
            buttonsLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < buttonsLayoutPanel.ColumnCount; i++)
            {
                buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            btnToMainScreen = new Button();
            btnToMainScreen.Text = "Entrar";
            btnToMainScreen.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnToMainScreen.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnToMainScreen.Size = new Size(110, 35);
            btnToMainScreen.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnToMainScreen.FlatStyle = FlatStyle.Flat;
            btnToMainScreen.FlatAppearance.BorderSize = 0;
            btnToMainScreen.Dock = DockStyle.Fill;
            btnToMainScreen.Click += (sender, e) =>
            {
                var initialScreen = new InitialScreen();
                initialScreen.Show();
            };

            // btnToMainScreen.Click += (sender, e) =>
            // {
            //     if (IsUserExisting())
            //     {
            //         menu.Hide();
            //         MainScreen mainScreen = new MainScreen();
            //         Models.Employee employee = GetUserLogin();
            //         mainScreen.GetOptionsAdmin(employee);
            //         mainScreen.ShowDialog();
            //         menu.Close();
            //     }
            //     else
            //     {
            //         MessageBox.Show(
            //             "Você não está cadastrado",
            //             "Cadastro",
            //             MessageBoxButtons.OK,
            //             MessageBoxIcon.Information
            //         );
            //     }
               
            // };

            btnExit = new Button();
            btnExit.Text = "Sair";
            btnExit.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnExit.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnExit.Size = new Size(110, 35);
            btnExit.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Click += (sender, e) =>
            {
                // ConfirmReserve();
                menu.Close();
            };

            buttonsLayoutPanel.Controls.Add(btnToMainScreen, 1, 0);
            buttonsLayoutPanel.Controls.Add(btnExit, 2, 0);
            menu.Controls.Add(buttonsLayoutPanel);

            menu.ShowDialog();

        }

        
    }

}