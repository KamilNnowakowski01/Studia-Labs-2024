using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labs2024_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    YearOfProduction = table.Column<int>(type: "INTEGER", nullable: false),
                    CarRegistration = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDCar = table.Column<int>(type: "INTEGER", nullable: false),
                    IDUser = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    DateStartRental = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCloseRental = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_IDCar",
                        column: x => x.IDCar,
                        principalTable: "Cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "Brand", "CarRegistration", "Model", "YearOfProduction" },
                values: new object[,]
                {
                    { 1, "Toyota", "ABC123", "Corolla", 2018 },
                    { 2, "Honda", "DEF456", "Civic", 2019 },
                    { 3, "Ford", "GHI789", "Focus", 2017 },
                    { 4, "BMW", "JKL012", "320i", 2020 },
                    { 5, "Audi", "MNO345", "A4", 2016 },
                    { 6, "Mercedes", "PQR678", "C-Class", 2015 },
                    { 7, "Volkswagen", "STU901", "Golf", 2018 },
                    { 8, "Nissan", "VWX234", "Altima", 2021 },
                    { 9, "Mazda", "YZA567", "6", 2018 },
                    { 10, "Hyundai", "BCD890", "Elantra", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "Login", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", "FirstAdmin", "LastAdmin", "admin", "$2a$11$ima.L6Kctr2w4tGi3M2.7uoswVkOlzFyoJjTrGpo7WCt3TF1dEWUq", "123456789", "Admin" },
                    { 2, "user@user.com", "FirstUser", "LastUser", "user", "$2a$11$AUaROYKm2H0uMyslznd0h.f8GgHQ7OPKAMlvRxjfDG95N73yIZT4.", "123456789", "User" },
                    { 3, "jan.kowalski@example.com", "Jan", "Kowalski", "jkowalski", "$2a$11$9.azS2lWdZf99yCdyMEl4uNTny6i1Q7peuUoSuSs9lkmG.eMfwpsW", "123456789", "User" },
                    { 4, "anna.nowak@example.com", "Anna", "Nowak", "anowak", "$2a$11$i.JSvrpcEk67zyjHLb6Rh.GRQLx9F1h/WvxUp9PLX1tuoVGNei2Ci", "987654321", "User" },
                    { 5, "piotr.kowalski@example.com", "Piotr", "Kowalski", "pkowalski", "$2a$11$UlDmWA5c/KC72/jGrNP.DeN1lPFW6iW3kzBi4rYE7sq3qJbpuZEDC", "654321987", "User" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "ID", "DateCloseRental", "DateStartRental", "IDCar", "IDUser", "State" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 29, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3919), 1, 2, 0 },
                    { 2, null, new DateTime(2024, 6, 3, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3968), 2, 3, 0 },
                    { 3, null, new DateTime(2024, 6, 6, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3970), 3, 4, 0 },
                    { 4, new DateTime(2024, 6, 3, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3987), new DateTime(2024, 5, 24, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3986), 4, 2, 1 },
                    { 5, new DateTime(2024, 5, 29, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(4006), new DateTime(2024, 5, 19, 16, 36, 36, 916, DateTimeKind.Local).AddTicks(3999), 5, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IDCar",
                table: "Rentals",
                column: "IDCar");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IDUser",
                table: "Rentals",
                column: "IDUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
