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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRange(IEnumerable<Student> entities)
        {
            _context.AddRange(entities);
            this.SaveChanges();
        }

        public void AddStudent(Student entity)
        {
            _context.Add(entity);
            this.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(s => s.Class).Include(s => s.Parent);
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Students.Include(s => s.Class).Include(s => s.Parent).FirstOrDefault(s => s.Id == studentId);
        }

        public IEnumerable<Student> GetStudentQuery(Expression<Func<Student, bool>> expression)
        {
            return _context.Students.Include(s => s.Class).Include(s => s.Parent).Where(expression).AsEnumerable();
        }

        public void RemoveStudent(Student entity)
        {
            _context.Remove(entity);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateStudent(Student entity)
        {
            _context.Update(entity);
            this.SaveChanges();
        }
    }
}
