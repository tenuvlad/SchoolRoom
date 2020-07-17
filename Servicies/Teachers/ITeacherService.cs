using Data;
using Data.Entities;
using Servicies.Teachers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servicies.Teachers
{
    public interface ITeacherService : IRepository<Teacher>
    {
        TeacherDto TeacherDetail(int id);
        IEnumerable<TeacherDto> TeacherList();
        void CreateTeacher(TeacherDto teacher);
        void TeacherEdit(TeacherDto teacher);
        void TeacherDelete(int id);
        bool FirstNameExists(string firstName);
        bool LastNameExists(string lastName);
    }
}
