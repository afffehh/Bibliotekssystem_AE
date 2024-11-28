using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bibliotekssystem_AE.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling", "British" },
                    { 2, "George R.R. Martin", "American" },
                    { 3, "Agatha Christie", "British" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { 2, new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" },
                    { 3, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murder on the Orient Express" }
                });

            migrationBuilder.InsertData(
                table: "BookToAuthors",
                columns: new[] { "AuthorID", "BookID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "BookID", "LoanDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookToAuthors",
                keyColumns: new[] { "AuthorID", "BookID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BookToAuthors",
                keyColumns: new[] { "AuthorID", "BookID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookToAuthors",
                keyColumns: new[] { "AuthorID", "BookID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 3);
        }
    }
}
