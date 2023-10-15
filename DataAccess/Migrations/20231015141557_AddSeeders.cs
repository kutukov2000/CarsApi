using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A passenger car with a closed body and two rows of seats.", "Sedan" },
                    { 2, "A large motor vehicle used for transporting goods.", "Truck" },
                    { 3, "A rugged automotive vehicle similar to a station wagon but built on a light-truck chassis.", "SUV" },
                    { 4, "A low-built car designed for performance at high speeds.", "Sports Car" },
                    { 5, "A small car with a rear door that opens upwards.", "Hatchback" },
                    { 6, "A car with a roof that can be folded back.", "Convertible" },
                    { 7, "A small van, typically one used for transporting passengers.", "Minivan" },
                    { 8, "A two-door car with a fixed roof.", "Coupe" },
                    { 9, "A vehicle that combines the features of an SUV with those of a passenger car.", "Crossover" },
                    { 10, "A car that runs on electricity stored in batteries.", "Electric" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Model", "Producer", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Camry", "Toyota", 2022 },
                    { 2, 2, "F-150", "Ford", 2021 },
                    { 3, 1, "Malibu", "Chevrolet", 2023 },
                    { 4, 5, "Civic", "Honda", 2022 },
                    { 5, 3, "X5", "BMW", 2022 },
                    { 6, 2, "A4", "Audi", 2023 },
                    { 7, 4, "E-Class", "Mercedes-Benz", 2021 },
                    { 8, 1, "Altima", "Nissan", 2022 },
                    { 9, 10, "Model 3", "Tesla", 2023 },
                    { 10, 5, "Golf", "Volkswagen", 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
