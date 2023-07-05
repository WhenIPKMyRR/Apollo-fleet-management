using Models;

namespace Controllers{

    public class Car{

        public static Models.Car CreateCar(
            int year,
            string color,
            string plate,
            string type,
            decimal price,
            string chassis,
            string renavam,
            string fuel,
            string transmission,
            int mileage,
            int idModel,
            int idBrand
        )
        {
            if((year > 1980))
            {
                return Models.Car.CreateCar(
                    year,
                    color,
                    plate,
                    type,
                    price,
                    chassis,
                    renavam,
                    fuel,
                    transmission,
                    mileage,
                    idModel,
                    idBrand
                );
            }
            else
            {
                throw new System.ArgumentException("Nome da marca deve ter mais de 3 caracteres");
            }

        }

        public static IEnumerable<Models.Car> ReadAllCars()
        {
            IEnumerable<Models.Car> cars = Models.Car.ReadAllCars();

            if(cars == null)
            {
                throw new System.ArgumentException("Nenhum carro encontrado");
            }

            return cars;
        }

        public static Models.Car ReadCarById(int id)
        {
            Models.Car car = Models.Car.ReadByIdCar(id);
            
            if(car != null){
                return car;
            }
            else
            {
                throw new System.ArgumentException("Carro não encontrado");
            }
        }

        public static IEnumerable<Models.Car> ReadCarByPlate(string plate)
        {
            IEnumerable<Models.Car> car = Models.Car.ReadAllCarsByPlate(plate);

            if(car != null){
                return car;
            }
            else
            {
                throw new System.ArgumentException("Carro não encontrado");
            }
        }

        public static IEnumerable<Models.Car> ReadCarByBrand(int brandId)
        {
            IEnumerable<Models.Car> car = Models.Car.ReadAllCarsByBrand(brandId);

            if(car != null){
                return car;
            }
            else
            {
                throw new System.ArgumentException("Carro não encontrado");
            }
        }

        public static IEnumerable<Models.Car> ReadCarByModel(int modelId)
        {
            IEnumerable<Models.Car> car = Models.Car.ReadAllCarsByModel(modelId);

            if(car != null){
                return car;
            }
            else
            {
                throw new System.ArgumentException("Carro não encontrado");
            }
        }

        public static IEnumerable<Models.Car> ReadCarByYear(int year)
        {
            IEnumerable<Models.Car> car = Models.Car.ReadAllCarsByYear(year);

            if(car != null){
                return car;
            }
            else
            {
                throw new System.ArgumentException("Carro não encontrado");
            }
        }

        public static Models.Car UpdateCar(
            int id,
            int year,
            string color,
            string plate,
            string type,
            decimal price,
            string chassis,
            string renavam,
            string fuel,
            string transmission,
            int mileage,
            int idModel,
            int idBrand
        )
        {
            Models.Car car = Models.Car.UpdateCar(
                id,
                year,
                color,
                plate,
                type,
                price,
                chassis,
                renavam,
                fuel,
                transmission,
                mileage,
                idModel,
                idBrand
            );

            if(car != null){

                if(id > 0){
                    return car;
                }
                else
                {
                    throw new System.ArgumentException("Todos os campos devem ser preennchidos");
                }
            }
            else
            {
                throw new System.ArgumentException("O Carro não foi encontrado");

            }
        }

        public static void DeleteCar(int id)
        {
            if(id > 0){
                Models.Car.DeleteCar(id);
            }
            else
            {
                throw new System.ArgumentException("O Carro não foi encontrado");
            }
        }
        
        
      



    }
}