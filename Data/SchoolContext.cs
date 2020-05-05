using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class SchoolContext :  DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<UserClassroomSubjectGrade> UserClassroomSubjectGrades { get; set; }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolApp;Integrated Security=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClassroomSubjectGrade>()
                        .HasKey(z => new { z.UserId, z.ClassRoomId, z.SubjectId, z.GradeId });
        }
    }
}
