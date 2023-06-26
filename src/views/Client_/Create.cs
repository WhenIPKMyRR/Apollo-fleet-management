// namespace Views
// {
//     public class Create : Form
//     {
//         public Label lblName;
//         public Label lblTelephone;
//         public Label lblAddress;
//         public Label lblDocument;
//         public TextBox txtName;
//         public TextBox txtTelephone;
//         public TextBox txtAddress;
//         public TextBox txtDocument;
//         public Button btCrt;

//         public void btCrt_Click(object sender, EventArgs e)
//         {
//             if
//             (
//                 txtName.Text == "" ||
//                 txtTelephone.Text == "" ||
//                 txtAddress.Text == "" ||
//                 txtDocument.Text == ""
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
//         this.Text = "Update Client";
//         this.StartPosition = FormStartPosition.CenterScreen;
//         this.FormBorderStyle = FormBorderStyle.FixedSingle;
//         this.MaximizeBox = false;
//         this.MinimizeBox = false;
//         this.ShowIcon = false;
//         this.ShowInTaskbar = false;
//         this.Size = new System.Drawing.Size(280, 360);

//         this.lblName = new Label();
//         this.lblName.Text = "Name";
//         this.lblName.Location = new Point(10, 40);
//         this.lblName.Size = new Point(50, 20);

//         this.txtName = new TextBox();
//         this.txtName.Location = new Point(80, 40);
//         this.txtName.Size = new Size(150, 20);

//         this.lblTelephone = new Label();
//         this.lblTelephone.Text = "Telephone";
//         this.lblTelephone.Location = new Point(10, 70);
//         this.lblTelephone.Size = new Size(50, 20);

//         this.txtTelephone = TextBox();
//         this.txtTelephone.Location = new Point(80, 70);
//         this.txtTelephone.Size = new Size(150, 20);

//         this.lblAddress = new Label();
//         this.lblAddress.Text = "Address";
//         this.lblAddress.Location = new Point(10, 110);
//         this.lblAddress.Size = new Size(50, 20);

//         this.txtAddress = new TextBox();
//         this.txtAddress.Location = new Point(80, 110);
//         this.txtAddress.Size = new Size(150, 20);

//         this.lblDocument = new Label();
//         this.lblDocument.Text = "Document";
//         this.lblDocument.Location = new Point(10, 140);
//         this.lblDocument.Size = new Size(50, 20);

//         this.txtDocument = new TextBox();
//         this.txtDocument.Location = new Point(80, 140);
//         this.txtDocument.Size = new Size(150, 20);
//     }
// }