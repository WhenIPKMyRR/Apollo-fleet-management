namespace Models
{
    public class Client
    {
        public int ClientId {get; set;}
        public string Name {get; set;}
        public string Telephone{get; set;}
        public string Address {get; set;}
        public string Document {get; set;}


        protected Client(
            string Name, 
            string Telephone, 
            string Address, 
            string Document
        )
        {
            this.Name = Name;
            this.Telephone = Telephone;
            this.Address = Address;
            this.Document = Document;

            Repository.Context context = new Repository.Context();
            context.Clients.Add(this);
            context.SaveChanges();
        }

        public Client()
        {

        }

        public override string ToString()
        {
            return "Id:" + ClientId + "\n" +
            "Name:" + Name + "\n" +
            "Telephone:" + Telephone + "\n" +
            "Address:" + Address + "\n" +
            "Document:" + Document;
        }

        public override bool Equals(object obj)
        {
            Client client = (Client)obj;
            return ClientId == client.ClientId;
        }

        public static Client CreateClient(
            string Name,
            string Telephone,
            string Address,
            string Document
        )
        {
            return new Client(
                Name,
                Telephone,
                Address,
                Document
            );
        }

        public static IEnumerable<Client> ReadAllClients()
        {
            Repository.Context context = new Repository.Context();
            return context.Clients.ToList();           
        }

        public static Client UpdateClient(
            int ClientId,
            string Name,
            string Telephone,
            string Address,
            string Document
        )
        {
            Client client = ReadByIdClient(
                ClientId
            );

            client.Name = Name;
            client.Telephone = Telephone;
            client.Address = Address;
            client.Document = Document;

            Repository.Context context = new Repository.Context();
            context.Clients.Update(client);
            context.SaveChanges();

            return client;
        }

        public static Client ReadByIdClient(
            int ClientId
        )
        {
            Repository.Context context = new Repository.Context();
            return context.Clients.Find(
                ClientId
            );
        }

        public static void DeleteClient(
            int ClientId
        )
        {
            Client client = ReadByIdClient(
                ClientId
            );

            Repository.Context context = new Repository.Context();
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        public static IEnumerable<Client> ReadByNameClient(
            string Name
        )
        {
            Repository.Context context = new Repository.Context();
            return context.Clients.Where(
                c => c.Name.Contains(Name)
            ).ToList();
        }
    }
}