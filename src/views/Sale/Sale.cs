namespace Views
{
    public class CreateSale : Form
    {
        public Label lblDate;
        public Label lblCarId;
        public Label lblClientId;
        public Label lblSellerId;
        public TextBox txtDate;
        public TextBox txtCarId;
        public TextBox txtClientId;
        public TextBox txtSellerId;
        public Button btCrt;

        public void btCrt_Click(object sender, EventArgs e)
        {
            Controllers.Sale.CreateSale(
                Convert.ToInt32(txtCarId.Text),
                Convert.ToInt32(txtClientId.Text),
                Convert.ToInt32(txtSellerId.Text)
            );

            MessageBox.Show("Venda criada com sucesso");

            ListSale SaleList = Application.OpenForms.OfType<ListSale>().FirstOrDefault();
            if (SaleList == null)
            {
                SaleList.RefreshList();
            }
            this.Close();
        }
    }
}