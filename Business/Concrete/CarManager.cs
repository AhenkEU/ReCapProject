using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && (car.Description).Length >= 2)
                _carDal.Add(car);
            else
                Console.WriteLine("Araba eklenmesi için fiyat 0'dan büyük ve isim iki karakterden uzun olmalıdır.");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            

        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
            
        }

        public Car GetById(int carId) {
            return _carDal.Get(c => c.Id == carId);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0 && (car.Description).Length>=2) 
            {
                _carDal.Update(car);
            }
            else
                Console.WriteLine("Bilgi güncellenmesi için fiyat 0'dan büyük ve isim iki karakterden uzun olmalıdır.");

        }
    }
}
