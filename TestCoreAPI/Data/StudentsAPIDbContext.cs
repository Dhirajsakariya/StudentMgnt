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
        public DbSet<FeesMaster> FeesMasters { get; set; }


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

                modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    Id = new Guid("EF966DD1-8455-430C-9A7D-134B564F29AB"),
                    Name = "English",
                    StandardId = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C")
                },
                new Subject()
                {
                    Id = new Guid("8C2C6493-7967-450C-AA4B-1E1B08470DCA"),
                    Name = "Gujarati",
                    StandardId = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C")
                },
                new Subject()
                {
                    Id = new Guid("9E3ACA2B-D4EB-43A7-8B97-2530A8CB029D"),
                    Name = "Maths",
                    StandardId = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C")
                },
                new Subject()
                {
                    Id = new Guid("7C16A113-F763-4924-B53D-2DD61658FC3E"),
                    Name = "Science",
                    StandardId = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C")
                },
                new Subject()
                {
                    Id = new Guid("64D5193E-2C83-4074-88BA-4E6DAE087E34"),
                    Name = "Social Science",
                    StandardId = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C")
                },
                new Subject()
                {
                    Id = new Guid("32F85EC7-69AD-4A09-9975-5E38D213AA45"),
                    Name = "Hindi",
                    StandardId = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C")
                },
                new Subject()
                {
                    Id = new Guid("A2B2A0F2-A8C5-4D5B-B805-71A2555804D2"),
                    Name = "Computer",
                    StandardId = new Guid("A8283465-6AE7-43D6-8ECA-09C02AB12B4C")
                },

                new Subject()
                {
                    Id = new Guid("4A543C11-2528-47D9-B6B9-87D6715662F8"),
                    Name = "English",
                    StandardId = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316")
                },
                new Subject()
                {
                    Id = new Guid("08965A20-5133-4973-8ABE-880EE4C9D459"),
                    Name = "Gujarati",
                    StandardId = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316")
                },
                new Subject()
                {
                    Id = new Guid("15565504-CC67-4A0C-95DC-9BA7487F5DA7"),
                    Name = "Maths",
                    StandardId = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316")
                },
                new Subject()
                {
                    Id = new Guid("81DD90F9-CA23-4CB6-B033-A719E162ACBD"),
                    Name = "Science",
                    StandardId = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316")
                },
                new Subject()
                {
                    Id = new Guid("6E5EAF49-2569-47C0-93B3-C6F2710F496D"),
                    Name = "Social Science",
                    StandardId = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316")
                },
                new Subject()
                {
                    Id = new Guid("0C1B106E-5CEE-4669-B8FC-FE82FA8D8AF8"),
                    Name = "Computer",
                    StandardId = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316")
                },
                new Subject()
                {
                    Id = new Guid("34BAA2CC-27AE-450A-A68A-879B93A4A19B"),
                    Name = "Sanskrit",
                    StandardId = new Guid("F82BA9D1-5D85-4C20-BCA0-142DD07E1316")
                },


                new Subject()
                {
                    Id = new Guid("A66ECDBA-36C5-4501-9737-0D40CDAA264E"),
                    Name = "English",
                    StandardId = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40")
                },
                new Subject()
                {
                    Id = new Guid("0416E0EA-3C21-4EC8-95D4-3FB5750409C8"),
                    Name = "Gujarati",
                    StandardId = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40")
                },
                new Subject()
                {
                    Id = new Guid("2A3D67CA-41A5-4878-8163-5A55F82242CE"),
                    Name = "Maths",
                    StandardId = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40")
                },
                new Subject()
                {
                    Id = new Guid("48E34651-25A6-4990-A4A6-BEF546ABC646"),
                    Name = "Science",
                    StandardId = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40")
                },
                new Subject()
                {
                    Id = new Guid("C2F93EE2-E912-4B03-8336-7CA346BCC83B"),
                    Name = "Social Science",
                    StandardId = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40")
                },
                new Subject()
                {
                    Id = new Guid("8F66BDC0-E70F-4153-B806-5C4A344E0B47"),
                    Name = "Hindi",
                    StandardId = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40")
                },
                new Subject()
                {
                    Id = new Guid("25418D7C-0BC0-44FA-AF90-716BBFDA4FD3"),
                    Name = "Computer",
                    StandardId = new Guid("49716B8A-ACA6-4CE9-9A74-199CE2A5AF40")
                },

                new Subject()
                {
                    Id = new Guid("8EDE72B7-0489-4767-8527-87DA60A15AE2"),
                    Name = "English",
                    StandardId = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7")
                },
                new Subject()
                {
                    Id = new Guid("932978E9-6EBE-46F0-8440-BBC08D4419F4"),
                    Name = "Gujarati",
                    StandardId = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7")
                },
                new Subject()
                {
                    Id = new Guid("5A41DEFE-5DB1-40BC-985A-94E5E6FB716A"),
                    Name = "Maths",
                    StandardId = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7")
                },
                new Subject()
                {
                    Id = new Guid("032082CD-95AA-4827-9FA7-9F6B5F6E27FE"),
                    Name = "Science",
                    StandardId = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7")
                },
                new Subject()
                {
                    Id = new Guid("20BE64C7-EC87-4F8F-9589-B01D648872AA"),
                    Name = "Social Science",
                    StandardId = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7")
                },
                new Subject()
                {
                    Id = new Guid("4C3B9F1E-C539-472D-B84F-FD99B7FBBA19"),
                    Name = "Computer",
                    StandardId = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7")
                },
                new Subject()
                {
                    Id = new Guid("E9B68C31-2AC3-4B12-84D8-031FE146B10A"),
                    Name = "Sanskrit",
                    StandardId = new Guid("3241A142-031D-41E4-A1BA-239EFC8559F7")
                },


                new Subject()
                {
                    Id = new Guid("C345EA33-CEEF-4362-89A2-EC572495A5F1"),
                    Name = "English",
                    StandardId = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386")
                },
                new Subject()
                {
                    Id = new Guid("45CAF56F-3A19-4FFD-B440-58EFE9636348"),
                    Name = "Gujarati",
                    StandardId = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386")
                },
                new Subject()
                {
                    Id = new Guid("ECA06498-6177-4403-A63C-08DC40022339"),
                    Name = "Maths",
                    StandardId = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386")
                },
                new Subject()
                {
                    Id = new Guid("CF6E4282-70C0-46D4-A37C-215C0DABAF2D"),
                    Name = "Science",
                    StandardId = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386")
                },
                new Subject()
                {
                    Id = new Guid("2A0D243D-C7E6-4212-BED6-46A0688995A3"),
                    Name = "Social Science",
                    StandardId = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386")
                },
                new Subject()
                {
                    Id = new Guid("FDCA3B5E-EBF5-4A21-8652-8853E5374B52"),
                    Name = "Hindi",
                    StandardId = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386")
                },
                new Subject()
                {
                    Id = new Guid("86FAB670-B1D9-4060-92F5-ABF844E7722E"),
                    Name = "Computer",
                    StandardId = new Guid("1ECC5761-7DDB-4EF7-8B16-28C91845A386")
                },

                new Subject()
                {
                    Id = new Guid("BC5C3E5B-7D3D-46FA-9EBC-F98B3B63DFCC"),
                    Name = "English",
                    StandardId = new Guid("B880223F-458F-4E5F-A012-313119BE3724")
                },
                new Subject()
                {
                    Id = new Guid("1C932EF0-6E4E-4745-9887-B73148594B40"),
                    Name = "Gujarati",
                    StandardId = new Guid("B880223F-458F-4E5F-A012-313119BE3724")
                },
                new Subject()
                {
                    Id = new Guid("26B69DBF-AF43-43EE-977F-2D083F905767"),
                    Name = "Maths",
                    StandardId = new Guid("B880223F-458F-4E5F-A012-313119BE3724")
                },
                new Subject()
                {
                    Id = new Guid("85D4C5ED-951E-4071-804A-3F18936CE1AE"),
                    Name = "Science",
                    StandardId = new Guid("B880223F-458F-4E5F-A012-313119BE3724")
                },
                new Subject()
                {
                    Id = new Guid("6E64FC17-847C-40CB-CFC0-08DC3DCF00A7"),
                    Name = "Social Science",
                    StandardId = new Guid("B880223F-458F-4E5F-A012-313119BE3724")
                },
                new Subject()
                {
                    Id = new Guid("3D2B8EB5-DB35-4E5E-A834-A48CFDFBDEF9"),
                    Name = "Computer",
                    StandardId = new Guid("B880223F-458F-4E5F-A012-313119BE3724")
                },
                new Subject()
                {
                    Id = new Guid("111A84AA-BF19-4CB5-970B-87FB6D69DE6B"),
                    Name = "Sanskrit",
                    StandardId = new Guid("B880223F-458F-4E5F-A012-313119BE3724")
                });
        }

    }
}
