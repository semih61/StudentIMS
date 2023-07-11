﻿// <auto-generated />
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Depart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Depart = "Business Administration"
                        },
                        new
                        {
                            Id = 2,
                            Depart = "Computer Science"
                        },
                        new
                        {
                            Id = 3,
                            Depart = "Management Information Systems"
                        },
                        new
                        {
                            Id = 4,
                            Depart = "Economics"
                        });
                });

            modelBuilder.Entity("Models.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 20,
                            DepartmentId = 1,
                            Name = "John",
                            StudentNumber = 123456,
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            Age = 21,
                            DepartmentId = 1,
                            Name = "Jane",
                            StudentNumber = 654321,
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            Age = 22,
                            DepartmentId = 1,
                            Name = "John",
                            StudentNumber = 123654,
                            Surname = "Smith"
                        },
                        new
                        {
                            Id = 4,
                            Age = 23,
                            DepartmentId = 1,
                            Name = "Jane",
                            StudentNumber = 321654,
                            Surname = "Smith"
                        });
                });

            modelBuilder.Entity("Models.Models.Student", b =>
                {
                    b.HasOne("Models.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
