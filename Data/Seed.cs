using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Entities;
using Newtonsoft.Json;

namespace Data
{
	public class Seed
	{
		public static void SeedUsers(SchoolContext context)
		{
			if (!context.Users.Any())
			{
				var userData = System.IO.File.ReadAllText(@"C:\Users\tenug\source\repos\ConsoleTestProject\Connsole\Seeder\user.json");
				var users = JsonConvert.DeserializeObject<List<User>>(userData);

				foreach (var user in users)
				{
					byte[] passwordHash, passwordSalt;
					CreatePasswordHash("password", out passwordHash, out passwordSalt);

					user.PasswordHash = passwordHash;
					user.PasswordSalt = passwordSalt;
					user.UserName = user.UserName.ToLower();
					context.Users.Add(user);
				}
				context.SaveChanges();
			}
		}

		private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			};
		}

		public static void SeedSubject(SchoolContext context)
		{
			if (!context.Subjects.Any())
			{
				var subjectData = System.IO.File.ReadAllText(@"C:\Users\tenug\source\repos\ConsoleTestProject\Connsole\Seeder\subject.json");
				var subjects = JsonConvert.DeserializeObject<List<Subject>>(subjectData);

				foreach (var subject in subjects)
				{
					context.Subjects.Add(subject);
				}
				context.SaveChanges();
			}

		}
		public static void SeedClassRoom(SchoolContext context)
		{
			if (!context.ClassRooms.Any())
			{
				var classRoomData = System.IO.File.ReadAllText(@"C:\Users\tenug\source\repos\ConsoleTestProject\Connsole\Seeder\classRoom.json");
				var classRooms = JsonConvert.DeserializeObject<List<ClassRoom>>(classRoomData);

				foreach (var classRoom in classRooms)
				{
					context.ClassRooms.Add(classRoom);
				}
				context.SaveChanges();
			}

		}
		public static void SeedUserClassSubject(SchoolContext context)
		{
			if (!context.UserClassroomSubjectGrades.Any())
			{
				var userClassSubjectData = System.IO.File.ReadAllText(@"C:\Users\tenug\source\repos\ConsoleTestProject\Connsole\Seeder\userclasssubject.json");
				var userClassSubjects = JsonConvert.DeserializeObject<List<UserClassroomSubjectGrade>>(userClassSubjectData);

				foreach (var userClassSubject in userClassSubjects)
				{
					context.UserClassroomSubjectGrades.Add(userClassSubject);
				}
				context.SaveChanges();
			}

		}
		public static void SeedGrade(SchoolContext context)
		{
			if (!context.Grades.Any())
			{
				var gradeData = System.IO.File.ReadAllText(@"C:\Users\tenug\source\repos\ConsoleTestProject\Connsole\Seeder\grade.json");
				var userGrades = JsonConvert.DeserializeObject<List<Grade>>(gradeData);

				foreach (var userGrade in userGrades)
				{
					context.Grades.Add(userGrade);
				}
				context.SaveChanges();
			}

		}
	}
}