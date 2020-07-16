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
            var departmentTeacher = _context.Departments.Include(table => table.Teacher).ToList().Where(teacher => teacher.TeacherId == teacher.Id);
            var departmentMap = _mapper.Map<IEnumerable<DepartmentDetailDto>>(department);

            return departmentMap;
        }

        public void CreateDepartment(DepartmentDto department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            var departmentEntity = new Department
            {
                Id = department.Id,
                Name = department.Name,
                Budget = department.Budget,
                StartDate = department.StartDate,
                TeacherId = department.TeacherId,
            };
            Add(departmentEntity);
            Commit();
        }

        public DepartmentDetailDto DepartmentDetails(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var departmentEntity = GetById(id);
            var departmentTeacher = _context.Departments.Include(table => table.Teacher).ToList().Where(teacherId => teacherId.TeacherId == id);
            var departmentMap = _mapper.Map<DepartmentDetailDto>(departmentEntity);

            return departmentMap;
        }

        public DepartmentDto DepartmentDetailForEdit(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var departmentEntity = GetById(id);
            var departmentTeacher = _context.Departments.Include(table => table.Teacher).ToList().Where(teacherId => teacherId.TeacherId == id);
            var departmentMap = _mapper.Map<DepartmentDto>(departmentEntity);

            return departmentMap;
        }

        public void EditDepartment(DepartmentDto department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            var departmentEntity = new Department
            {
                Id = department.Id,
                Name = department.Name,
                Budget = department.Budget,
                StartDate = department.StartDate,
                TeacherId = department.TeacherId
            };
            Update(departmentEntity);
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
