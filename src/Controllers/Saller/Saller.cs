namespace Controllers{

    public class Saller{

        public static Models.Seller CreateSaller(
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

        public static IEnumerable<Models.Seller> ReadAllSaller()
        {
            IEnumerable<Models.Seller> sallers = Models.Seller.ReadAllSeller();

            if(sallers != null){
                return sallers;
            }
            else
            {
                throw new Exception("Nenhum vendedor encontrado");
            }
        }

        public static Models.Seller ReadSallerById(int id)
        {
            Models.Seller saller = Models.Seller.ReadByIdSeller(id);
            
            if(saller != null){
                return saller;
            }
            else
            {
                throw new Exception("Vendedor não encontrado");
            }
        }

        public static Models.Seller UpdateSaler(
            int SallerId,
            string Name,
            string Email,
            string Telephone,
            int Registration
        )
        {
            Models.Seller saller = ReadSallerById(
                SallerId
            );

            if( saller != null)
            {
                return Models.Seller.UpdateSeller(
                    SallerId,
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

        public static void DeleteSaller(
            int SallerId
        )
        {
            if( SallerId > 0)
            {
                Models.Seller.DeleteSeller(
                    SallerId
                );
            }
            else
            {
                throw new Exception("Vendedor não encontrado");
            }
        }

    }
}