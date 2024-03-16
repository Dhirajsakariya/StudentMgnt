using Microsoft.EntityFrameworkCore;
using TestCoreApi.Models;

namespace TestCoreApi.Data
{
    public class StudentsAPIDbContext : DbContext
    {
        public StudentsAPIDbContext(DbContextOptions<StudentsAPIDbContext> options) : base(options)
        {
        }
        public DbSet<AdminTeacher> AdminTeachers { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Fees> Fees { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminTeacher>().HasData(
                new AdminTeacher() {
                    Id = new Guid ("8F66BDC0-E70F-4153-B806-5C4A344E0B47"),
                    Name = "admin",
                    Email = "admin@gmail.com",
                    Password = "Admin@123",
                    Gender = "Female",
                    BirthDate = new DateOnly(2002,01,02) ,
                    MobileNumber = "9876543210",
                    JoinDate = new DateOnly(2024,02,02),
                    Address = "Krishna House",
                    City = "Rajkot",
                    District = "Rajkot",
                    State = "Gujarat",
                    PinCode = "360001",
                    IsAdmin = true
                });
        }

    }
}
