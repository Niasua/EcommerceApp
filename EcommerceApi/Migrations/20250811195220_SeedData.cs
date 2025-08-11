using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Electronics", false },
                    { 2, "Clothing", false },
                    { 3, "Home", false }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "DateTime", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, new DateTime(2025, 8, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "isDeleted" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone", 500.00m, false },
                    { 2, 1, "Headphones", 50.00m, false },
                    { 3, 2, "T-Shirt", 20.00m, false },
                    { 4, 2, "Jeans", 40.00m, false },
                    { 5, 3, "Coffee Maker", 80.00m, false }
                });

            migrationBuilder.InsertData(
                table: "SaleProducts",
                columns: new[] { "ProductId", "SaleId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 500.00m },
                    { 2, 1, 2, 50.00m },
                    { 3, 2, 3, 20.00m },
                    { 5, 2, 1, 80.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SaleProducts",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SaleProducts",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SaleProducts",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SaleProducts",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

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
        }
    }
}
