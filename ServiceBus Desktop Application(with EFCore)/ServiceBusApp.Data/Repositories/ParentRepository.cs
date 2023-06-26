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
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;

        public ParentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddParent(Parent entity)
        {
            _context.Add(entity);
            this.SaveChanges();
        }

        public void AddRange(IEnumerable<Parent> entities)
        {
            _context.AddRange(entities);
            this.SaveChanges();
        }

        public IEnumerable<Parent> GetAll()
        {
            return _context.Parents.Include(p => p.Students);
        }

        public Parent GetParentById(int parentId)
        {
            return _context.Parents.Include(p => p.Students).FirstOrDefault(p => p.Id == parentId);
        }

        public IEnumerable<Parent> GetParentQuery(Expression<Func<Parent, bool>> expression)
        {
            return _context.Parents.Include(p => p.Students).Where(expression).AsEnumerable();
        }

        public void RemoveParent(Parent entity)
        {
            _context.Remove(entity);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateParent(Parent entity)
        {
            _context.Update(entity);
            this.SaveChanges();
        }
    }
}
