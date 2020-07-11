using Data;
using Data.Entities;
using Servicies.Courses.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Courses
{
    public interface ICourseService : IRepository<Course>
    {
        IEnumerable<CourseDetailDto> CourseList();
        CourseDetailDto CourseDetail(int id);
        void CreateNewCourse(CourseDto course);
        void EditCourse(CourseDto course);
        void DeleteCourse(int id);
    }
}
