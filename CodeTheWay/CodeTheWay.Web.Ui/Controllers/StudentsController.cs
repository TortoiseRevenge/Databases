using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;

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
            Student student = new Student()
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstMidName = model.FirstName
            };
            if (ModelState.IsValid)
            {
                if (model.Age < 19)
                {
                    student = await StudentService.Create(student);
                }

                    return RedirectToAction("Index");
                
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            return View(new StudentRegistrationViewModel()
            {
                Id = id,
                FirstName = student.FirstMidName,
                LastName = student.LastName,
                Age = 0
            }) ;
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(StudentRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Age < 19)
                {
                    var student = await StudentService.Update(new Student()
                    {
                        Id = model.Id,
                        LastName = model.LastName,
                        FirstMidName = model.FirstName
                    });
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            return View(new StudentRegistrationViewModel()
            {
                Id = id,
                FirstName = student.FirstMidName,
                LastName = student.LastName

            }); ;
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            await StudentService.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
