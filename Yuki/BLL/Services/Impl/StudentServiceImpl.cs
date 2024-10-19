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

        public async Task<Service> Create(Student type)
        {
          bool exist = StudentsDBContext.Students.Any(student => student.Id == type.Id);  
            
            if (exist)
            {
                return Error("EXISTS!!!");
            }

            StudentsDBContext.Students.Add(type);
            await StudentsDBContext.SaveChangesAsync();
            return Success("Inserted!!");
        }

        public async Task<Service> Delete(int id)
        {
            Student student = await StudentsDBContext.Students.Select(student => student).Where(student => student.Id == id).FirstOrDefaultAsync();
           
            if (student != null)
            {
                StudentsDBContext.Students.Remove(student);
                await StudentsDBContext.SaveChangesAsync();
                return Success("Successful");
            }

            return Error($"Can't Access the Student with id {id}");
        }

        public IQueryable<StudentModel> Query()
        {
            return StudentsDBContext.Students.OrderBy(student => student.Name).Select(student => new StudentModel { Student = student });
        }

        public async Task<Service> Update(Student type)
        {
            bool exist = StudentsDBContext.Students.Any(student => student.Id == type.Id);

            if (!exist)
            {
                return Error("Does not Exist!!!");
            }

            StudentsDBContext.Students.Update(type);
            await StudentsDBContext.SaveChangesAsync();
            return Success("Updated");
        }
    }
}
