using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data.Repositories.Abstractions
{
    public interface IDriverRepository
    {
        Driver GetDriverById(int driverId);

        IEnumerable<Driver> GetAll();

        void AddDriver(Driver entity);

        void AddRange(IEnumerable<Driver> entities);

        void UpdateDriver(Driver entity);

        void RemoveDriver(Driver entity);

        void SaveChanges();

        IEnumerable<Driver> GetDriverQuery(Expression<Func<Driver, bool>> expression);
    }
}
