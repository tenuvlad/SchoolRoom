﻿using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicies.Students
{
    public class StudentService : Repository<Student>, IStudentService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;
        private readonly IRepository<Enrollment> _enrollmentsRepo;

        public StudentService(SchoolContext context, IMapper mapper, IRepository<Enrollment> enrollmentsRepo) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _enrollmentsRepo = enrollmentsRepo;
        }

        public StudentDto StudentDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var studentModel = _context.Students.Include(table => table.Enrollment).ThenInclude(entity => entity.Course).ToList();
            var studentEntity = GetById(id);
            var studentMap = _mapper.Map<StudentDto>(studentEntity);
            return studentMap;
        }

        public IEnumerable<StudentDto> StudentList()
        {
            var student = GetAll();
            var studentMap = _mapper.Map<IEnumerable<StudentDto>>(student);
            return studentMap;
        }

        public void CreateStudent(StudentDto student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            var studentEntity = new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };
            Add(studentEntity);
            Commit();
            var enrollment = new Enrollment
            {
                StudentId = studentEntity.Id,
                CourseId = student.CourseId
            };
            _enrollmentsRepo.Add(enrollment);
            Commit();
        }

        public void StudentEdit(StudentDto student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            var studentEntity = GetById(student.Id);
            if (studentEntity != null)
            {
                studentEntity.Id = student.Id;
                studentEntity.FirstName = student.FirstName;
                studentEntity.LastName = student.LastName;
                studentEntity.EnrollmentDate = student.EnrollmentDate;
                studentEntity.Enrollment = student.Enrollment;
            }
            var studentMap = _mapper.Map<Student>(studentEntity);
            Update(studentMap);
            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                CourseId = student.CourseId
            };
            _enrollmentsRepo.Add(enrollment);
            Commit();
        }

        public void StudentDelete(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var studentEntity = GetById(id);
            var studentMap = _mapper.Map<Student>(studentEntity);
            Delete(studentMap);
            Commit();
        }
        public bool FirstNameExists(string firstName)
        {
            if (_context.Teachers.Any(x => x.FirstName == firstName))
                return true;

            return false;
        }
        public bool LastNameExists(string lastName)
        {
            if (_context.Teachers.Any(x => x.LastName == lastName))
                return true;

            return false;
        }
    }
}
