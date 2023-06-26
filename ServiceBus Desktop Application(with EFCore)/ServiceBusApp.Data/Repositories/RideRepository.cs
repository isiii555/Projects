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
    public class RideRepository : IRideRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<Ride> dbSet;

        public RideRepository(ApplicationDbContext context)
        {
            _context = Guard.Against.Null(context);
            dbSet = _context.Set<Ride>();
        }

        public void AddRange(IEnumerable<Ride> entities)
        {
            _context.Rides.AddRange(entities);
            this.SaveChanges();
        }

        public void AddRide(Ride entity)
        {
            _context.Add(entity);
            this.SaveChanges();
        }

        public IEnumerable<Ride> GetAll()
        {
            return _context.Rides.Include(r => r.Students);
        }

        public Ride GetRideById(int rideId)
        {
            return _context.Rides.Include(r => r.Students).FirstOrDefault(r => r.Id == rideId);
        }

        public IEnumerable<Ride> GetRideQuery(Expression<Func<Ride, bool>> expression)
        {
            return _context.Rides.Include(r => r.Students).Where(expression).AsEnumerable();
        }

        public void RemoveRide(Ride entity)
        {
            _context.Remove(entity);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<Ride> entities)
        {
            _context.UpdateRange(entities);
            this.SaveChanges();
        }

        public void UpdateRide(Ride entity)
        {
            _context.Update(entity);
            this.SaveChanges();
        }
    }
}
