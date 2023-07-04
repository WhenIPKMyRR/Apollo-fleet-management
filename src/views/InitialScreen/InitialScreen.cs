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
            divHorizontal.Size = new Size(this.ClientSize.Width , 190);
            divHorizontal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            divHorizontal.BackColor = ColorTranslator.FromHtml("#BFCBE9");
            Controls.Add(this.divHorizontal);


            int columnsSquare = 3;
            int rowsSquare = 2;
            
            this.divVertical  = new TableLayoutPanel();
            divVertical.Size = new Size(630, 310);
            divVertical.Location = new Point((ClientSize.Width - 630 ) / 2, divHorizontal.Bottom + 150);
            divVertical.ColumnCount = columnsSquare;
            divVertical.RowCount = rowsSquare;
            divVertical.BackColor = ColorTranslator.FromHtml("#ffffff");
            divVertical.ColumnStyles.Clear();
            divVertical.RowStyles.Clear();
            divVertical.Dock = DockStyle.Fill;
            Controls.Add(this.divVertical);

            for (int i = 0; i < divVertical.ColumnCount; i++)
            {
                divVertical.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / divVertical.ColumnCount));
            }

            for (int i = 0; i < divVertical.RowCount; i++)
            {
                divVertical.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / divVertical.RowCount));
            }

            for (int i = 1; i <= 6; i++)
            {

                this.buttonsInformations = new Button();
                buttonsInformations.Text = "Informações";
                buttonsInformations.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                // buttonsInformations.Location = new Point(0, 0);
                buttonsInformations.Size = new Size(195, 135);
                buttonsInformations.BackColor = Color.Transparent;
                buttonsInformations.ForeColor = ColorTranslator.FromHtml("#000000");
                buttonsInformations.FlatStyle = FlatStyle.Flat;
                buttonsInformations.FlatAppearance.BorderSize = 0;
                buttonsInformations.Dock = DockStyle.Fill;
                // buttonsInformations.Image = Image.FromFile("Assets/Icon-car.png");
                // buttonsInformations.ImageAlign = ContentAlignment.MiddleLeft;
                // buttonsInformations.Click += new EventHandler(Informations);
                divVertical.Controls.Add(buttonsInformations, i, 0);
            }












        }
    }
}