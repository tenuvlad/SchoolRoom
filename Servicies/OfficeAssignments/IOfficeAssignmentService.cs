using Data;
using Data.Entities;
using Servicies.OfficeAssignments.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.OfficeAssignments
{
    public interface IOfficeAssignmentService : IRepository<OfficeAssignment>
    {
        IEnumerable<OfficeAssignmentsDto> OfficeList();
        OfficeAssignmentsDto OfficeDetail(int id);
        void AddNewOffice(OfficeAssignmentsDto office);
        void EditOffice(OfficeAssignmentsDto office);
        void DeleteOffice(int id);
    }
}
