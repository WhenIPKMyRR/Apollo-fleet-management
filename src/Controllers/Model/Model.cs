namespace Controllers{

    public class Model{

        public static Models.Model CreateModel(
            string name,
            int brandId
        )
        {
            if(name.Length >= 2)
            {
                return Models.Model.CreateModel(
                    name,
                    brandId
                );
            }
            else
            {
                throw new System.ArgumentException("Nome do modelo deve ter mais de 2 caracteres");
            }
        }

        public static IEnumerable<Models.Model> ReadAllModels()
        {
            IEnumerable<Models.Model> models = Models.Model.ReadAllModel();

            if(models != null){
                return models;
            }
            else
            {
                throw new System.ArgumentException("Nenhum modelo encontrado");
            }
        }

        public static Models.Model ReadModelById(int id)
        {
            Models.Model model = Models.Model.ReadByIdModel(id);
            
            if(model != null){
                return model;
            }
            else
            {
                throw new System.ArgumentException("Modelo não encontrado");
            }
        }


        public static IEnumerable<Models.Model> ReadModelByBrandId(int brandId)
        {
            IEnumerable<Models.Model> models = Models.Model.ReadByBrandIdModel(brandId);

            if(models != null){
                return models;
            }
            else
            {
                throw new System.ArgumentException("Modelo não encontrado");
            }
        }

        public static Models.Model UpdateModel(
            int id,
            string name,
            int brandId
        )
        {
            if(name.Length >= 2)
            {
                
                Models.Model model = Models.Model.UpdateModel(
                    id,
                    name,
                    brandId
                );

                return model;
            }
            else
            {
                throw new System.ArgumentException("Nome do modelo deve ter mais de 2 caracteres");
            }
        }   

        public static void DeleteModel(int id)
        {

            if(id > 0){
                Models.Model.DeleteModel(id);
            }
            else
            {
                throw new System.ArgumentException("Modelo não encontrado");
            }
        }


    }
}