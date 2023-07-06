using Models;
using System;

namespace Views
{
    public class InitialScreen : Form
    {
        private Panel panelHorizontal;
        private TableLayoutPanel divHorizontal;
        private TableLayoutPanel divVertical;
        private Button buttonsInformations;
        private Button button;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuItemRegister;
        private ToolStripMenuItem menuItemViews;
        private ToolStripMenuItem menuItemStatements;

        
        private string[] GetValuesToHorizontalPanel()
        {
            IEnumerable<Models.Car> cars = Controllers.Car.ReadAllCars();
            IEnumerable<Models.Client> clients = Controllers.Client.ReadAllClients();
            IEnumerable<Models.Sale> sales = Controllers.Sale.ReadAllSale();

            int quantityCars = cars.Count();
            int quantityClients = clients.Count();
            int quantitySales = sales.Count();


            string[] textPanels = {
                $"{quantityCars}\nCarros cadastrados",
                $"{quantityClients}\nClientes satisfeitos",
                $"{quantitySales}\nVendas realizadas"
            };

            return textPanels;
        }

        // Método para atualizar os valores do texto dos botões
        private void UpdateButtonLabels()
        {
            string[] buttonLabels = GetValuesToHorizontalPanel();
            int buttonIndex = 0;

            foreach (Control control in divHorizontal.Controls)
            {
                if (control is Button button)
                {
                    button.Text = buttonLabels[buttonIndex];
                    buttonIndex++;
                }
            }
        }

        private void Button_Click(Button button)
        {

            switch (button.Text)
            {
                case "Carros":
                    var carrosForm = new ListCar();
                    carrosForm.FormClosed += (s, args) =>
                    {
                        UpdateButtonLabels();
                    };
                    carrosForm.ShowDialog();
                    break;

                case "Documentos":
                    var documentosForm = new ListDocument();
                    documentosForm.FormClosed += (s, args) =>
                    {
                        UpdateButtonLabels();
                    };  
                    documentosForm.ShowDialog();
                    break;

                case "Garagens":
                    var garageForm = new ListGarage();
                    garageForm.FormClosed += (s, args) =>
                    {
                        UpdateButtonLabels();
                    };
                    garageForm.ShowDialog();
                    break;

                case "Clientes":
                    var clientForm = new ListClient();
                    clientForm.FormClosed += (s, args) =>
                    {
                        UpdateButtonLabels();
                    };
                    clientForm.ShowDialog();
                    break;
                
                case "Vendedores":
                    var employeeForm = new ListSeller();
                    employeeForm.FormClosed += (s, args) =>
                    {
                        UpdateButtonLabels();
                    };
                    employeeForm.ShowDialog();
                    break;

                case "Balanços":
                    var balancesForm = new ListSale();
                    balancesForm.FormClosed += (s, args) =>
                    {
                        UpdateButtonLabels();
                    };
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.ControlBox = true;
            this.BackColor = ColorTranslator.FromHtml("#ffffff");
            

            this.menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;
            menuStrip.AutoSize = true;
            menuStrip.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            // menuStrip.ForeColor = ColorTranslator.FromHtml("#000000");
            

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
                var registerCar = new CreateCar();
                registerCar.FormClosed += (s, args) => 
                {
                    UpdateButtonLabels();
                };
                
                registerCar.ShowDialog();
            }; 

            ToolStripMenuItem subMenuItRegisterDocuments = new ToolStripMenuItem();
            subMenuItRegisterDocuments.Text = "Documentos";
            subMenuItRegisterDocuments.Click += (sender, e) =>
            {
                var registerDocument = new CreateDocument();
                registerDocument.FormClosed += (s, args) => 
                {
                   UpdateButtonLabels();
                };
                registerDocument.ShowDialog();
            };

            ToolStripMenuItem subMenuItemRegisterGarages = new ToolStripMenuItem();
            subMenuItemRegisterGarages.Text = "Garagens";
            subMenuItemRegisterGarages.Click += (sender, e) =>
            {
                var registerGarage = new CreateGarage();
                registerGarage.FormClosed += (s, args) => 
                {
                    UpdateButtonLabels();
                };
                registerGarage.ShowDialog();
            }; 

            ToolStripMenuItem subMenuItemregisterEmployees = new ToolStripMenuItem();
            subMenuItemregisterEmployees.Text = "Clientes";
            subMenuItemregisterEmployees.Click += (sender, e) =>
            {
                var registerEmployee = new CreateClient();
                registerEmployee.FormClosed += (s, args) =>
                {
                    UpdateButtonLabels();
                };
                registerEmployee.ShowDialog();
            };

            ToolStripMenuItem subMenuItemRegisterEmployees = new ToolStripMenuItem();
            subMenuItemRegisterEmployees.Text = "Vendedores";
            subMenuItemRegisterEmployees.Click += (sender, e) =>
            {
                var registerEmployee = new CreateSeller();
                 registerEmployee.FormClosed += (s, args) =>
                {
                    UpdateButtonLabels(); 
                };
                registerEmployee.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsCars = new ToolStripMenuItem();
            subMenuItemViewsCars.Text = "Carros";
            subMenuItemViewsCars.Click += (sender, e) =>
            {
                var listCars = new ListCar();
                listCars.FormClosed += (s, args) =>
                {
                    UpdateButtonLabels(); 
                };
                listCars.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsDocuments = new ToolStripMenuItem();
            subMenuItemViewsDocuments.Text = "Documentos";
            subMenuItemViewsDocuments.Click += (sender, e) =>
            {
                var listDocument = new Views.ListDocument();
                 listDocument.Click += (s, args) =>
                {
                    UpdateButtonLabels();
                };
                listDocument.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsGarages = new ToolStripMenuItem();
            subMenuItemViewsGarages.Text = "Garagens";
            subMenuItemViewsGarages.Click += (sender, e) =>
            {
                var listGarages = new Views.ListGarage();
                listGarages.Click += (s, args) =>
                {
                    UpdateButtonLabels();
                };
                listGarages.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsClients = new ToolStripMenuItem();
            subMenuItemViewsClients.Text = "Clientes";
            subMenuItemViewsClients.Click += (sender, e) =>
            {
                var listClients = new ListClient();
                listClients.FormClosed += (s, args) =>
                {
                    UpdateButtonLabels();
                };
                listClients.ShowDialog();
                this.Show();
            }; 

            ToolStripMenuItem subMenuItemViewsEmployees = new ToolStripMenuItem();
            subMenuItemViewsEmployees.Text = "Vendedores";
            subMenuItemViewsEmployees.Click += (sender, e) =>
            {
                var listEmployee = new ListSeller();
                listEmployee.FormClosed += (s, args) =>
                {
                    UpdateButtonLabels();
                };
                listEmployee.ShowDialog();
                this.Show();
            }; 

            //Balanço
            ToolStripMenuItem subMenuItemStatementsSales = new ToolStripMenuItem();
            subMenuItemStatementsSales.Text = "Vendas";
            subMenuItemStatementsSales.Click += (sender, e) =>
            {
                var balanceSales = new ListSale();
                balanceSales.FormClosed += (s, args) =>
                {
                    UpdateButtonLabels();

                };
                balanceSales.ShowDialog();
            };

          
            menuStrip.Items.Add(menuItemRegister);
            menuStrip.Items.Add(menuItemViews);
            menuStrip.Items.Add(menuItemStatements);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterCars);
            menuItemRegister.DropDownItems.Add(subMenuItemregisterEmployees);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterEmployees);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterGarages);
            menuItemRegister.DropDownItems.Add(subMenuItRegisterDocuments);
            menuItemViews.DropDownItems.Add(subMenuItemViewsCars);
            menuItemViews.DropDownItems.Add(subMenuItemViewsClients);
            menuItemViews.DropDownItems.Add(subMenuItemViewsDocuments);
            menuItemViews.DropDownItems.Add(subMenuItemViewsEmployees);
            menuItemViews.DropDownItems.Add(subMenuItemViewsGarages);
            menuItemStatements.DropDownItems.Add(subMenuItemStatementsSales);


            this.panelHorizontal = new Panel();
            panelHorizontal.Size = new Size(ClientSize.Width, 260);
            panelHorizontal.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            panelHorizontal.Location = new Point((ClientSize.Width - panelHorizontal.Width) / 2, 0);
            Controls.Add(this.panelHorizontal);
            panelHorizontal.Controls.Add(divHorizontal);


            this.divHorizontal = new TableLayoutPanel();
            divHorizontal.Size = new Size(800, 100); 
            divHorizontal.Location = new Point((ClientSize.Width - divHorizontal.Width) / 2, 200);
            divHorizontal.BackColor = Color.Transparent;
            divHorizontal.ForeColor = Color.Transparent;
            divHorizontal.ColumnCount = 3;
            divHorizontal.RowCount = 1;
            divHorizontal.ColumnStyles.Clear();
            divHorizontal.RowStyles.Clear();
            divHorizontal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 3));
            divHorizontal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 3));
            divHorizontal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 3));
            divHorizontal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Controls.Add(this.divHorizontal);
            divHorizontal.BringToFront();


            int buttonCountDivHorizontal = 3;
            int buttonWidthDivHorizontal = 290;
            int buttonHeightDivHorizontal = 100;

            string[] buttonLabels = GetValuesToHorizontalPanel();

            for (int i = 0; i < buttonCountDivHorizontal; i++)
            {
                Button button = new Button();
                button.Size = new Size(buttonWidthDivHorizontal, buttonHeightDivHorizontal);
                button.Margin = new Padding(5); // Adicione margem para criar espaçamento entre os botões
                button.BackColor = ColorTranslator.FromHtml("#F8F8F8");
                button.ForeColor = ColorTranslator.FromHtml("#242424");
                button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#BFCBE9");
                button.FlatStyle = FlatStyle.Flat;
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.Text = buttonLabels[i];
                button.Font = new Font("Segoe UI", 13f, FontStyle.Regular);
                button.FlatAppearance.BorderSize = 2;

                divHorizontal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / buttonCountDivHorizontal));
                divHorizontal.Controls.Add(button, i, 0);
            }

            int columnsSquare = 3;
            int rowsSquare = 2;

            this.divVertical = new TableLayoutPanel();
            divVertical.Size = new Size(630, 310);
            divVertical.Location = new Point((ClientSize.Width - divVertical.Width) / 2, (ClientSize.Height - divVertical.Height) / 2 + 100);
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