using AutoMapper;
using Data;
using Data.Entities;
using Servicies.Students.Dto;
using System;
using System.Collections.Generic;

namespace Servicies.Students
{
    public class StudentService : Repository<Student>, IStudentService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public StudentService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public StudentDto StudentDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
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
            var studentMap = _mapper.Map<Student>(student);
            Add(studentMap);
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
        }

        public void StudentDelete(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var studentEntity = GetById(id);
            var studentMap = _mapper.Map<Student>(studentEntity);
            Delete(studentMap);
            Commit();
        }
    }
}
