using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data.Repositories.Abstractions
{
    public  interface ICarRepository
    {
        Car GetCarById(int carId);

        IEnumerable<Car> GetCarQuery(Expression<Func<Car,bool>> expression);

        IEnumerable<Car> GetAll();

        void AddCar(Car entity);

        void AddRange(IEnumerable<Car> entities);

        void UpdateCar(Car entity);

        void RemoveCar(Car entity);

        void SaveChanges();

    }
}
