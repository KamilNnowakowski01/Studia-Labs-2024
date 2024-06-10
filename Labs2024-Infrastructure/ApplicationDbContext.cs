using Labs2024_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs2024_Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities
        //public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Rentals)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.IDUser)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfiguracja relacji Car-Rental (jeden do wielu)
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Rentals)
                .WithOne(r => r.Car)
                .HasForeignKey(r => r.IDCar)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasKey(c => c.ID);
            modelBuilder.Entity<Car>().HasKey(c => c.ID);
            modelBuilder.Entity<Rental>().HasKey(c => c.ID);

            // Konfiguracja relacji User-Rental (jeden do wielu)
            /*
            modelBuilder.Entity<User>()
                .HasMany(u => u.Rentals)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.IDUser)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfiguracja relacji Car-Rental (jeden do wielu)
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Rentals)
                .WithOne(r => r.Car)
                .HasForeignKey(r => r.IDCar)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasKey(c => c.ID);
            modelBuilder.Entity<Car>().HasKey(c => c.ID);
            modelBuilder.Entity<Rental>().HasKey(c => c.ID);
            */


            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    Login = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123!"),
                    FirstName = "FirstAdmin",
                    LastName = "LastAdmin",
                    Email = "admin@admin.com",
                    PhoneNumber = "123456789",
                    Role = "Admin"
                },
                new User
                {
                    ID = 2,
                    Login = "user",
                    Password = BCrypt.Net.BCrypt.HashPassword("user123!"),
                    FirstName = "FirstUser",
                    LastName = "LastUser",
                    Email = "user@user.com",
                    PhoneNumber = "123456789",
                    Role = "User"
                },
                new User
                {
                    ID = 3,
                    Login = "jkowalski",
                    Password = BCrypt.Net.BCrypt.HashPassword("password123!"),
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jan.kowalski@example.com",
                    PhoneNumber = "123456789",
                    Role = "User"
                },
                new User
                {
                    ID = 4,
                    Login = "anowak",
                    Password = BCrypt.Net.BCrypt.HashPassword("password123!"),
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Email = "anna.nowak@example.com",
                    PhoneNumber = "987654321",
                    Role = "User"
                },
                new User
                {
                    ID = 5,
                    Login = "pkowalski",
                    Password = BCrypt.Net.BCrypt.HashPassword("password123!"),
                    FirstName = "Piotr",
                    LastName = "Kowalski",
                    Email = "piotr.kowalski@example.com",
                    PhoneNumber = "654321987",
                    Role = "User"
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { ID = 1, Brand = "Toyota", Model = "Corolla", YearOfProduction = 2018, CarRegistration = "ABC123" },
                new Car { ID = 2, Brand = "Honda", Model = "Civic", YearOfProduction = 2019, CarRegistration = "DEF456" },
                new Car { ID = 3, Brand = "Ford", Model = "Focus", YearOfProduction = 2017, CarRegistration = "GHI789" },
                new Car { ID = 4, Brand = "BMW", Model = "320i", YearOfProduction = 2020, CarRegistration = "JKL012" },
                new Car { ID = 5, Brand = "Audi", Model = "A4", YearOfProduction = 2016, CarRegistration = "MNO345" },
                new Car { ID = 6, Brand = "Mercedes", Model = "C-Class", YearOfProduction = 2015, CarRegistration = "PQR678" },
                new Car { ID = 7, Brand = "Volkswagen", Model = "Golf", YearOfProduction = 2018, CarRegistration = "STU901" },
                new Car { ID = 8, Brand = "Nissan", Model = "Altima", YearOfProduction = 2021, CarRegistration = "VWX234" },
                new Car { ID = 9, Brand = "Mazda", Model = "6", YearOfProduction = 2018, CarRegistration = "YZA567" },
                new Car { ID = 10, Brand = "Hyundai", Model = "Elantra", YearOfProduction = 2019, CarRegistration = "BCD890" }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental { ID = 1, IDCar = 1, IDUser = 2, State = RentalState.Rented, DateStartRental = DateTime.Now.AddDays(-10), DateCloseRental = null },
                new Rental { ID = 2, IDCar = 2, IDUser = 3, State = RentalState.Rented, DateStartRental = DateTime.Now.AddDays(-5), DateCloseRental = null },
                new Rental { ID = 3, IDCar = 3, IDUser = 4, State = RentalState.Rented, DateStartRental = DateTime.Now.AddDays(-2), DateCloseRental = null },
                new Rental { ID = 4, IDCar = 4, IDUser = 2, State = RentalState.Returned, DateStartRental = DateTime.Now.AddDays(-15), DateCloseRental = DateTime.Now.AddDays(-5) },
                new Rental { ID = 5, IDCar = 5, IDUser = 3, State = RentalState.Returned, DateStartRental = DateTime.Now.AddDays(-20), DateCloseRental = DateTime.Now.AddDays(-10) }
            );
        }
    }
}
