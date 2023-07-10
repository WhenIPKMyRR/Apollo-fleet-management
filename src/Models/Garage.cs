namespace Models
{
    public class Garage
    {
        public int GarageId {get; set;}
        public string Name {get; set;}
        public string Address {get; set;}
        public string PhoneNumber {get; set;}

    
        public Garage(string Name, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;

            Repository.Context context = new Repository.Context();
            context.Garages.Add(this);
            context.SaveChanges();
        }
        public Garage()
        {

        }

        public override string ToString()
        {
            return "Id: " + GarageId + "\n" +
                "Name" + Name + "\n" +
                "Address" + Address + "\n" +
                "PhoneNumber" + PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            Garage garage = (Garage)obj;
            return GarageId == garage.GarageId;
        }

        public static Garage CreateGarage(
            string Name,
            string Address,
            string PhoneNumber
        )
        {
            return new Garage(
                Name,
                Address,
                PhoneNumber
            );
        }

        public static IEnumerable<Garage> ReadAllGarages()
        {
            Repository.Context context = new Repository.Context();
            return context.Garages.ToList();           
        }

        public static Garage ReadGarageById(
            int garageId
        )
        {
            Repository.Context context = new Repository.Context();
            Garage garage = context.Garages.Find(garageId);

            if (garage == null)
            {
                throw new ArgumentException("Garagem não encontrada");
            }
            return garage;
        }

        public static Garage ReadGarageByName( string Name )
        {
            Repository.Context context = new Repository.Context();
            Garage garage = context.Garages.FirstOrDefault(
                garage => garage.Name == Name
            );

            if (garage == null)
            {
                throw new ArgumentException("Garagem não encontrada");
            }

            return garage;
        }
        public static Models.Garage UpdateGarage(Garage garage)
        {
            Models.Garage garageToUpdate = ReadGarageById(garage.GarageId);

            Repository.Context context = new Repository.Context();
            context.Garages.Update(garageToUpdate);
            context.SaveChanges();
            
            return garageToUpdate;
        }


        public static void DeleteGarage(
            int GarageId
        )
        {
            Garage garage = ReadGarageById(
                GarageId
            );

            Repository.Context context = new Repository.Context();
            context.Garages.Remove(garage);
            context.SaveChanges();
        }


    }
}
