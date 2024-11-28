using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotekssystem_AE.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookToAuthors",
                keyColumns: new[] { "AuthorID", "BookID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 1,
                columns: new[] { "Name", "Nationality" },
                values: new object[] { "Astrid Lindgren", "Svensk" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 2,
                columns: new[] { "Name", "Nationality" },
                values: new object[] { "J.K. Rowling", "Brittisk" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1,
                columns: new[] { "ReleaseDate", "Title" },
                values: new object[] { new DateTime(1945, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pippi Långstrump" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2,
                columns: new[] { "ReleaseDate", "Title" },
                values: new object[] { new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter och de vises sten" });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 1,
                column: "ReturnDate",
                value: new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 2,
                column: "ReturnDate",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 1,
                columns: new[] { "Name", "Nationality" },
                values: new object[] { "J.K. Rowling", "British" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorID",
                keyValue: 2,
                columns: new[] { "Name", "Nationality" },
                values: new object[] { "George R.R. Martin", "American" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "Name", "Nationality" },
                values: new object[] { 3, "Agatha Christie", "British" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1,
                columns: new[] { "ReleaseDate", "Title" },
                values: new object[] { new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2,
                columns: new[] { "ReleaseDate", "Title" },
                values: new object[] { new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "ReleaseDate", "Title" },
                values: new object[] { 3, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murder on the Orient Express" });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 1,
                column: "ReturnDate",
                value: new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 2,
                column: "ReturnDate",
                value: new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "BookToAuthors",
                columns: new[] { "AuthorID", "BookID" },
                values: new object[] { 3, 3 });
        }
    }
}
