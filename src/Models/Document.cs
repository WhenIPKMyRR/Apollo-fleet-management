namespace Models
{
    public class Document
    {
        public int DocumentId {get; set;}
        public string Type {get; set;}
        public string Value {get; set;}
        public int CarId {get; set;}
        public virtual Car car {get; set;}
        
        


        protected Document(string Type, string Value, int CarId)
        {
            this.Type = Type;
            this.Value = Value;
            this.CarId = CarId;

            Repository.Context context = new Repository.Context();
            context.Documents.Add(this);
            context.SaveChanges();
        }
        public Document()
        {
            
        }

        public override string ToString()
        {
            return "Id:" + DocumentId + "\n" +
            " Type:" + Type + "\n" +
            " Value:" + Value + "\n" +
            " CarId:" + CarId;
        }

        public override bool Equals(object obj)
        {
            Document document = (Document)obj;
            return DocumentId == document.DocumentId;
        }

        public static Document CreateDocument(
            string Type,
            string Value,
            int CarId
        )
        {
            return new Document(
                Type,
                Value,
                CarId
            );
        }

        public static IEnumerable<Document> ReadAllDocument()
        {
            Repository.Context context = new Repository.Context();
            return context.Documents.ToList();           
        }

        public static Document UpdateDocument(
            int DocumentId,
            string Type,
            string Value,
            int CarId
        )
        {
            Document document = ReadByIdDocument(
                DocumentId
            );

            document.Type = Type;
            document.Value = Value;
            document.CarId = CarId;

            Repository.Context context = new Repository.Context();
            context.Documents.Update(document);
            context.SaveChanges();
            return document;
        }

        public static void DeleteDocument(
            int DocumentId
        )
        {
            Document document = ReadByIdDocument(
                DocumentId
            );

            Repository.Context context = new Repository.Context();
            context.Documents.Remove(document);
            context.SaveChanges();
        }

        public static void DeleteDocumentByValue(
            string value
        )
        {
            Document document = ReadByValueDocument(
                value
            );

            Repository.Context context = new Repository.Context();
            context.Documents.Remove(document);
            context.SaveChanges();
        }


        public static Document ReadByIdDocument(
            int DocumentId
        )
        {
            Repository.Context context = new Repository.Context();
            Document document = context.Documents.Find(DocumentId);
            {
                if (document == null)
                {
                    throw new ArgumentException("Documento não encontrado");
                }
                else
                {
                    return document;
                }
            }
        }

        public static Document ReadByValueDocument(string value)
        {
            Repository.Context context = new Repository.Context();
            Document document =  context.Documents.Where(d => d.Value == value).FirstOrDefault();
            {
                if (document == null)
                {
                    throw new ArgumentException("Documento não encontrado");
                }
                else
                {
                    return document;
                }
            }
        }

    }
}