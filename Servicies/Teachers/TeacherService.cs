using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.Courses.Dto;
using Servicies.Teachers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicies.Teachers
{
    public class TeacherService : Repository<Teacher>, ITeacherService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public TeacherService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public TeacherDto TeacherDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var teacher = _context.Teachers
                .Include(table => table.CourseAssignments)
                .ThenInclude(entity => entity.Course).ToList();
            var teacherEntity = GetById(id);
            var teacherMap = _mapper.Map<TeacherDto>(teacherEntity);
            return teacherMap;
        }

        public IEnumerable<TeacherDto> TeacherList()
        {
            var teacher = GetAll();
/*            teacher = _context.Teachers
                .Include(office => office.OfficeAssignment)
                .Include(course => course.CourseAssignments)
                    .ThenInclude(entityCourse => entityCourse.Course)
                        .ThenInclude(entityEnrollment => entityEnrollment.Enrollments)
                            .ThenInclude(entityStudent => entityStudent.Student)
                .Include(course => course.CourseAssignments)
                    .ThenInclude(entityCourse => entityCourse.Course)
                        .ThenInclude(entityDepartment => entityDepartment.Department)
                .OrderBy(name => name.FullName).ToList();*/
            var teacherMap = _mapper.Map<IEnumerable<TeacherDto>>(teacher);
            return teacherMap;
        }

        public void CreateTeacher(TeacherDto teacher)
        {
            if (teacher == null) throw new ArgumentNullException(nameof(teacher));
            var teacherMap = _mapper.Map<Teacher>(teacher);
            Add(teacherMap);
            Commit();
        }

        public void TeacherEdit(TeacherDto teacher)
        {
            if (teacher == null) throw new ArgumentNullException(nameof(teacher));
            var teacherEntity = GetById(teacher.Id);
            if (teacherEntity != null)
            {
                teacherEntity.Id = teacher.Id;
                teacherEntity.FirstName = teacher.FirstName;
                teacherEntity.LastName = teacher.LastName;
                teacherEntity.HireDate = teacher.HireDate;
                teacherEntity.OfficeAssignment = teacher.OfficeAssignment;
                teacherEntity.CourseAssignments = teacher.CourseAssignments;
            }
            var teacherMap = _mapper.Map<Teacher>(teacherEntity);
            Update(teacherMap);
        }

        public void TeacherDelete(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var teacherEntity = GetById(id);
            var teacherMap = _mapper.Map<Teacher>(teacherEntity);
            Delete(teacherMap);
            Commit();
        }
    }
}
