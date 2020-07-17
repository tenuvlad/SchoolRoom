using Data;
using Data.Entities;
using Servicies.Students.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servicies.Students
{
    public interface IStudentService : IRepository<Student>
    {
        StudentDto StudentDetail(int id);
        IEnumerable<StudentDto> StudentList();
        void CreateStudent(StudentDto student);
        void StudentEdit(StudentDto student);
        void StudentDelete(int id);
        bool FirstNameExists(string firstName);
        bool LastNameExists(string lastName);
    }
}
