using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SchoolContext : IdentityDbContext<User, Role, int,
            IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
            IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<UserClassroomGrade> UserClassroomGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserClassroomGrade>()
                        .HasKey(z => new { z.UserId, z.ClassRoomId, z.GradeId });

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId, });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
