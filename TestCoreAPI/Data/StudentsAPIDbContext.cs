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
            
            modelBuilder.Entity<Standard>().HasData(
                new Standard()
                {
                    Id = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C"),
                    StandardNumber = 8,
                    Section = "A",
                },
                new Standard()
                {
                    Id = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316"),
                    StandardNumber = 8,
                    Section = "B",
                },
                new Standard()
                {
                    Id = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40"),
                    StandardNumber = 9,
                    Section = "A",
                },
                new Standard()
                {
                    Id = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7"),
                    StandardNumber = 9,
                    Section = "B",
                },
                new Standard()
                {
                    Id = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386"),
                    StandardNumber = 10,
                    Section = "A",
                },
                new Standard()
                {
                    Id = new Guid("B880223F-458F-4E5F-A012-313119BE3724"),
                    StandardNumber = 10,
                    Section = "B",
                });
        }

    }
}
