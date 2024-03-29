﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestCoreApi.Data;

#nullable disable

namespace TestCoreApi.Migrations
{
    [DbContext(typeof(StudentsAPIDbContext))]
    [Migration("20240321112820_AddFeesMaster")]
    partial class AddFeesMaster
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestCoreApi.Models.AdminTeacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("JoinDate")
                        .HasColumnType("date");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("AdminTeachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f66bdc0-e70f-4153-b806-5c4a344e0b47"),
                            Address = "Krishna House",
                            BirthDate = new DateOnly(2002, 1, 2),
                            City = "Rajkot",
                            District = "Rajkot",
                            Email = "admin@gmail.com",
                            Gender = "Female",
                            IsAdmin = true,
                            JoinDate = new DateOnly(2024, 2, 2),
                            MobileNumber = "9876543210",
                            Name = "admin",
                            Password = "Admin@123",
                            PinCode = "360001",
                            State = "Gujarat"
                        });
                });

            modelBuilder.Entity("TestCoreApi.Models.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("TestCoreApi.Models.Fees", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("TestCoreApi.Models.FeesMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<int>("StandardNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FeesMasters");
                });

            modelBuilder.Entity("TestCoreApi.Models.Standard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StandardNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Standards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c"),
                            Section = "A",
                            StandardNumber = 8
                        },
                        new
                        {
                            Id = new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316"),
                            Section = "B",
                            StandardNumber = 8
                        },
                        new
                        {
                            Id = new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40"),
                            Section = "A",
                            StandardNumber = 9
                        },
                        new
                        {
                            Id = new Guid("3241a142-031d-41e4-a1ba-239efc8559f7"),
                            Section = "B",
                            StandardNumber = 9
                        },
                        new
                        {
                            Id = new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386"),
                            Section = "A",
                            StandardNumber = 10
                        },
                        new
                        {
                            Id = new Guid("b880223f-458f-4e5f-a012-313119be3724"),
                            Section = "B",
                            StandardNumber = 10
                        });
                });

            modelBuilder.Entity("TestCoreApi.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("JoinDate")
                        .HasColumnType("date");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RollNo")
                        .HasColumnType("int");

                    b.Property<Guid>("StandardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StandardId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TestCoreApi.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StandardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StandardId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("TestCoreApi.Models.TimeTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("NoOfDay")
                        .HasColumnType("int");

                    b.Property<Guid>("StandardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StandardId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TimeTables");
                });

            modelBuilder.Entity("TestCoreApi.Models.AdminTeacher", b =>
                {
                    b.HasOne("TestCoreApi.Models.Subject", "Subjects")
                        .WithMany("AdminTeachers")
                        .HasForeignKey("SubjectId");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("TestCoreApi.Models.Family", b =>
                {
                    b.HasOne("TestCoreApi.Models.Student", "Students")
                        .WithMany("Families")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");
                });

            modelBuilder.Entity("TestCoreApi.Models.Fees", b =>
                {
                    b.HasOne("TestCoreApi.Models.Student", "Student")
                        .WithMany("Fees")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TestCoreApi.Models.Student", b =>
                {
                    b.HasOne("TestCoreApi.Models.Standard", "Standards")
                        .WithMany("Students")
                        .HasForeignKey("StandardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Standards");
                });

            modelBuilder.Entity("TestCoreApi.Models.Subject", b =>
                {
                    b.HasOne("TestCoreApi.Models.Standard", "Standards")
                        .WithMany("Subjects")
                        .HasForeignKey("StandardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Standards");
                });

            modelBuilder.Entity("TestCoreApi.Models.TimeTable", b =>
                {
                    b.HasOne("TestCoreApi.Models.Standard", "Standards")
                        .WithMany("TimeTables")
                        .HasForeignKey("StandardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestCoreApi.Models.Subject", "Subjects")
                        .WithMany("TimeTables")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Standards");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("TestCoreApi.Models.Standard", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");

                    b.Navigation("TimeTables");
                });

            modelBuilder.Entity("TestCoreApi.Models.Student", b =>
                {
                    b.Navigation("Families");

                    b.Navigation("Fees");
                });

            modelBuilder.Entity("TestCoreApi.Models.Subject", b =>
                {
                    b.Navigation("AdminTeachers");

                    b.Navigation("TimeTables");
                });
#pragma warning restore 612, 618
        }
    }
}
