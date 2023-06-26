using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data.Repositories.Abstractions
{
    public interface IClassRepository
    {
        Class GetClassById(int classId);

        IEnumerable<Class> GetAll();

        void AddClass(Class entity);

        void AddRange(IEnumerable<Class> entities);

        void UpdateClass(Class entity);

        void RemoveClass(Class entity);

        void SaveChanges();

        IEnumerable<Class> GetClassQuery(Expression<Func<Class, bool>> expression);
    }
}
