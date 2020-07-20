using Data;
using Data.Entities;
using Servicies.Grades.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Grades
{
    public interface IGradeService : IRepository<Grade>
    {
        GradeDto GradeDetail(int id);
        IEnumerable<GradeDto> GradeList();
        void CreateGrade(GradeDto grade);
        void GradeEdit(GradeDto grade);
        void GradeDelete(int id);
    }
}
