using StudentDotNetCoreApp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentDotNetCoreApp.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBEntities _context;
        public StudentRepository()
        {
            _context = new StudentDBEntities();
        }
        public StudentRepository(StudentDBEntities context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public Student GetById(int StudentID)
        {
            return _context.Students.Find(StudentID);
        }
        public void Insert(Student student)
        {
            _context.Students.Add(student);
        }
        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }
        public void Delete(int StudentID)
        {
            Student student = _context.Students.Find(StudentID);
            _context.Students.Remove(student);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
