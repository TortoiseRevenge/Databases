using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Services
{
    public class StudentsService : IStudentsService
    {
        private IStudentsRepository StudentRepo;

        public StudentsService(AppDbContext dbContext) 
        {
            this.StudentRepo = new StudentsRepository(dbContext);
        }

        public async Task<Student> Create(Student student)
        {
            return await this.StudentRepo.Create(student);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await this.StudentRepo.GetStudents();
        }
        public async Task<Student> GetStudent(Guid id)
        {
            return await this.StudentRepo.GetStudent(id);
        }
        public async Task<Student> Update(Student student)
        {
            return await StudentRepo.Update(student);
        }
        public async Task<Student> Delete(Student student)
        {
            return await StudentRepo.Delete(student);
        }

    }
}
