using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryCarDal : ICarDal
      public class InMemoryCarDal
    {
        List<Car> _cars; //global değişken
        public InMemoryCarDal()
        {
            _cars = new List<Car> {  //proje açıldığında bellekte car listesi için yer aç

                new Car{Id=1,BrandId=11,ColorId=1,ModelYear=2000,DailyPrice=1000,Description="İlk arabamiz." },
                new Car{Id=2,BrandId=12,ColorId=2,ModelYear=2001,DailyPrice=1500,Description="İkinci arabamiz." },
                new Car{Id=3,BrandId=14,ColorId=3,ModelYear=2005,DailyPrice=1700,Description="Üçüncü arabamiz." },
                new Car{Id=4,BrandId=15,ColorId=1,ModelYear=2020,DailyPrice=5000,Description="Dördüncü arabamiz." }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            //_carsı tek tek dolaşıp her c için yolladığım carın idsi eşit mi diye bakıyor.
            //Single sonuçlu bir foreach döngüsü

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }



        public Car GetById(int carId)
        {

            Car carToGetById = _cars.SingleOrDefault(c => c.Id == carId);

            return carToGetById;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
