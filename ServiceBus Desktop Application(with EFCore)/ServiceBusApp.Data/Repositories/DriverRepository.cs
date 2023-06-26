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
    public class DriverRepository : IDriverRepository
    {
        private readonly ApplicationDbContext _context;

        public DriverRepository(ApplicationDbContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public void AddDriver(Driver entity)
        {
            _context.Drivers.Add(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<Driver> entities)
        {
            _context.AddRange(entities);
            SaveChanges();
        }

        public IEnumerable<Driver> GetAll()
        {
            return _context.Drivers.Include(d => d.Car).Include(d => d.Ride);
        }

        public Driver GetDriverById(int driverId)
        {
            return _context.Drivers.Include(d => d.Car).FirstOrDefault(d => d.Id == driverId);
        }

        public IEnumerable<Driver> GetDriverQuery(Expression<Func<Driver, bool>> expression)
        {
            return _context.Drivers.Include(d => d.Car).Where(expression).AsEnumerable();
        }

        public void RemoveDriver(Driver entity)
        {
            _context.Remove(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateDriver(Driver entity)
        {
            _context.Update(entity);
            SaveChanges();
        }
    }
}
