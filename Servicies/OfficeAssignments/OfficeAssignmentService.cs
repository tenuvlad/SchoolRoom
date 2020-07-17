using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.OfficeAssignments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicies.OfficeAssignments
{
    public class OfficeAssignmentService : Repository<OfficeAssignment>, IOfficeAssignmentService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public OfficeAssignmentService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<OfficeAssignmentsDto> OfficeList()
        {
            var office = GetAll();
            var officeTeacher = _context.OfficeAssignments.Include(table => table.Teacher).ToList().Where(teacher => teacher.TeacherId == teacher.Id);
            var officeMap = _mapper.Map<IEnumerable<OfficeAssignmentsDto>>(office);
            return officeMap;
        }
        public OfficeAssignmentsDto OfficeDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var officeEntity = GetById(id);
            var teacher = _context.OfficeAssignments.Include(table => table.Teacher).ToList().Where(teacherId => teacherId.TeacherId == id);
            var officeMap = _mapper.Map<OfficeAssignmentsDto>(officeEntity);

            return officeMap;
        }

        public void AddNewOffice(OfficeAssignmentsDto office)
        {
            if (office == null) throw new ArgumentNullException(nameof(office));
            var officeMap = _mapper.Map<OfficeAssignment>(office);
            Add(officeMap);
            Commit();
        }

        public void EditOffice(OfficeAssignmentsDto office)
        {
            if (office == null) throw new ArgumentNullException(nameof(office));
            var officeEntity = new OfficeAssignment
            {
                Id = office.Id,
                Location = office.Location,
                TeacherId = office.TeacherId
            };
            Update(officeEntity);
        }

        public void DeleteOffice(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var officeEntity = GetById(id);
            var officeMap = _mapper.Map<OfficeAssignment>(officeEntity);
            Delete(officeMap);
            Commit();
        }
    }
}
