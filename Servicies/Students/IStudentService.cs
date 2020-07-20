using Data;
using Data.Entities;
using Servicies.Students.Dto;
using System.Collections.Generic;

namespace Servicies.Students
{
    public interface IStudentService : IRepository<Student>
    {
        StudentDto StudentDetail(int id);
        IEnumerable<StudentDto> StudentList();
        void CreateStudent(StudentDto student);
        void StudentEdit(StudentDto student);
        void StudentDelete(int id);
    }
}
