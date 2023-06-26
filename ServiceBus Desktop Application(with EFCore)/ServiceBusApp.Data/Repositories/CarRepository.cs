using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public void AddCar(Car entity)
        {
            _context.Cars.Add(entity);
            this.SaveChanges();
        }

        public void AddRange(IEnumerable<Car> entities)
        {
            _context.AddRange(entities);
            this.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.Include(c => c.Driver);
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Include(c => c.Driver).FirstOrDefault(c => c.Id == carId);
        }

        public void RemoveCar(Car entity)
        {
            _context.Remove(entity);
            this.SaveChanges();
        }
        public void UpdateCar(Car entity)
        {
            _context.Update(entity);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetCarQuery(Expression<Func<Car, bool>> expression)
        {
            return _context.Cars.Include(c => c.Driver).Where(expression).AsEnumerable();
        }
    }
}
