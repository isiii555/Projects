using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data.Repositories.Abstractions
{
    public interface IStudentRepository
    {
        Student GetStudentById(int studentId);

        IEnumerable<Student> GetAll();

        void AddStudent(Student entity);

        void AddRange(IEnumerable<Student> entities);

        void UpdateStudent(Student entity);

        void RemoveStudent(Student entity);

        void SaveChanges();

        IEnumerable<Student> GetStudentQuery(Expression<Func<Student,bool>> expression);
    }
}
