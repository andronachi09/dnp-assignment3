﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.DataAccess;

namespace Server.Migrations
{
    [DbContext(typeof(FamilyDBContext))]
    partial class FamilyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Server.Models.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JobTitleJobID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleJobID");

                    b.ToTable("Adults");
                });

            modelBuilder.Entity("Server.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("Salary")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobID");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Server.Models.Adult", b =>
                {
                    b.HasOne("Server.Models.Job", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleJobID");

                    b.Navigation("JobTitle");
                });
#pragma warning restore 612, 618
        }
    }
}
