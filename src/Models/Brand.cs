namespace Models
{
    public class Brand
    {
        public int BrandId {get; set;}
        public string Name {get; set;}
    
        public Brand(string Name)
        {
            this.Name = Name;

            Repository.Context context = new Repository.Context();
            context.Brands.Add(this);
            context.SaveChanges();
        }
        public Brand()
        {

        }


        public override string ToString()
        {
            return "Id: " + BrandId + "\n" +
                "Name" + Name;
        }

        public override bool Equals(object obj)
        {
            Brand brand = (Brand)obj;
            return BrandId == brand.BrandId;
        }

        public static Brand CreateBrand(
            string Name
        )
        {
            return new Brand(
                Name
            );
        }

        public static IEnumerable<Brand> ReadAllBrands()
        {
            Repository.Context context = new Repository.Context();
            return context.Brands.ToList();           
        }

        public static Brand UpdateBrand(
            int BrandId,
            string Name
        )
        {
            Brand brand = ReadBrandById(
                BrandId
            );

            brand.Name = Name;

            Repository.Context context = new Repository.Context();
            context.Brands.Update(brand);
            context.SaveChanges();

            return brand;
        }

        public static void DeleteBrand(
            int BrandId
        )
        {
            Brand brand = ReadBrandById(
                BrandId
            );

            Repository.Context context = new Repository.Context();
            context.Brands.Remove(brand);
            context.SaveChanges();
        }

        public static Brand ReadBrandById(
            int BrandId
        )
        {
            Repository.Context context = new Repository.Context();
            Brand brand = context.Brands.Find(BrandId);
            if (brand == null)
            {
                throw new ArgumentException("Marca não encontrada");
            }
            else
            {
                return brand;
            }
        }

        public static Brand ReadBrandByName(
            string Name
        )
        {
            Repository.Context context = new Repository.Context();
            Brand brand = context.Brands.FirstOrDefault(
                brand => brand.Name == Name
            );
            if (brand == null)
            {
                throw new ArgumentException("Marca não encontrada");
            }
            else
            {
                return brand;
            }
        }
    }
}