namespace Controllers{

    public class Document{

        public static Models.Document CreateDocument(
            string Type,
            string Value,
            int CarId
        )
        {
            if(CarId > 0)
            {
                return Models.Document.CreateDocument(
                    Type,
                    Value,
                    CarId
                );
            }
            else
            {
                throw new System.ArgumentException("Não foi possivel achar o veiculo");
            }
        }

        public static IEnumerable<Models.Document> ReadAllDocument()
        {
            IEnumerable<Models.Document> documents = Models.Document.ReadAllDocument();

            if(documents != null){
                return documents;
            }
            else
            {
                throw new System.ArgumentException("Nenhum documento encontrado");
            }
        }

        public static Models.Document ReadDocumentById(int id)
        {
            Models.Document document = Models.Document.ReadByIdDocument(id);
            
            if(document != null){
                return document;
            }
            else
            {
                throw new System.ArgumentException("Documento não encontrado");
            }
        }

        public static Models.Document ReadDocumentByValue(string value)
        {
            Models.Document document = Models.Document.ReadByValueDocument(value);

            if(document != null){
                return document;
            }
            else
            {
                throw new System.ArgumentException("Documento não encontrado");
            }
        }

        public static void UpdateDocument(
            int id,
            string Type,
            string Value,
            int CarId
        )
        {
            Models.Document document = Models.Document.ReadByIdDocument(id);

            if(document != null){
                Models.Document.UpdateDocument(
                    id,
                    Type,
                    Value,
                    CarId
                );
            }
            else
            {
                throw new System.ArgumentException("Documento não encontrado");
            }
        }

        public static void DeleteDocument(int id)
        {

            if(id > 0){
                Models.Document.DeleteDocument(id);
            }
            else
            {
                throw new System.ArgumentException("Documento não encontrado");
            }
        }

         public static void DeleteDocumentByValue(string value)
        {

            if(value != null){
                Models.Document.DeleteDocumentByValue(value);
            }
            else
            {
                throw new System.ArgumentException("Documento não encontrado");
            }
        }




    }
}