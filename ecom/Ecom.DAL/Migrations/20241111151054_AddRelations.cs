using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ec32390-2699-401b-ab84-3deea46fbbae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac417d10-3aa4-415b-b56b-d31f40ad9193");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34bffd55-3892-45b6-941e-c56358036695", null, "Admin", "ADMIN" },
                    { "9adc07eb-5f1a-4b9d-aa38-befecffca73d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34bffd55-3892-45b6-941e-c56358036695");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9adc07eb-5f1a-4b9d-aa38-befecffca73d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ec32390-2699-401b-ab84-3deea46fbbae", null, "Admin", "ADMIN" },
                    { "ac417d10-3aa4-415b-b56b-d31f40ad9193", null, "User", "USER" }
                });
        }
    }
}
