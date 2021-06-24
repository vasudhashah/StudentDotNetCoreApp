using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDotNetCoreApp.DAL;

namespace StudentDotNetCoreApp.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int StudentID);
        void Insert(Student student);
        void Update(Student student);
        void Delete(int StudentID);
        void Save();
    }
}
