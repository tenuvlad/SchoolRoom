using AutoMapper;
using Data.Entities;
using Servicies.Courses.Dto;
using Servicies.Departments.Dto;
using Servicies.OfficeAssignments.Dto;
using Servicies.Students.Dto;
using Servicies.Teachers.Dto;
using System.Linq;

namespace Servicies.Infrastructure
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Department, DepartmentDetailDto>();

            CreateMap<DepartmentDto, Department>()
                .ForMember(course => course.Courses, opt => opt
                .MapFrom(course => course.Courses
                .Select(courseEntity => courseEntity.Id).ToList()));

            CreateMap<Department, DepartmentDto>();

            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<OfficeAssignment, OfficeAssignmentsDto>();
            CreateMap<OfficeAssignmentsDto, OfficeAssignment>();

            CreateMap<Course, CourseDetailDto>()
                .ForMember(numberStudent => numberStudent.NumberOfStudents, opt => opt
                .MapFrom(enroll => enroll.Enrollments
                .Select(student => student.Student).Count()));

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>()
                .ForMember(department => department.DepartmentId, opt => opt
                .MapFrom(table => table.Department.Id))
                .ForMember(student => student.Enrollments, opt => opt
                .MapFrom(table => table.Enrollments
                .Select(entity => entity.Student).Where(studentId => studentId.Id == table.StudentId)))
                .ForMember(teacher => teacher.CourseAssignments, opt => opt
                .MapFrom(table => table.CourseAssignments
                .Select(entity => entity.Teacher).Where(teacherId => teacherId.Id == table.TeacherId)));
        }
    }
}
