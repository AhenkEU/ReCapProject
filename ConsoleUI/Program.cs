using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
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
            Console.WriteLine("ID:"+oneCar.Id+" Model Yılı:"+ oneCar.ModelYear+" Marka Kodu:"+oneCar.BrandId+" Renk Kodu:" + oneCar.ColorId+" Güncel Fiyat:"+oneCar.DailyPrice +" Açıklaması:"+oneCar.Description);
        }

       
    }
}
