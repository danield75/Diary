﻿// <auto-generated />
using System;
using DiaryApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiaryApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.7.24405.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiaryApp.Models.DiaryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiaryEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Went hiking with Joe!",
                            Created = new DateTime(2024, 8, 28, 11, 21, 55, 242, DateTimeKind.Local).AddTicks(1439),
                            Title = "Went hiking"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Went shopping with Joe!",
                            Created = new DateTime(2024, 8, 28, 11, 21, 55, 242, DateTimeKind.Local).AddTicks(1843),
                            Title = "Went shopping"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Went diving with Joe!",
                            Created = new DateTime(2024, 8, 28, 11, 21, 55, 242, DateTimeKind.Local).AddTicks(1848),
                            Title = "Went diving"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
