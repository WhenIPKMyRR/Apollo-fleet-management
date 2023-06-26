namespace Models
{
    public class Model
    {
        public int ModelId {get; set;}
        public string Name {get; set;}
        public int BrandId {get; set;}

        protected Model(string Name, int BrandId)
        {
            this.Name = Name;
            this.BrandId = BrandId;

            Repository.Context context = new Repository.Context();
            context.Models.Add(this);
            context.SaveChanges();
        }

        public Model()
        {

        }

        public override string ToString()
        {
            return "Id:" + ModelId + "\n" +
            "Name:" + Name + "\n" +
            "Brand:" + BrandId;
        }

        public override bool Equals(object obj)
        {
            Model model = (Model)obj;
            return ModelId == model.ModelId;
        }

        public static Model CreateModel(
            string Name,
            int BrandId
        )
        {
            return new Model(
                Name,
                BrandId
            );
        }

        public static IEnumerable<Model> ReadAllModel()
        {
            Repository.Context context = new Repository.Context();
            return context.Models.ToList();           
        }

        public static Model UpdateModel(
            int ModelId,
            string Name,
            int BrandId
        )
        {
            Model model = ReadByIdModel(
                ModelId
            );

            model.Name = Name;
            model.BrandId = BrandId;

            Repository.Context context = new Repository.Context();
            context.Models.Update(model);
            context.SaveChanges();

            return model;
        }

        public static void DeleteModel(
            int ModelId
        )
        {
            Model model = ReadByIdModel(
                ModelId
            );

            Repository.Context context = new Repository.Context();
            context.Models.Remove(model);
            context.SaveChanges();
        }

        public static Model ReadByIdModel(
            int ModelId
        )
        {
            Repository.Context context = new Repository.Context();
            Model model = context.Models.Find(ModelId);
            if(model == null)
            {
                throw new ArgumentException("Modelo não encontrado");   
            }
            else
            {
                return model;
            }
        }

        public static IEnumerable<Model> ReadByBrandIdModel(
            int BrandId
        )
        {
            Repository.Context context = new Repository.Context();
            return context.Models.Where(model => model.BrandId == BrandId).ToList();
        }
    }
}