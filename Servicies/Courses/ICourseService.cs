using Data;
using Data.Entities;
using Servicies.Courses.Dto;
using System.Collections.Generic;

namespace Servicies.Courses
{
    public interface ICourseService : IRepository<Course>
    {
        IEnumerable<CourseDetailDto> CourseList();
        CourseDetailDto CourseDetail(int id);
        CourseDto CourseForEditDetail(int id);
        void CreateNewCourse(CourseDto course);
        void EditCourse(CourseDto course);
        void DeleteCourse(int id);
        bool CourseTitleExist(string title);
    }
}
