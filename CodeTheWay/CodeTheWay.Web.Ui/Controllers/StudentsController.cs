using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentsService StudentService;

        public StudentsController(IStudentsService studentsService)
        {
            this.StudentService = studentsService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await StudentService.GetStudents());
        }
        public async Task<IActionResult> Create()
        {
            
            return View(new StudentRegistrationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(StudentRegistrationViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                if (model.Age < 19)
                {
                    Student student = new Student()
                    {
                        Id = model.Id,
                        LastName = model.LastName,
                        FirstMidName = model.FirstMidName,
                    };
                    
                    var result = await StudentService.Create(student);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            StudentRegistrationViewModel stud = new StudentRegistrationViewModel()
            {
                Age = 0,
                Id = id,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
            };


            return View(stud);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(StudentRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Age < 19)
                {
                    Student stud = new Student()
                    {
                        Id = model.Id,
                        FirstMidName = model.FirstMidName,
                        LastName = model.LastName,

                    };

                    var result = await StudentService.Update(stud);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var student = await StudentService.GetStudent(id);
            StudentRegistrationViewModel stud = new StudentRegistrationViewModel()
            {
                Age = 0,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                Id = student.Id,
            };
            
            return View(stud);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            await StudentService.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
