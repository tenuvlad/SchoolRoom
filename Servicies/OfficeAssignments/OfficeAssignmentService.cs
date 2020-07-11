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

        public OfficeAssignmentsDto OfficeDetail(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var officeId = GetById(id);
            var officeTable = _context.OfficeAssignments.Include(table => table.Teacher).ThenInclude(person => person.FullName).Where(person => person.Id == id);
            var officeMap = _mapper.Map<OfficeAssignmentsDto>(officeId);

            return officeMap;
        }

        public void AddNewOffice(OfficeAssignmentsDto office)
        {
            if (office == null) throw new ArgumentNullException(nameof(office));
            var officeTable = _context.OfficeAssignments.Include(table => table.Teacher).ThenInclude(person => person.FullName);
            var officeMap = _mapper.Map<OfficeAssignment>(office);
            Add(officeMap);
            Commit();
        }

        public void EditOffice(OfficeAssignmentsDto office)
        {
            if (office == null) throw new ArgumentNullException(nameof(office));
            var officeId = GetById(office.Id);
            if (officeId != null)
            {
                officeId.Id = office.Id;
                officeId.Location = office.Location;
                officeId.TeacherId = office.InstructorId;
            }
            var officeMap = _mapper.Map<OfficeAssignment>(officeId);
            Update(officeMap);
        }

        public void DeleteOffice(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var officeId = GetById(id);
            var officeMap = _mapper.Map<OfficeAssignment>(officeId);
            Delete(officeMap);
            Commit();
        }
    }
}
