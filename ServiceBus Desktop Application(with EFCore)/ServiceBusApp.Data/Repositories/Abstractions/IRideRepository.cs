using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data.Repositories.Abstractions
{
    public interface IRideRepository
    {
        Ride GetRideById(int rideId);

        IEnumerable<Ride> GetAll();

        void AddRide(Ride entity);

        void AddRange(IEnumerable<Ride> entities);

        void UpdateRide(Ride entity);
        void UpdateRange(IEnumerable<Ride> entities);



        void RemoveRide(Ride entity);

        void SaveChanges();

        IEnumerable<Ride> GetRideQuery(Expression<Func<Ride, bool>> expression);
    }
}
