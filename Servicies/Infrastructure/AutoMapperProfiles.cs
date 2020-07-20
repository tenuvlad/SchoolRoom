using AutoMapper;
using Data.Entities;
using Servicies.Courses.Dto;
using Servicies.Departments.Dto;
using Servicies.Grades.Dto;
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
            CreateMap<Grade, GradeDto>()
                .ForMember(student => student.StudentsList, opt => opt
                .MapFrom(table => table.StudentScore
                .Select(entity => entity.Student)));
            CreateMap<GradeDto, Grade>()
                .ForMember(student => student.StudentScore, opt => opt
                .MapFrom(table => table.StudentScore
                .Select(entity => entity.Student)
                .Where(studentId => studentId.Id == table.StudentId)));

            CreateMap<Department, DepartmentDetailDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>()
                .ForMember(course => course.Course, opt => opt
                .MapFrom(course => course.Courses
                .Select(courseEntity => courseEntity.Id).ToList()))
                .ForMember(teacher => teacher.InstructorId, opt => opt
                .MapFrom(entity => entity.Teacher.Id));

            CreateMap<TeacherDto, Teacher>()
                .ForMember(courseassignemt => courseassignemt.CourseAssignment, opt => opt
                .MapFrom(table => table.CourseAssignments
                .Select(entity => entity.Course)
                .Where(courseId => courseId.Id == table.CourseId)));
            CreateMap<Teacher, TeacherDto>()
                .ForMember(course => course.CourseList, opt => opt
                .MapFrom(table => table.CourseAssignment
                .Select(entity => entity.Course)));

            CreateMap<StudentDto, Student>()
                .ForMember(enrollment => enrollment.Enrollment, opt => opt
                .MapFrom(table => table.Enrollment
                .Select(entity => entity.Student)
                .Where(courseId => courseId.Id == table.CourseId)));
            CreateMap<Student, StudentDto>()
                .ForMember(course => course.CoursesList, opt => opt
                .MapFrom(table => table.Enrollment
                .Select(entity => entity.Course)))
                .ForMember(grade => grade.GradesList, opt => opt
                .MapFrom(table => table.StudentScore
                .Select(entity => entity.Grade)))
                .ForMember(score => score.ScoreAverage, opt => opt
                .MapFrom(table => table.StudentScore
                .Select(grade => grade.Grade).Average(score => score.Score)));

            CreateMap<OfficeAssignmentsDto, OfficeAssignment>();
            CreateMap<OfficeAssignment, OfficeAssignmentsDto>();

            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseDetailDto>()
                .ForMember(numberStudent => numberStudent.NumberOfStudents, opt => opt
                .MapFrom(table => table.Enrollment
                .Select(entity => entity.Student).Count()))
                .ForMember(teacher => teacher.TeachersList, opt => opt
                .MapFrom(table => table.CourseAssignment
                .Select(entity => entity.Teacher)))
                .ForMember(student => student.StudentsList, opt => opt
                .MapFrom(table => table.Enrollment
                .Select(entity => entity.Student)));
            CreateMap<CourseDto, Course>()
                .ForMember(department => department.DepartmentId, opt => opt
                .MapFrom(table => table.Department.Id))
                .ForMember(student => student.Enrollment, opt => opt
                .MapFrom(table => table.Enrollments
                .Select(entity => entity.Student)
                .Where(studentId => studentId.Id == table.StudentId)))
                .ForMember(teacher => teacher.CourseAssignment, opt => opt
                .MapFrom(table => table.CourseAssignments
                .Select(entity => entity.Teacher)
                .Where(teacherId => teacherId.Id == table.TeacherId)));
        }
    }
}
