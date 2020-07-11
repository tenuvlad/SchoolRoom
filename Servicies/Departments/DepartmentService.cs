using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicies.Departments
{
    public class DepartmentService : Repository<Department>, IDepartmentService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentDetailDto> DepartmentList()
        {
            var department = GetAll();
            var departmentMap = _mapper.Map<IEnumerable<DepartmentDetailDto>>(department);

            return departmentMap;
        }

        public void CreateDepartment(DepartmentDto department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            var departmentMap = _mapper.Map<Department>(department);
            Add(departmentMap);
            Commit();
        }

        public DepartmentDetailDto DepartmentDetails(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var departmentEntity = GetById(id);
            var departmentMap = _mapper.Map<DepartmentDetailDto>(departmentEntity);

            return departmentMap;
        }

        public DepartmentDto DepartmentDetailForEdit(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var departmentEntity = GetById(id);
            var departmentMap = _mapper.Map<DepartmentDto>(departmentEntity);

            return departmentMap;
        }

        public void EditDepartment(DepartmentDto department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            var departmentEntity = GetById(department.Id);
            if (departmentEntity != null)
            {
                departmentEntity.Id = department.Id;
                departmentEntity.Teacher = department.Teacher;
                departmentEntity.Budget = department.Budget;
                departmentEntity.Name = department.Name;
                departmentEntity.StartDate = department.StartDate;
                departmentEntity.Courses = department.Courses;
            }
            var departmentMap = _mapper.Map<Department>(departmentEntity);
            Update(departmentMap);
        }

        public void DeleteDepartment(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var departmentEntity = GetById(id);
            var departmentMap = _mapper.Map<Department>(departmentEntity);
            Delete(departmentMap);
            Commit();
        }
    }
}
