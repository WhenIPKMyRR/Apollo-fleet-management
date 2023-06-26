namespace Models
{
    public class Sale
    {
        public int SaleId {get; set;}
        public int CarId {get; set;}
        public int ClientId {get; set;}
        public int SellerId {get; set;}

        public Sale(int CarId, int ClientId, int SellerId)
        {
            this.CarId = CarId;
            this.ClientId = ClientId;
            this.SellerId = SellerId;

            Repository.Context context = new Repository.Context();
            context.Sales.Add(this);
            context.SaveChanges();
        }

        public Sale()
        {

        }

        public override string ToString()
        {
            return "Id:" + SaleId + "\n" +
            "Id Car:" + CarId + "\n" +
            "Id Client:" + ClientId + "\n" +
            "Id Seller:" + SellerId;
        }

        public override bool Equals(object obj)
        {
            Sale sale = (Sale)obj;
            return SaleId == sale.SaleId;
        }

        public static Sale CreateSale(
            int CarId,
            int ClientId,
            int SellerId
        )
        {
            return new Sale(
                CarId,
                ClientId,
                SellerId
            );
        }

        public static IEnumerable<Sale> ReadAllSale()
        {
            Repository.Context context = new Repository.Context();
            return context.Sales.ToList();           
        }

        public static Sale UpdateSale(
            int SaleId,
            int CarId,
            int ClientId,
            int SellerId
        )
        {
            Sale sale = ReadByIdSale(
                SaleId
            );

            sale.CarId = CarId;
            sale.ClientId = ClientId;
            sale.SellerId = SellerId;

            Repository.Context context = new Repository.Context();
            context.SaveChanges();
            return sale;
        }

        public static void DeleteSale(
            int SaleId
        )
        {
            Sale sale = ReadByIdSale(
                SaleId
            );

            Repository.Context context = new Repository.Context();
            context.Sales.Remove(sale);
            context.SaveChanges();
        }

        public static Sale ReadByIdSale(
            int SaleId
        )
        {
            Repository.Context context = new Repository.Context();
            Sale sale = context.Sales.Find(SaleId);
            if(sale == null)
            {
                throw new ArgumentException("Sale not found");
            }
            else
            {
                return sale;
            }

        }
    }
}