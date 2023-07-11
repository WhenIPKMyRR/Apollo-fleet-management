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
            Models.Garage garage = Models.Garage.ReadGarageById(id);
            
            if(garage != null){
                return garage;
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

        public static Models.Garage UpdateGarage(
            int id,
            string name,
            string address,
            string phoneNumber
        )
        {
            Models.Garage garageToUpdate = Models.Garage.ReadGarageById(id);

            garageToUpdate.Name = name;
            garageToUpdate.Address = address;
            garageToUpdate.PhoneNumber = phoneNumber;

            Models.Garage garageUpdated = Models.Garage.UpdateGarage(
                garageToUpdate.GarageId,
                garageToUpdate.Name,
                garageToUpdate.Address,
                garageToUpdate.PhoneNumber
            );

            if (garageUpdated == null)
            {
                throw new System.ArgumentException("Garagem não encontrado");
            }

            return garageUpdated;
        }

        public static void DeleteGarage(int id)
        {
            Models.Garage Garage = Models.Garage.ReadGarageById(id);

            if(Garage != null){
                Models.Garage.DeleteGarage(id);
            }
            else
            {
                throw new System.ArgumentException("Garagem não encontrado");
            }
        }



    }
}