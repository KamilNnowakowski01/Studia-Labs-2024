﻿// <auto-generated />
using System;
using Labs2024_Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labs2024_Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240608143637_initDB")]
    partial class initDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Labs2024_Domain.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CarRegistration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearOfProduction")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Brand = "Toyota",
                            CarRegistration = "ABC123",
                            Model = "Corolla",
                            YearOfProduction = 2018
                        },
                        new
                        {
                            ID = 2,
                            Brand = "Honda",
                            CarRegistration = "DEF456",
                            Model = "Civic",
                            YearOfProduction = 2019
                        },
                        new
                        {
                            ID = 3,
                            Brand = "Ford",
                            CarRegistration = "GHI789",
                            Model = "Focus",
                            YearOfProduction = 2017
                        },
                        new
                        {
                            ID = 4,
                            Brand = "BMW",
                            CarRegistration = "JKL012",
                            Model = "320i",
                            YearOfProduction = 2020
                        },
                        new
                        {
                            ID = 5,
                            Brand = "Audi",
                            CarRegistration = "MNO345",
                            Model = "A4",
                            YearOfProduction = 2016
                        },
                        new
                        {
                            ID = 6,
                            Brand = "Mercedes",
                            CarRegistration = "PQR678",
                            Model = "C-Class",
                            YearOfProduction = 2015
                        },
                        new
                        {
                            ID = 7,
                            Brand = "Volkswagen",
                            CarRegistration = "STU901",
                            Model = "Golf",
                            YearOfProduction = 2018
                        },
                        new
                        {
                            ID = 8,
                            Brand = "Nissan",
                            CarRegistration = "VWX234",
                            Model = "Altima",
                            YearOfProduction = 2021
                        },
                        new
                        {
                            ID = 9,
                            Brand = "Mazda",
                            CarRegistration = "YZA567",
                            Model = "6",
                            YearOfProduction = 2018
                        },
                        new
                        {
                            ID = 10,
                            Brand = "Hyundai",
                            CarRegistration = "BCD890",
                            Model = "Elantra",
                            YearOfProduction = 2019
                        });
                });

            modelBuilder.Entity("Labs2024_Domain.Models.Rental", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateCloseRental")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateStartRental")
                        .HasColumnType("TEXT");

                    b.Property<int>("IDCar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IDUser")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("IDCar");

                    b.HasIndex("IDUser");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateStartRental = new DateTime(2024, 5, 29, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3919),
                            IDCar = 1,
                            IDUser = 2,
                            State = 0
                        },
                        new
                        {
                            ID = 2,
                            DateStartRental = new DateTime(2024, 6, 3, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3968),
                            IDCar = 2,
                            IDUser = 3,
                            State = 0
                        },
                        new
                        {
                            ID = 3,
                            DateStartRental = new DateTime(2024, 6, 6, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3970),
                            IDCar = 3,
                            IDUser = 4,
                            State = 0
                        },
                        new
                        {
                            ID = 4,
                            DateCloseRental = new DateTime(2024, 6, 3, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3987),
                            DateStartRental = new DateTime(2024, 5, 24, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3986),
                            IDCar = 4,
                            IDUser = 2,
                            State = 1
                        },
                        new
                        {
                            ID = 5,
                            DateCloseRental = new DateTime(2024, 5, 29, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(4006),
                            DateStartRental = new DateTime(2024, 5, 19, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3999),
                            IDCar = 5,
                            IDUser = 3,
                            State = 1
                        });
                });

            modelBuilder.Entity("Labs2024_Domain.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "admin@admin.com",
                            FirstName = "FirstAdmin",
                            LastName = "LastAdmin",
                            Login = "admin",
                            Password = "$2a$11$ima.L6Kctr2w4tGi3M2.7uoswVkOlzFyoJjTrGpo7WCt3TF1dEWUq",
                            PhoneNumber = "123456789",
                            Role = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            Email = "user@user.com",
                            FirstName = "FirstUser",
                            LastName = "LastUser",
                            Login = "user",
                            Password = "$2a$11$AUaROYKm2H0uMyslznd0h.f8GgHQ7OPKAMlvRxjfDG95N73yIZT4.",
                            PhoneNumber = "123456789",
                            Role = "User"
                        },
                        new
                        {
                            ID = 3,
                            Email = "jan.kowalski@example.com",
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Login = "jkowalski",
                            Password = "$2a$11$9.azS2lWdZf99yCdyMEl4uNTny6i1Q7peuUoSuSs9lkmG.eMfwpsW",
                            PhoneNumber = "123456789",
                            Role = "User"
                        },
                        new
                        {
                            ID = 4,
                            Email = "anna.nowak@example.com",
                            FirstName = "Anna",
                            LastName = "Nowak",
                            Login = "anowak",
                            Password = "$2a$11$i.JSvrpcEk67zyjHLb6Rh.GRQLx9F1h/WvxUp9PLX1tuoVGNei2Ci",
                            PhoneNumber = "987654321",
                            Role = "User"
                        },
                        new
                        {
                            ID = 5,
                            Email = "piotr.kowalski@example.com",
                            FirstName = "Piotr",
                            LastName = "Kowalski",
                            Login = "pkowalski",
                            Password = "$2a$11$UlDmWA5c/KC72/jGrNP.DeN1lPFW6iW3kzBi4rYE7sq3qJbpuZEDC",
                            PhoneNumber = "654321987",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("Labs2024_Domain.Models.Rental", b =>
                {
                    b.HasOne("Labs2024_Domain.Models.Car", "Car")
                        .WithMany("Rentals")
                        .HasForeignKey("IDCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labs2024_Domain.Models.User", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("IDUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Labs2024_Domain.Models.Car", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("Labs2024_Domain.Models.User", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
