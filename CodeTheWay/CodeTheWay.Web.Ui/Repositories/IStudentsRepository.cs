using CodeTheWay.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Repositories
{
    public interface IStudentsRepository
    {
        public Task<Student> Create(Student student);

        public Task<List<Student>> GetStudents();
    }
}
