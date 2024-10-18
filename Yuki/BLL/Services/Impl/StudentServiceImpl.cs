using BLL.Interfaces;
using BLL.Models;
using BLL.DLL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Impl
{
    public class StudentServiceImpl : Service, IGenericService<Student, StudentModel>
    {
        public StudentServiceImpl(StudentsDBContext studentsDBContext) : base(studentsDBContext)
        {
        }

        public Task<Service> Create(Student type)
        {
            throw new NotImplementedException();
        }

        public Task<Service> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<StudentModel> Query()
        {
            return StudentsDBContext.Students.OrderBy(student => student.Name).Select(student => new StudentModel { Student = student });
        }

        public Task<Service> Update(Student type)
        {
            throw new NotImplementedException();
        }
    }
}
