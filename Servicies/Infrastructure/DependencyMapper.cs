using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servicies.Courses;
using Servicies.Departments;
using Servicies.OfficeAssignments;
using Servicies.Students;
using Servicies.Teachers;

namespace Servicies.Infrastructure
{
    public static class DependencyMapper
	{
		public static IServiceCollection MapDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddDbContext<SchoolContext>(options => options
				.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
				.AddAutoMapper(typeof(AutoMapperProfiles).Assembly)
				.AddScoped(typeof(IRepository<>), typeof(Repository<>))
				.AddScoped<ICourseService, CourseService>()
				.AddScoped<IDepartmentService, DepartmentService>()
				.AddScoped<IOfficeAssignmentService, OfficeAssignmentService>()
				.AddScoped<ITeacherService, TeacherService>()
				.AddScoped<IStudentService, StudentService>();

			return services;

		}
	}
}
