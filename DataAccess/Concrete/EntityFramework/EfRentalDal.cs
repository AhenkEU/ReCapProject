using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,RecapContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join customer in context.Customers on rental.CustomerId equals customer.UsersId
                             join user in context.Users on rental.CustomerId equals user.Id
                             
                             select new RentalDetailDto
                             {  
                                   RentalId = rental.Id,
                                   CarId = car.Id,
                                   CarName = car.Description,
                                   UserName = (user.FirstName+" "+user.LastName),
                                   CustomerName = customer.CompanyName,
                             //    DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }

        }
    }
}
