using AutoMapper;
using Data;
using Data.Entities;
using Servicies.Grades.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Grades
{
    public class GradeService : Repository<Grade>, IGradeService
    {
        public readonly SchoolContext _context;
        private readonly IMapper _mapper;
        public GradeService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GradeDto> GetGradeList()
        {
            var grades = GetAll();
            var gradeToReturn = _mapper.Map<List<GradeDto>>(grades);

            return gradeToReturn;
        }

        public void AddNewGrade(GradeDto grade)
        {
            var gradereturn = _mapper.Map<Grade>(grade);
            Add(gradereturn);
            Commit();
        }
    }
}
