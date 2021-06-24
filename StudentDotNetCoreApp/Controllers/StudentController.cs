using StudentDotNetCoreApp.DAL;
using StudentDotNetCoreApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDotNetCoreApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;
        public StudentController()
        {
            _studentRepository = new StudentRepository(new StudentDBEntities());
        }
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _studentRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Insert(model);
                _studentRepository.Save();
                return RedirectToAction("Index", "Student");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditStudent(int StudentId)
        {
            Student model = _studentRepository.GetById(StudentId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Update(model);
                _studentRepository.Save();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeleteStudent(int StudentId)
        {
            Student model = _studentRepository.GetById(StudentId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int StudentID)
        {
            _studentRepository.Delete(StudentID);
            _studentRepository.Save();
            return RedirectToAction("Index", "Student");
        }
    }
}
