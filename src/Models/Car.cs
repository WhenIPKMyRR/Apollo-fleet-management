namespace Models
{
    public class Car
    {
        public int CarId { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string BodyworkType  { get; set; }
        public int Price { get; set; }
        public string ChassisCode { get; set; }
        public string RenavanCode { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public int CarMileage { get; set; }
        public bool IsUsed { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public int GarageId { get; set; }
        public virtual Brand brand {get; set;}
        public virtual Model model {get; set;}
        public virtual Garage garage {get; set;}

    


        protected Car(int Year, string Color, string LicensePlate, string BodyworkType, int Price, string ChassisCode, string RenavanCode, string FuelType, string TransmissionType, int CarMileage, bool IsUsed, int ModelId, int BrandId, int GarageId)
        {
            this.Year = Year;
            this.Color = Color;
            this.LicensePlate = LicensePlate;
            this.BodyworkType = BodyworkType;
            this.Price = Price;
            this.ChassisCode = ChassisCode;
            this.RenavanCode = RenavanCode;
            this.FuelType = FuelType;
            this.TransmissionType = TransmissionType;
            this.CarMileage = CarMileage;
            this.IsUsed = IsUsed;
            this.ModelId = ModelId;
            this.BrandId = BrandId;
            this.GarageId = GarageId;

            Repository.Context context = new Repository.Context();
            context.Cars.Add(this);
            context.SaveChanges();
        }

        public Car()
        {

        }

        public override string ToString()
        {
            return "Id:" + CarId + "\n" +
            "Year:" + Year + "\n" +
            "Color:" + Color + "\n" +
            "LicensePlate:" + LicensePlate + "\n" +
            "BodyworkType:" + BodyworkType + "\n" +
            "Price:" + Price + "\n" +
            "ChassisCode:" + ChassisCode + "\n" +
            "RenavanCode:" + RenavanCode + "\n" +
            "FuelType:" + FuelType + "\n" +
            "ransmissionType:" + TransmissionType + "\n" +
            "CarMileage:" + CarMileage + "\n" +
            "IsUsed:" + IsUsed + "\n" +
            "ModelId:" + ModelId + "\n" +
            "BrandId:" + BrandId + "\n" +
            "GarageId:" + GarageId;
        }

        public override bool Equals(object obj)
        {
            Car car = (Car)obj;
            return CarId == car.CarId;
        }

        public static Car CreateCar(
            int Year,
            string Color,
            string LicensePlate,
            string BodyworkType,
            int Price,
            string ChassisCode,
            string RenavanCode,
            string FuelType,
            string TransmissionType,
            int CarMileage,
            bool IsUsed,
            int ModelId,
            int BrandId,
            int GarageId
        )
        {
            return new Car(
                Year,
                Color,
                LicensePlate,
                BodyworkType,
                Price,
                ChassisCode,
                RenavanCode,
                FuelType,
                TransmissionType,
                CarMileage,
                IsUsed,
                ModelId,
                BrandId,
                GarageId
            );
        }

        public static IEnumerable<Car> ReadAllCars()
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.ToList();
        }

        public static Car UpdateCar(
            int CarId,
            int Year,
            string Color,
            string LicensePlate,
            string BodyworkType,
            int Price,
            string ChassisCode,
            string RenavanCode,
            string FuelType,
            string TransmissionType,
            int CarMileage,
            bool IsUsed,
            int ModelId,
            int BrandId,
            int GarageId
        )
        {
            Car car = ReadByIdCar(
                CarId
            );

            car.Year = Year;
            car.Color = Color;
            car.LicensePlate = LicensePlate;
            car.BodyworkType = BodyworkType;
            car.Price = Price;
            car.ChassisCode = ChassisCode;
            car.RenavanCode = RenavanCode;
            car.FuelType = FuelType;
            car.TransmissionType = TransmissionType;
            car.CarMileage = CarMileage;
            car.IsUsed = IsUsed;
            car.ModelId = ModelId;
            car.BrandId = BrandId;
            car.GarageId = GarageId;

            Repository.Context context = new Repository.Context();
            context.Cars.Update(car);
            context.SaveChanges();
            return car;
        }

        public static Car ReadByIdCar(int CarId)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Find(CarId);
        }

        public static void DeleteCar(int CarId)
        {
            Car car = ReadByIdCar(CarId);

            Repository.Context context = new Repository.Context();
            context.Cars.Remove(car);
            context.SaveChanges();

        }

        public static IEnumerable<Car> ReadAllCarsByBrand(int BrandId)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public static IEnumerable<Car> ReadAllCarsByModel(int ModelId)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Where(c => c.ModelId == ModelId).ToList();
        }

        public static IEnumerable<Car> ReadAllCarsByYear(int Year)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Where(c => c.Year == Year).ToList();
        }

        public static IEnumerable<Car> ReadAllCarsByColor(string Color)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Where(c => c.Color == Color).ToList();
        }

        public static IEnumerable<Car> ReadAllCarsByPlate(string LicensePlate)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Where(c => c.LicensePlate == LicensePlate).ToList();
        }

        public static IEnumerable<Car> ReadAllCarsByBodyworkType(string BodyworkType)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Where(c => c.BodyworkType == BodyworkType).ToList();
        }

        public static IEnumerable<Car> ReadAllCarsByPrice(decimal Price)
        {
            Repository.Context context = new Repository.Context();
            return context.Cars.Where(c => c.Price == Price).ToList();
        }   


    }
}