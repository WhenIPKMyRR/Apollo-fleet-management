using Models;
using System;

namespace Views
{
    public class InitialScreen : Form
    {
        private TableLayoutPanel divHorizontal;
        private TableLayoutPanel divVertical;
        private Button buttonsInformations;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuItemRegister;
        private ToolStripMenuItem menuItemViews;
        private ToolStripMenuItem menuItemStatements;
        


        // // Dentro do loop for onde você cria os botões, adicione o manipulador de eventos para cada botão
        // for (int i = 0; i < buttonTexts.Length; i++)
        // {
        //     // Restante do código...

        //     this.buttonsInformations.Click += Button_Click; // Substitua "Button_Click" pelo nome do manipulador de evento correspondente ao botão atual
        // }

        // Implementação do manipulador de eventos genérico para todos os botões
        private void Button_Click(Button button)
        {

            switch (button.Text)
            {
                case "Carros":
                    var carrosForm = new ListCar();
                    carrosForm.ShowDialog();
                    break;

                case "Documentos":
                    var documentosForm = new ListDocument();
                    documentosForm.ShowDialog();
                    break;

                // case "Garagens":
                //     var garageForm = new ListGarage();
                //     documentosForm.ShowDialog();
                //     break;

                case "Clientes":
                    var documentsForm = new ListDocument();
                    documentsForm.ShowDialog();
                    break;
                
                case "Vendedores":
                    var employeeForm = new ListSeller();
                    employeeForm.ShowDialog();
                    break;

                case "Balanços":
                    var balancesForm = new ListSale();
                    balancesForm.ShowDialog();
                    break;
                default:
                    break;
            }
        }


        public InitialScreen()
        {
            
            // this.Icon = new Icon("Assets/logoUm.ico", 52, 52);
            this.Text = "Bem vindo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.ControlBox = true;
            this.BackColor = ColorTranslator.FromHtml("#ffffff");
            

            this.menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;
            menuStrip.AutoSize = true;
            menuStrip.BackColor = ColorTranslator.FromHtml("#BFCBE9");

            this.Controls.Add(menuStrip);


            //Cadastro
            this.menuItemRegister = new ToolStripMenuItem();
            menuItemRegister.Text = "Cadastros";

            //Vizualização      
            this.menuItemViews = new ToolStripMenuItem();
            menuItemViews.Text = "Vizualizações";

            //Balanço
            this.menuItemStatements = new ToolStripMenuItem();
            menuItemStatements.Text = "Balanços";


            //Cadastro
            ToolStripMenuItem subMenuItemRegisterCars = new ToolStripMenuItem();
            subMenuItemRegisterCars.Text = "Carros";
            subMenuItemRegisterCars.Click += (sender, e) =>
            {
                // var registerRoom = new RoomCreate();
                // registerRoom.FormClosed += (s, args) => 
                // {
                //     AttStatusButton();
                // };
                
                // registerRoom.ShowDialog();
            }; 

            ToolStripMenuItem subMenuItRegisterDocuments = new ToolStripMenuItem();
            subMenuItRegisterDocuments.Text = "Documentos";
            subMenuItRegisterDocuments.Click += (sender, e) =>
            {
                // var registerEmployee = new EmployeeCreate();
                // registerEmployee.FormClosed += (s, args) => 
                // {
                //     AttStatusButton();
                // };
                // registerEmployee.ShowDialog();
            };

            ToolStripMenuItem subMenuItemRegisterGarages = new ToolStripMenuItem();
            subMenuItemRegisterGarages.Text = "Garagens";
            subMenuItemRegisterGarages.Click += (sender, e) =>
            {
                // var registerGuest = new CreateGuest();
                // registerGuest.FormClosed += (s, args) => 
                // {
                //     AttStatusButton();
                // };
                // registerGuest.ShowDialog();
            }; 

            ToolStripMenuItem subMenuItemRegisterClients = new ToolStripMenuItem();
            subMenuItemRegisterClients.Text = "Clientes";
            subMenuItemRegisterClients.Click += (sender, e) =>
            {
                // var registerProduct = new CreateProduct();
                //  registerProduct.FormClosed += (s, args) =>
                // {
                //     AttStatusButton(); 
                // };
                // registerProduct.ShowDialog();
            };

            ToolStripMenuItem subMenuItemRegisterEmployees = new ToolStripMenuItem();
            subMenuItemRegisterEmployees.Text = "Vendedores";
            subMenuItemRegisterEmployees.Click += (sender, e) =>
            {
                // var registerProduct = new CreateProduct();
                //  registerProduct.FormClosed += (s, args) =>
                // {
                //     AttStatusButton(); 
                // };
                // registerProduct.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsCars = new ToolStripMenuItem();
            subMenuItemViewsCars.Text = "Carros";
            subMenuItemViewsCars.Click += (sender, e) =>
            {
                // var listRooms = new ListRoom();
                // listRooms.FormClosed += (s, args) =>
                // {
                //     AttStatusButton(); 
                // };
                // listRooms.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsDocuments = new ToolStripMenuItem();
            subMenuItemViewsDocuments.Text = "Documentos";
            subMenuItemViewsDocuments.Click += (sender, e) =>
            {
                // var listEmployees = new Views.ListEmployee();
                //  listEmployees.Click += (s, args) =>
                // {
                //    AttStatusButton();
                // };
                // listEmployees.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsGarages = new ToolStripMenuItem();
            subMenuItemViewsGarages.Text = "Garagens";
            subMenuItemViewsGarages.Click += (sender, e) =>
            {
                // var listGuests = new Views.ListGuest();
                // listGuests.Click += (s, args) =>
                // {
                //    AttStatusButton();
                // };
                // listGuests.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsClients = new ToolStripMenuItem();
            subMenuItemViewsClients.Text = "Clientes";
            subMenuItemViewsClients.Click += (sender, e) =>
            {
                // var listProoducts = new List();
                // listProoducts.ShowDialog();
                // this.Show();
            }; 

            ToolStripMenuItem subMenuItemViewsEmployees = new ToolStripMenuItem();
            subMenuItemViewsEmployees.Text = "Vendedores";
            subMenuItemViewsEmployees.Click += (sender, e) =>
            {
                // var listProoducts = new List();
                // listProoducts.ShowDialog();
                // this.Show();
            }; ;

            //Balanço
            ToolStripMenuItem subMenuItemStatementsSales = new ToolStripMenuItem();
            subMenuItemStatementsSales.Text = "Vendas";
            subMenuItemStatementsSales.Click += (sender, e) =>
            {
                // var statementsProducts = new StatementsProducts();
                // statementsProducts.ShowDialog();
                // this.Show();
            };

            // ToolStripMenuItem subMenuItemStatementsAccommodation = new ToolStripMenuItem();
            // subMenuItemStatementsAccommodation.Text = "Hospedagem";
            // subMenuItemStatementsAccommodation.Click += (sender, e) =>
            // {
            //     // var statementsAccommodation = new StatementsAccommodation();
            //     // statementsAccommodation.ShowDialog();
            //     // this.Show();
            // };


            menuItemRegister.DropDownItems.Add(subMenuItemRegisterCars);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterClients);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterEmployees);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterGarages);
            menuItemRegister.DropDownItems.Add(subMenuItRegisterDocuments);
            menuItemViews.DropDownItems.Add(subMenuItemViewsCars);
            menuItemViews.DropDownItems.Add(subMenuItemViewsClients);
            menuItemViews.DropDownItems.Add(subMenuItemViewsDocuments);
            menuItemViews.DropDownItems.Add(subMenuItemViewsEmployees);
            menuItemViews.DropDownItems.Add(subMenuItemViewsGarages);
            menuItemStatements.DropDownItems.Add(subMenuItemStatementsSales);


            this.divHorizontal = new TableLayoutPanel();
            divHorizontal.Dock = DockStyle.Top;
            divHorizontal.Size = new Size(870, 130);
            divHorizontal.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            divHorizontal.ColumnCount = 3;
            divHorizontal.ColumnStyles.Clear();
            Controls.Add(this.divHorizontal);

            int buttonCountDivHorizontal = 3;
            int buttonWidthDivHorizontal = 200;
            int buttonHeightDivHorizontal = 100;

            for (int i = 0; i < buttonCountDivHorizontal; i++)
            {
                Button button = new Button();
                button.Size = new Size(buttonWidthDivHorizontal, buttonHeightDivHorizontal);
                button.BackColor = ColorTranslator.FromHtml("#F8F8F8");
                button.ForeColor = ColorTranslator.FromHtml("#BFCBE9");
                button.FlatStyle = FlatStyle.Flat;
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.Text = "Button " + (i + 1);
                button.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 2;

                divHorizontal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / buttonCountDivHorizontal));
                divHorizontal.Controls.Add(button, i, 0);
            }


            int columnsSquare = 3;
            int rowsSquare = 2;

            this.divVertical = new TableLayoutPanel();
            divVertical.Size = new Size(630, 310);
            divVertical.Location = new Point((ClientSize.Width - divVertical.Width) / 2, (ClientSize.Height - divVertical.Height) / 2 + 150);
            divVertical.ColumnCount = columnsSquare;
            divVertical.RowCount = rowsSquare;
            divVertical.BackColor = ColorTranslator.FromHtml("#ffffff");
            divVertical.ColumnStyles.Clear();
            divVertical.RowStyles.Clear();
            divVertical.Dock = DockStyle.None;
            divVertical.Padding = new Padding(10); // Espaçamento interno dos botões
            Controls.Add(this.divVertical);

            for (int i = 0; i < divVertical.ColumnCount; i++)
            {
                divVertical.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / divVertical.ColumnCount));
            }

            for (int i = 0; i < divVertical.RowCount; i++)
            {
                divVertical.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / divVertical.RowCount));
            }

            string[] buttonTexts = { "Carros", "Documentos", "Garagens", "Clientes", "Vendedores", "Balanços" };
            string[] imagePaths = { "Assets/icon-car.png", "Assets/icon-document.png", "Assets/icon-garage.png", "Assets/icon-client.png", "Assets/icon-employee.png", "Assets/icon-balance.png" };

            int buttonWidth = (divVertical.Width - divVertical.Padding.Horizontal) / divVertical.ColumnCount;
            int buttonHeight = (divVertical.Height - divVertical.Padding.Vertical) / divVertical.RowCount;

            for (int i = 0; i < buttonTexts.Length; i++)
            {
                this.buttonsInformations = new Button();
                buttonsInformations.Text = buttonTexts[i];
                buttonsInformations.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
                buttonsInformations.Size = new Size(buttonWidth, buttonHeight);
                buttonsInformations.BackColor = ColorTranslator.FromHtml("#F8F8F8");
                buttonsInformations.ForeColor = ColorTranslator.FromHtml("#BFCBE9");
                buttonsInformations.FlatStyle = FlatStyle.Flat;
                buttonsInformations.FlatAppearance.BorderSize = 2;
                buttonsInformations.ImageAlign = ContentAlignment.MiddleCenter;
                buttonsInformations.TextAlign = ContentAlignment.MiddleCenter;
                buttonsInformations.TextImageRelation = TextImageRelation.ImageAboveText; 
                buttonsInformations.Click += (sender, e) =>
                {
                    if (sender is Button clickedButton)
                    {
                        Button_Click(clickedButton);
                    }
                };

                // Carregar imagem e ajustar tamanho
                Image image = Image.FromFile(imagePaths[i]);
                float scale = Math.Min(buttonsInformations.Width / (float)image.Width, buttonsInformations.Height / (float)image.Height);
                int imageWidth = (int)(image.Width * scale * 0.4f); 
                int imageHeight = (int)(image.Height * scale * 0.4f); 
                buttonsInformations.Image = new Bitmap(image, new Size(imageWidth, imageHeight));

                int column = i % divVertical.ColumnCount;
                int row = i / divVertical.ColumnCount;
                divVertical.Controls.Add(buttonsInformations, column, row);
            }

        }

        
    }
}