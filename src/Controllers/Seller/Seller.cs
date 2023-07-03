namespace Controllers{

    public class Seller{

        public static Models.Seller CreateSeller(
            string Name,
            string Email,
            string Telephone,
            int Registration
        )
        {
            if( Name.Length > 2 )
            {
                return Models.Seller.CreateSeller(
                    Name,
                    Email,
                    Telephone,
                    Registration
                );
            }
            else
            {
                throw new Exception("Nome inválido");
            }
        }

        public static IEnumerable<Models.Seller> ReadAllSeller()
        {
            IEnumerable<Models.Seller> sellers = Models.Seller.ReadAllSeller();

            if(sellers != null){
                return sellers;
            }
            else
            {
                throw new Exception("Nenhum vendedor encontrado");
            }
        }

        public static Models.Seller ReadSellerById(int id)
        {
            Models.Seller seller = Models.Seller.ReadByIdSeller(id);
            
            if(seller != null){
                return seller;
            }
            else
            {
                throw new Exception("Vendedor não encontrado");
            }
        }

        public static Models.Seller UpdateSeller(
            int SellerId,
            string Name,
            string Email,
            string Telephone,
            int Registration
        )
        {
            Models.Seller saller = ReadSellerById(
                SellerId
            );

            if( saller != null)
            {
                return Models.Seller.UpdateSeller(
                    SellerId,
                    Name,
                    Email,
                    Telephone,
                    Registration
                );
            }
            else
            {
                throw new Exception("Vendedor não encontrado");
            }
        }

        public static void DeleteSeller(
            int SellerId
        )
        {
            if( SellerId > 0)
            {
                Models.Seller.DeleteSeller(
                    SellerId
                );
            }
            else
            {
                throw new Exception("Vendedor não encontrado");
            }
        }

    }
}