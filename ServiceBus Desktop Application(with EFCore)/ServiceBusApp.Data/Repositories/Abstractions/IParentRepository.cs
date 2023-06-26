using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data.Repositories.Abstractions
{
    public interface IParentRepository
    {
        Parent GetParentById(int parentId);

        IEnumerable<Parent> GetAll();

        void AddParent(Parent entity);

        void AddRange(IEnumerable<Parent> entities);

        void UpdateParent(Parent entity);

        void RemoveParent(Parent entity);

        void SaveChanges();

        IEnumerable<Parent> GetParentQuery(Expression<Func<Parent,bool>> expression);
    }
}
