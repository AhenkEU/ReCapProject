using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCodes();
            
            

        }

        private static void TestCodes()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());



            brandManager.Add(new Brand { Id = 1, Name = "Audi" });
            colorManager.Add(new Color { Id = 1, Name = "Kırmızı" });
            carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2000, DailyPrice = 1000, Description = "İlk arabamiz." });

            brandManager.Add(new Brand { Id = 2, Name = "BMW" });
            colorManager.Add(new Color { Id = 2, Name = "Siyah" });
            carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 2, ModelYear = 2010, DailyPrice = 2000, Description = "İkinci arabamiz." });





            Console.WriteLine("GetAll Methodu Testi:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }
            Console.WriteLine("................");
            int testId = new int();
            testId = 1;
            Car oneCar;

            Console.WriteLine("GetById Testi 1 numaralı arabayı getirecek.");

            oneCar = carManager.GetById(testId);
            Console.WriteLine("ID:" + oneCar.Id + " Model Yılı:" + oneCar.ModelYear + " Marka Kodu:" + oneCar.BrandId + " Renk Kodu:" + oneCar.ColorId + " Güncel Fiyat:" + oneCar.DailyPrice + " Açıklaması:" + oneCar.Description);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
            
            foreach (var car in carManager.GetAll())
            {
                carManager.Delete(car);
                Console.WriteLine(car.Id + " car silindi.");
            }

            foreach (var brand in brandManager.GetAll())
            {
                brandManager.Delete(brand);
                Console.WriteLine(brand.Id + " brand silindi.");
            }
            foreach (var color in colorManager.GetAll())
            {
                colorManager.Delete(color);
                Console.WriteLine(color.Id + " color silindi.");
            }
        }

    }
}
