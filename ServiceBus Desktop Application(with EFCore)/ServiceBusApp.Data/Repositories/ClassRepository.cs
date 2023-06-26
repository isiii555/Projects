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
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddClass(Class entity)
        {
            _context.Add(entity);
            this.SaveChanges();
        }

        public void AddRange(IEnumerable<Class> entities)
        {
            _context.AddRange(entities);
            this.SaveChanges();
        }

        public IEnumerable<Class> GetAll()
        {
            return _context.Classes.Include(c => c.Students);
        }

        public Class GetClassById(int classId)
        {
            return _context.Classes.Include(c => c.Students).FirstOrDefault(c => c.Id == classId);
        }

        public IEnumerable<Class> GetClassQuery(Expression<Func<Class, bool>> expression)
        {
            return _context.Classes.Include(c => c.Students).Where(expression).AsEnumerable();
        }

        public void RemoveClass(Class entity)
        {
            _context.Remove(entity);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateClass(Class entity)
        {
            _context.Update(entity);
            this.SaveChanges();
        }
    }
}
