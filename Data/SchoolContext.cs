using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enrollment>()
                        .HasKey(entityId => new { entityId.CourseId, entityId.StudentId });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentScore>()
                        .HasKey(entityId => new { entityId.GradeId, entityId.StudentId });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseAssignment>()
                        .HasKey(entityId => new { entityId.CourseId, entityId.TeacherId });
        }
    }
}
