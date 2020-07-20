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
        private readonly IRepository<Enrollment> _enrollmentsRepo;
        private readonly IRepository<CourseAssignment> _assignmentRepo;

        public CourseService(SchoolContext context, IMapper mapper, IRepository<Enrollment> enrollmentsRepo, IRepository<CourseAssignment> assignmentRepo) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _enrollmentsRepo = enrollmentsRepo;
            _assignmentRepo = assignmentRepo;
        }

        public CourseDetailDto CourseDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var courseEntity = GetById(id);
            var studentCourse = _context.Courses.Include(table => table.Enrollment).ThenInclude(entity => entity.Student).ToList();
            var teacherCourse = _context.Courses.Include(table => table.CourseAssignment).ThenInclude(entity => entity.Teacher).ToList();
            var departmentCourse = _context.Courses.Include(table => table.Department).ToList().Where(departmentId => departmentId.DepartmentId == id);
            var courseMap = _mapper.Map<CourseDetailDto>(courseEntity);
            return courseMap;
        }
        public CourseDto CourseForEditDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var courseEntity = GetById(id);
            var courseMap = _mapper.Map<CourseDto>(courseEntity);
            return courseMap;
        }

        public IEnumerable<CourseDetailDto> CourseList()
        {
            var course = _context.Courses.Include(table => table.Enrollment).ThenInclude(student => student.Student).ToList();
            var departmentCourse = _context.Courses.Include(table => table.Department).ToList().Where(departmentId => departmentId.DepartmentId == departmentId.Id);
            var courseMap = _mapper.Map<IEnumerable<CourseDetailDto>>(course);
            return courseMap;
        }

        public void CreateNewCourse(CourseDto course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            var courseEntity = new Course
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                CourseNumber = course.CourseNumber,
                DepartmentId = course.DepartmentId
            };
            Add(courseEntity);
            Commit();

            var enrollment = new Enrollment
            {
                StudentId = course.StudentId,
                CourseId = courseEntity.Id
            };
            _enrollmentsRepo.Add(enrollment);

            var courseAssignment = new CourseAssignment
            {
                TeacherId = course.TeacherId,
                CourseId = courseEntity.Id
            };
            _assignmentRepo.Add(courseAssignment);
            Commit();
        }

        public void EditCourse(CourseDto course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            var courseEntity = new Course
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                CourseNumber = course.CourseNumber,
                DepartmentId = course.DepartmentId
            };
            Update(courseEntity);
            var enrollment = new Enrollment
            {
                StudentId = course.StudentId,
                CourseId = courseEntity.Id
            };
            _enrollmentsRepo.Add(enrollment);

            var courseAssignment = new CourseAssignment
            {
                TeacherId = course.TeacherId,
                CourseId = courseEntity.Id
            };
            _assignmentRepo.Add(courseAssignment);
            Commit();
        }

        public void DeleteCourse(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var courseEntity = GetById(id);
            Delete(courseEntity);
            Commit();
        }

        public bool CourseTitleExist(string title)
        {
            if (_context.Courses.Any(x => x.Title == title))
                return true;

            return false;
        }
    }
}
