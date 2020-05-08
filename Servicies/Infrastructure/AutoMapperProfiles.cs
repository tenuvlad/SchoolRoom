using AutoMapper;
using Data.Entities;
using Servicies.Users.Dto;

namespace Servicies.Infrastructure
{
    public  class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailed>();
            CreateMap<User, UserForList>();
            CreateMap<User, UserForUpdate>();

        }
    }
}
