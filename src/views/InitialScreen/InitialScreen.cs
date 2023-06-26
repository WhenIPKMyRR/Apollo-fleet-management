// using Models;
// using System;

// namespace Views
// {
//     public class Menu : Form
//     {
//         public static void Index()
//         {
//             Form menu = new Form();

//             menu.Icon = new Icon("Assets/iconHome.ico", 52,52);
//             menu.Text = "Menu";
//             menu.Size = new Size(250, 300);
//             menu.StartPosition = FormStartPosition.CenterScreen;
//             menu.FormBorderStyle = FormBorderStyle.FixedSingle;
//             menu.MaximizeBox = false;
//             menu.MinimizeBox = false;
//             menu.ShowIcon = false;
//             menu.ShowInTaskbar = false;

//             Button btnToCars = new Button();
//             btnToCars.Text = "Carros";
//             btnToCars.Size = new Size(150, 35);
//             btnToCars.Location = new Point(40, 40);
//             btnToCars.Click += (sender, e) => {
//                 menu.Hide();
//                 var listCar = new ListCar();
//                 listCar.ShowDialog();
//                 menu.Show();
//             };
//             Button btnToGarage = new Button();
//             btnToGarage.Text = "Garagens";
//             btnToGarage.Size = new Size(150, 35);
//             btnToGarage.Location = new Point(40, 85);
//             btnToGarage.Click += (sender, e) => {
//                 menu.Hide();
//                 var listGarage = new ListGarage();
//                 listGarage.ShowDialog();
//                 menu.Show();
//             };
//             Button btnToSalesBalance = new Button();
//             btnToSalesBalance.Text = "Balanço dos saldos";
//             btnToSalesBalance.Size = new Size(150, 35);
//             btnToSalesBalance.Location = new Point(40, 130);
//             btnToSalesBalance.Click += (sender, e) => {
//                 menu.Hide();
//                 var listSalesBalance = new ListSalesBalance();
//                 listSalesBalance.ShowDialog();
//                 menu.Show();
//             };
//             Button sair = new Button();
//             sair.Text = "Sair";
//             sair.Size = new Size(150, 35);
//             sair.Location = new Point(40, 175);
//             sair.Click += (sender, e) => {
//                 menu.Close();
//             };

//             menu.Controls.Add(btnToCars);
//             menu.Controls.Add(btnToGarage);
//             menu.Controls.Add(btnToSalesBalance);
//             menu.Controls.Add(sair);
//             menu.ShowDialog();
//         }
//     }
// }