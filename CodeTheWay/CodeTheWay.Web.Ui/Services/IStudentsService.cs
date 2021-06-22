using CodeTheWay.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Services
{
    public interface IStudentsService
    {
        public Task<Student> Create(Student student);

        public Task<List<Student>> GetStudents();
        public Task<Student> GetStudent(Guid id);


        public Task<Student> Update(Student student);

        public Task<Student> Delete(Student student);
    }
}
