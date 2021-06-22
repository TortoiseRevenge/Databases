using CodeTheWay.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Services
{
    public interface IStudentsService
    {
        public Task<Student> CreateStudent(Student student);

        public Task<List<Student>> GetStudents();
    }
}
