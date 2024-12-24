using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockSchool.WebApi.Entities
{
    public class RockSchoolContext : DbContext
    {
        public RockSchoolContext(DbContextOptions<RockSchoolContext> options) : base(options)
        {
        }

        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Teacher" },
                new Role { RoleId = 3, RoleName = "Student" });
        }
    }
}
