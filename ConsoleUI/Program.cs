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

            //AddCustomer();

            //AddRental();

        }
        private static void AddRental()
        {

            //int carIdToRent ;

            //int customerIdToRent ;
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rentalToAdd = new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = null,
            };
            Console.WriteLine(rentalManager.Add(rentalToAdd));

        }

        

        private static void AddCustomer()
        {

            int userIdToAdd = 1;
            string companyNameToAdd = "test co";
            string userFirstNameToAdd = "test";
            string userLastNameToAdd = "testo";

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            User userToAdd = new User
            {
                Id = userIdToAdd,
                FirstName = userFirstNameToAdd,
                LastName = userLastNameToAdd,
            };
            userManager.Add(userToAdd);

            Customer customerToAdd = new Customer
            {
                Id = userIdToAdd,
                UsersId = userIdToAdd,
                CompanyName = companyNameToAdd,
            };


            customerManager.Add(customerToAdd);

            Console.WriteLine("GetAll Methodu Testi:");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id);
            }

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.Id);
            }

        }



        private static void TestCodes()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //UserManager userManager = new UserManager(new EfUserDal());
           //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());



            brandManager.Add(new Brand { Id = 1, Name = "Audi" });
            colorManager.Add(new Color { Id = 1, Name = "Kırmızı" });
            carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2000, DailyPrice = 1000, Description = "İlk arabamiz." });

            brandManager.Add(new Brand { Id = 2, Name = "BMW" });
            colorManager.Add(new Color { Id = 2, Name = "Siyah" });
            carManager.Add(new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2010, DailyPrice = 2000, Description = "İkinci arabamiz." });



            AddCustomer();
            AddRental();

            //Console.WriteLine("GetAll Methodu Testi:");
            //foreach (var car in carManager.GetAll().Data)
            //{
            //    Console.WriteLine(car.Id);
            //}
            //Console.WriteLine("................");
            //int testId = new int();
            //testId = 1;
            //Car oneCar;

            //Console.WriteLine("GetById Testi 1 numaralı arabayı getirecek.");

            //oneCar = carManager.GetById(testId).Data;
            //Console.WriteLine("ID:" + oneCar.Id + " Model Yılı:" + oneCar.ModelYear + " Marka Kodu:" + oneCar.BrandId + " Renk Kodu:" + oneCar.ColorId + " Güncel Fiyat:" + oneCar.DailyPrice + " Açıklaması:" + oneCar.Description);

            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            //}

            //foreach (var car in carManager.GetAll().Data)
            //{
            //    carManager.Delete(car);
            //    Console.WriteLine(car.Id + " car silindi.");
            //}

            //foreach (var brand in brandManager.GetAll().Data)
            //{
            //    brandManager.Delete(brand);
            //    Console.WriteLine(brand.Id + " brand silindi.");
            //}
            //foreach (var color in colorManager.GetAll().Data)
            //{
            //    colorManager.Delete(color);
            //    Console.WriteLine(color.Id + " color silindi.");
            //}
        }

    }
}
