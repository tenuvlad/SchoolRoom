using Data;
using Data.Entities;
using Servicies.ClassRooms.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicies.ClassRooms
{
    public class ClassRoomService : Repository<ClassRoom>, IClassRoomService
    {
        public readonly Repository<ClassRoom> _repo;
        public readonly SchoolContext _context;

        public ClassRoomService(SchoolContext context, Repository<ClassRoom> repo) : base(context)
        {
            _context = context;
            _repo = repo;
        }
    }
}
