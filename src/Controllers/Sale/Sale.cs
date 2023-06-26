namespace Controllers{

    public class Sale{

        public static Models.Sale CreateSale(
            int carId,
            int clientId,
            int sellerId
        )
        {
            if(carId > 0)
            {
                return Models.Sale.CreateSale(
                    carId,
                    clientId,
                    sellerId
                );
            }
            else
            {
                throw new System.ArgumentException("Não foi possivel criar a venda");
            }
        }

        public static IEnumerable<Models.Sale> ReadAllSale()
        {
            IEnumerable<Models.Sale> sales = Models.Sale.ReadAllSale();

            if(sales != null){
                return sales;
            }
            else
            {
                throw new System.ArgumentException("Nenhuma venda encontrada");
            }
        }

        public static Models.Sale ReadSaleById(int id)
        {
            Models.Sale sale = Models.Sale.ReadByIdSale(id);
            
            if(sale != null){
                return sale;
            }
            else
            {
                throw new System.ArgumentException("Venda não encontrada");
            }
        }

        public static void UpdateSale(
            int id,
            int carId,
            int clientId,
            int sellerId
        )
        {
            Models.Sale sale = Models.Sale.ReadByIdSale(id);

            if(sale != null){
                Models.Sale.UpdateSale(
                    id,
                    carId,
                    clientId,
                    sellerId
                );
            }
            else
            {
                throw new System.ArgumentException("Venda não encontrada");
            }
        }

        public static void DeleteSale(int id)
        {

            if(id > 0){
                Models.Sale.DeleteSale(id);
            }
            else
            {
                throw new System.ArgumentException("Venda não encontrada");
            }
        }


    }
}