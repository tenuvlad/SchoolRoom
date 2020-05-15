using Data;
using Microsoft.Extensions.DependencyInjection;
using Servicies.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Servicies.ClassRooms;

namespace Servicies.Infrastructure
{
	public class DependencyMapper
	{
		public static IServiceCollection MapDependencies(IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddDbContext<SchoolContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
				.AddAutoMapper(typeof(AutoMapperProfiles).Assembly)
				.AddScoped(typeof(IRepository<>), typeof(Repository<>))
				.AddScoped<IUserService, UserService>()
				.AddScoped<IClassRoomService, ClassRoomService>();

			return services;

		}
	}
}