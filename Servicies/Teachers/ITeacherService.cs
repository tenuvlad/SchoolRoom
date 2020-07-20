using Data;
using Data.Entities;
using Servicies.Teachers.Dto;
using System.Collections.Generic;

namespace Servicies.Teachers
{
    public interface ITeacherService : IRepository<Teacher>
    {
        TeacherDto TeacherDetail(int id);
        IEnumerable<TeacherDto> TeacherList();
        void CreateTeacher(TeacherDto teacher);
        void TeacherEdit(TeacherDto teacher);
        void TeacherDelete(int id);
    }
}
