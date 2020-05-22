using Servicies.Grades.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Grades
{
    public interface IGradeService
    {
        List<GradeDto> GetGradeList();
        void AddNewGrade(GradeDto grade);
    }
}
