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

        public async Task<Student> CreateStudent(Student student)
        {
            return await this.StudentRepo.Create(student);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await this.StudentRepo.GetStudents();
        }
    }
}
