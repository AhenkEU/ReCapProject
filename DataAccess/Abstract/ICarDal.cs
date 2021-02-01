using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    //interfacein kendisi public değil ama operasyonları publictir.
    //Ondan public yazmadık.
    public interface ICarDal
    {
        List<Car> GetAll();

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        Car GetById(int carId);

    }
}

//GetById, GetAll, Add, Update, Delete