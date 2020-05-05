using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Connsole
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceProvider serviceProvider = new ServiceCollection()
				.AddDbContext<SchoolContext>()
				.BuildServiceProvider();

			using (var scope = serviceProvider.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<SchoolContext>();
				context.Database.Migrate();
				Seed.SeedUsers(context);
				Seed.SeedSubject(context);
				Seed.SeedClassRoom(context);
				Seed.SeedGrade(context);
				Seed.SeedUserClassSubject(context);
			}

			Console.WriteLine("Data has be seeded.");
		}
	}
}
