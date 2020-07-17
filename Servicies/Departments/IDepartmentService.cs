using Data;
using Data.Entities;
using Servicies.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Departments
{
    public interface IDepartmentService: IRepository<Department>
    {
        IEnumerable<DepartmentDetailDto> DepartmentList();
        void CreateDepartment(DepartmentDto department);
        DepartmentDetailDto DepartmentDetails(int id);
        DepartmentDto DepartmentDetailForEdit(int id);
        void EditDepartment(DepartmentDto department);
        void DeleteDepartment(int id);
        bool DepartmentNameExist(string name);

    }
}
