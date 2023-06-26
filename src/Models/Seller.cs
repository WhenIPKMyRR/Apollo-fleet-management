namespace Models
{
    public class Seller
    {
        public int SellerId {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Telephone {get; set;}
        public int Registration {get; set;}

        public Seller(string Name, string Email, string Telephone, int Registration)
        {
            this.Name = Name;
            this.Email = Email;
            this.Telephone = Telephone;
            this.Registration = Registration;

            Repository.Context context = new Repository.Context();
            context.Sellers.Add(this);
            context.SaveChanges();
        }

        public Seller()
        {

        }

        public override string ToString()
        {
            return "Id:" + SellerId + "\n" + 
            "Name:" + Name + "\n" +
            "Email:" + Email + "\n" +
            "Telephone:" + Telephone + "\n" +
            "Registration:" + Registration;
        }

        public override bool Equals(object obj)
        {
            Seller seller = (Seller)obj;
            return SellerId == seller.SellerId;
        }

        public static Seller CreateSeller(
            string Name,
            string Email,
            string Telephone,
            int Registration
        )
        {
            return new Seller(
                Name,
                Email,
                Telephone,
                Registration
            );
        }

        public static IEnumerable<Seller> ReadAllSeller()
        {
            Repository.Context context = new Repository.Context();
            return context.Sellers.ToList();           
        }

        public static Seller UpdateSeller(
            int SellerId,
            string Name,
            string Email,
            string Telephone,
            int Registration
        )
        {
            Seller seller = ReadByIdSeller(
                SellerId
            );

            seller.Name = Name;
            seller.Email = Email;
            seller.Telephone = Telephone;
            seller.Registration = Registration;

            Repository.Context context = new Repository.Context();
            context.Sellers.Update(seller);
            context.SaveChanges();

            return seller;
        }

        public static void DeleteSeller(
            int SellerId
        )
        {
            Seller seller = ReadByIdSeller(
                SellerId
            );

            Repository.Context context = new Repository.Context();
            context.Sellers.Remove(seller);
            context.SaveChanges();
        }
        
        public static Seller ReadByIdSeller(
            int SellerId
        )
        {
            Repository.Context context = new Repository.Context();
            Seller seller = context.Sellers.Find(SellerId);
            if(seller == null)
            {
                throw new ArgumentException("Vendedor não encontrado");
            }
            else
            {
                return seller;
            }
        }
    }
}