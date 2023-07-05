using Models;

namespace Controllers{

    public class Client{

        public static Models.Client CreateClient(
            string name,
            string telephone,
            string address,
            string document
        )
        {
            if(name.Length > 3)
            {
                return Models.Client.CreateClient(
                    name,
                    telephone,
                    address,
                    document
                );
            }
            else
            {
                throw new System.ArgumentException("Nome do cliente deve ter mais de 3 caracteres");
            }
        }
        
        public static Models.Client ReadClientById(int id)
        {
            Models.Client client = Models.Client.ReadByIdClient(id);
            
            if(client != null){
                return client;
            }
            else
            {
                throw new System.ArgumentException("Cliente não encontrado");
            }
        }

        public static IEnumerable<Models.Client> ReadClientByName(string name)
        {
            IEnumerable<Models.Client> clients = Models.Client.ReadByNameClient(name);

            if(clients != null){
                return clients;
            }
            else
            {
                throw new System.ArgumentException("Cliente não encontrado");
            }
        }

        public static IEnumerable<Models.Client> ReadAllClients()
        {
            IEnumerable<Models.Client> clients = Models.Client.ReadAllClients();

            if(clients == null)
            {
                throw new System.ArgumentException("Nenhum cliente encontrado");
            }
            return clients;
        }

        public static void UpdateClient(
            int id,
            string name,
            string telephone,
            string address,
            string document
        )
        {
            Models.Client client = Models.Client.ReadByIdClient(id);

            if(client != null){
                Models.Client.UpdateClient(
                    id,
                    name,
                    telephone,
                    address,
                    document
                );
            }
            else
            {
                throw new System.ArgumentException("Cliente não encontrado");
            }
        }

        public static void DeleteClient(int id)
        {
            Models.Client client = Models.Client.ReadByIdClient(id);

            if(client != null){
                Models.Client.DeleteClient(id);
            }
            else
            {
                throw new System.ArgumentException("Cliente não encontrado");
            }
        }




    }
}