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
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>()
                .ForMember(course => course.Courses, opt => opt
                .MapFrom(course => course.Courses
                .Select(courseEntity => courseEntity.Id).ToList()))
                .ForMember(teacher => teacher.TeacherId, opt => opt
                .MapFrom(entity => entity.Teacher.Id));

            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherDto>()
                .ForMember(course => course.CourseList, opt => opt
                .MapFrom(table => table.CourseAssignments
                .Select(entity => entity.Course)));

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>()
                .ForMember(course => course.CourseList, opt => opt
                .MapFrom(table => table.Enrollment
                .Select(entity => entity.Course)));

            CreateMap<OfficeAssignmentsDto, OfficeAssignment>();
            CreateMap<OfficeAssignment, OfficeAssignmentsDto>();

            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseDetailDto>()
                .ForMember(numberStudent => numberStudent.NumberOfStudents, opt => opt
                .MapFrom(table => table.Enrollments
                .Select(entity => entity.Student).Count()))
                .ForMember(teacher => teacher.TeachersList, opt => opt
                .MapFrom(table => table.CourseAssignments
                .Select(entity => entity.Teacher)))
                .ForMember(student => student.StudentsList, opt => opt
                .MapFrom(table => table.Enrollments
                .Select(entity => entity.Student)));
            CreateMap<CourseDto, Course>()
                .ForMember(department => department.DepartmentId, opt => opt
                .MapFrom(table => table.Department.Id))
                .ForMember(student => student.Enrollments, opt => opt
                .MapFrom(table => table.Enrollments
                .Select(entity => entity.Student)
                .Where(studentId => studentId.Id == table.StudentId)))
                .ForMember(teacher => teacher.CourseAssignments, opt => opt
                .MapFrom(table => table.CourseAssignments
                .Select(entity => entity.Teacher)
                .Where(teacherId => teacherId.Id == table.TeacherId)));
        }
    }
}
