using Microsoft.AspNetCore.Mvc;
using ADO.Data;
using ADO.Models;

namespace AdoCrudApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDAL dal;

        public StudentController(StudentDAL dal)
        {
            this.dal = dal;
            this.dal.Init();
        }

        public IActionResult Index()
        {
            return View(dal.GetAllStudents());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            dal.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(dal.GetStudentById(id));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            dal.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            dal.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
