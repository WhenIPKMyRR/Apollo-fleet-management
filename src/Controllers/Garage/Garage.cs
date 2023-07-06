using Models;

namespace Controllers
{
    public class Garage
    {
          public static Models.Garage CreateGarage(
            string name,
            string address,
            string phoneNumber
        )
        {
            if(name.Length > 3)
            {
                return Models.Garage.CreateGarage(
                    name,
                    address,
                    phoneNumber
                );
            }
            else
            {
                throw new System.ArgumentException("Nome do Garagee deve ter mais de 3 caracteres");
            }
        }
        
        public static Models.Garage ReadGarageById(int id)
        {
            Models.Garage Garage = Models.Garage.ReadGarageById(id);
            
            if(Garage != null){
                return Garage;
            }
            else
            {
                throw new System.ArgumentException("Garagem não encontrada");
            }
        }

        public static Models.Garage ReadGarageByName(string name)
        {
            Models.Garage Garage = Models.Garage.ReadGarageByName(name);

            if(Garage == null)
            {
                throw new System.ArgumentException("Nenhuma Garagem encontrada");
            }

            return Garage;
        }

        public static IEnumerable<Models.Garage> ReadAllGarages()
        {
            IEnumerable<Models.Garage> Garages = Models.Garage.ReadAllGarages();

            if(Garages == null)
            {
                throw new System.ArgumentException("Nenhuma Garagem encontrada");
            }
            return Garages;
        }

        public static void UpdateGarage(
            int id,
            string name,
            string address,
            string phoneNumber
        )
        {
            Models.Garage garage = Models.Garage.ReadGarageById(id);

           if (garage != null)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    garage.Name = name;
                }

                if (!string.IsNullOrEmpty(address))
                {
                    garage.Address = address;
                }

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    garage.PhoneNumber = phoneNumber;
                }
            }
            else
            {
                throw new System.ArgumentException("Garagee não encontrado");
            }
        }

        public static void DeleteGarage(int id)
        {
            Models.Garage Garage = Models.Garage.ReadGarageById(id);

            if(Garage != null){
                Models.Garage.DeleteGarage(id);
            }
            else
            {
                throw new System.ArgumentException("Garagee não encontrado");
            }
        }



    }
}