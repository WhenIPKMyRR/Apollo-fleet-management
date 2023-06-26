// namespace Views
// {
//     public class Create : Form
//     {
//         public Label lblType;
//         public Label lblValue;
//         public Label lblIdCar;
//         public TextBox txtType;
//         public TextBox txtValue;
//         public TextBox txtIdCar;
//         public Button btCrt;

//         public void btCrt_Click(object sender, EventArgs e)
//         {
//             if
//             (
//                 txtType.Text == "" ||
//                 txtValue.Text == "" ||
//                 txtIdCar.Text == ""
//             )

//             {
//                 MessageBox.Show("Please fill all the fields");
//             }
//             else
//             {

//             }
//         }
//     }

//     public Create()
//     {
//         this.Text = "Update Document";
//         this.StartPosition = FormStartPosition.CenterScreen;
//         this.FormBorderStyle = FormBorderStyle.FixedSingle;
//         this.MaximizeBox = false;
//         this.MinimizeBox = false;
//         this.ShowIcon = false;
//         this.ShowInTaskbar = false;
//         this.Size = new System.Drawing.Size(280, 360);

//         this.lblType = new Label();
//         this.lblType.Text = "Type";
//         this.lblType.Location = new Point(10, 40);
//         this.lblType.Size = new Size(50, 20);

//         this.txtType = new TextBox();
//         this.txtType.Location = new Point(80, 40);
//         this.txtType.Size = new Size(150, 20);

//         this.lblValue = new Label();
//         this.lblValue.Text = "Value";
//         this.lblValue.Location = new Point(10, 70);
//         this.lblValue.Size = new Size(50, 20);

//         this.txtValue = new TextBox();
//         this.txtValue.Location = new Point(80, 70);
//         this.txtValue.Size = new Size(150, 20);

//         this.lblIdCar = new Label();
//         this.lblIdCar.Text = "Car";
//         this.lblIdCar.Location = new Point(10, 110);
//         this.lblIdCar.Size = new Size(50, 20);

//         this.txtIdCar = new TextBox();
//         this.txtIdCar.Location = new Point(80, 110);                 
//         this.txtIdCar.Size = new Size(150, 20);
//     }
// }