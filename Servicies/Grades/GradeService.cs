using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.Grades.Dto;
using Servicies.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicies.Grades
{
    public class GradeService : Repository<Grade>, IGradeService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;
        private readonly IRepository<StudentScore> _studentScoreRepo;

        public GradeService(SchoolContext context, IMapper mapper, IRepository<StudentScore> studentScoreRepo) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _studentScoreRepo = studentScoreRepo;
        }

        public GradeDto GradeDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var gradeModel = _context.Grades.Include(table => table.StudentScore).ThenInclude(entity => entity.Student).ToList();
            var gradeEntity = GetById(id);
            var gradeMap = _mapper.Map<GradeDto>(gradeEntity);
            return gradeMap;
        }

        public IEnumerable<GradeDto> GradeList()
        {
            var gradeEntity = GetAll();
            var gradeMap = _mapper.Map<IEnumerable<GradeDto>>(gradeEntity);
            return gradeMap;
        }

        public void CreateGrade(GradeDto grade)
        {
            if (grade == null) throw new ArgumentNullException(nameof(grade));
            var gradeEntity = new Grade
            {
                Id = grade.Id,
                Score = grade.Score,
                DateOfTheGrade = grade.DateOfTheGrade
            };
            Add(gradeEntity);
            Commit();

            var studentScore = new StudentScore
            {
                GradeId = gradeEntity.Id,
                StudentId = grade.StudentId
            };
            _studentScoreRepo.Add(studentScore);
            Commit();
        }

        public void GradeEdit(GradeDto grade)
        {
            if (grade == null) throw new ArgumentNullException(nameof(grade));
            var gradeEntity = GetById(grade.Id);
            if (gradeEntity != null)
            {
                gradeEntity.Id = grade.Id;
                gradeEntity.Score = grade.Score;
                gradeEntity.DateOfTheGrade = grade.DateOfTheGrade;
            }
            Update(gradeEntity);
            var studentScore = new StudentScore
            {
                StudentId = grade.StudentId,
                GradeId = gradeEntity.Id
            };
            _studentScoreRepo.Add(studentScore);
            Commit();
        }
        public void GradeDelete(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var gradeEntity = GetById(id);
            Delete(gradeEntity);
            Commit();
        }
    }
}
