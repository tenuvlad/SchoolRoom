using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.Teachers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicies.Teachers
{
    public class TeacherService : Repository<Teacher>, ITeacherService
    {
        private readonly SchoolContext _context;
        private readonly IRepository<CourseAssignment> _assignmentRepo;
        private readonly IMapper _mapper;

        public TeacherService(SchoolContext context, IMapper mapper, IRepository<CourseAssignment> assignmentRepo) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _assignmentRepo = assignmentRepo;
        }

        public TeacherDto TeacherDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var teacher = _context.Teachers
                .Include(table => table.CourseAssignment)
                .ThenInclude(entity => entity.Course).ToList();
            var teacherEntity = GetById(id);
            var teacherMap = _mapper.Map<TeacherDto>(teacherEntity);
            return teacherMap;
        }

        public IEnumerable<TeacherDto> TeacherList()
        {
            var teacher = GetAll();
            var teacherMap = _mapper.Map<IEnumerable<TeacherDto>>(teacher);
            return teacherMap;
        }

        public void CreateTeacher(TeacherDto teacher)
        {
            if (teacher == null) throw new ArgumentNullException(nameof(teacher));
            var teacherEntity = new Teacher
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                DateOfBirth = teacher.DateOfBirth,
                City = teacher.City,
                Email = teacher.Email,
                HireDate = teacher.HireDate
            };
            Add(teacherEntity);
            Commit();

            var courseAssignment = new CourseAssignment
            {
                TeacherId = teacherEntity.Id,
                CourseId = teacher.CourseId
            };
            _assignmentRepo.Add(courseAssignment);
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
                teacherEntity.DateOfBirth = teacher.DateOfBirth;
                teacherEntity.City = teacher.City;
                teacherEntity.Email = teacher.Email;
                teacherEntity.HireDate = teacher.HireDate;
                teacherEntity.OfficeAssignment = teacher.OfficeAssignment;
            }
            Update(teacherEntity);
            var courseAssignment = new CourseAssignment
            {
                TeacherId = teacher.Id,
                CourseId = teacher.CourseId
            };
            _assignmentRepo.Add(courseAssignment);
            Commit();
        }

        public void TeacherDelete(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var teacherEntity = GetById(id);
            Delete(teacherEntity);
            Commit();
        }

    }
}
