using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.Courses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicies.Courses
{
    public class CourseService : Repository<Course>, ICourseService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public CourseService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public CourseDetailDto CourseDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var courseEntity = GetById(id);
            var course = _context.Courses.Include(table => table.Enrollments).ThenInclude(student => student.Student).ToList();
            var courseMap = _mapper.Map<CourseDetailDto>(courseEntity);
            return courseMap;
        }

        public IEnumerable<CourseDetailDto> CourseList()
        {
            var course = _context.Courses.Include(table => table.Enrollments).ThenInclude(student => student.Student).ToList();
            var courseMap = _mapper.Map<IEnumerable<CourseDetailDto>>(course);
            return courseMap;
        }

        public void CreateNewCourse(CourseDto course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            var courseMap = _mapper.Map<Course>(course);
            Add(courseMap);
            Commit();
        }

        public void EditCourse(CourseDto course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            var courseEntity = GetById(course.Id);
            if (courseEntity != null)
            {
                courseEntity.Id = course.Id;
                courseEntity.Credits = course.Credits;
                courseEntity.DepartmentId = course.DepartmentId;
                courseEntity.Enrollments = course.Enrollment;
                courseEntity.Title = course.Title;
            }
            var courseMap = _mapper.Map<Course>(courseEntity);
            Update(courseMap);
        }

        public void DeleteCourse(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var courseEntity = GetById(id);
            var courseMap = _mapper.Map<Course>(courseEntity);
            Delete(courseMap);
            Commit();
        }
    }
}
