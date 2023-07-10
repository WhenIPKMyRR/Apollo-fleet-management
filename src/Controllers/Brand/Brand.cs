using Models;

namespace Controllers{

    public class Brand{

        public static Models.Brand CreateBrand(
            string name
        )
        {
            if(name.Length >= 3)
            {
                return Models.Brand.CreateBrand(
                    name
                );
            }
            else
            {
                throw new System.ArgumentException("Nome da marca deve ter mais de 3 caracteres");
            }
        }

        public static IEnumerable<Brand> ReadAllBrands()
        {
            IEnumerable<Brand> brands = Brand.ReadAllBrands();

            if(brands != null){
                return brands;
            }
            else
            {
                throw new System.ArgumentException("Nenhuma marca encontrada");
            }
        }

        public static Models.Brand ReadBrandById(int id)
        {
            Models.Brand brand = Models.Brand.ReadBrandById(id);
            
            if(brand != null){
                return brand;
            }
            else
            {
                throw new System.ArgumentException("Marca não encontrada");
            }
        }

        public static Brand ReadBrandByName(string name)
        {
            Brand brand = Brand.ReadBrandByName(name);

            if(brand != null){
                return brand;
            }
            else
            {
                throw new System.ArgumentException("Marca não encontrada");
            }
        }

        public static void UpdateBrand(
            int id,
            string name
        )
        {
            if((id != 0) && (name != null)){
                Brand.UpdateBrand(id, name);
            }else{
                throw new System.ArgumentException("Id ou nome da marca não podem ser nulos");
            }

        }

        public static void DeleteBrand(
            int id
        )
        {
            if(id != 0){
                Brand.DeleteBrand(id);
            }else{
                throw new System.ArgumentException("Id da marca não pode ser nulo");
            }
        }      

    }
}