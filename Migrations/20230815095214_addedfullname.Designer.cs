﻿// <auto-generated />
using EmailWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmailWebApplication.Migrations
{
    [DbContext(typeof(FormDbContext))]
    [Migration("20230815095214_addedfullname")]
    partial class addedfullname
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("EmailWebApplication.Models.EmailForm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("EmailForms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "darexolu16@gmail.com",
                            FullName = "Olushola Damilare",
                            Gender = "Male",
                            ImageUrl = "",
                            Password = "1234"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}