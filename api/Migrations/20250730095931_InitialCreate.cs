using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cb196bd-d834-47be-a646-e62110b93bfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d235cd4-8a18-4c59-ad31-c71d5da70711");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42cb12e6-2add-4061-a185-1a1f090e996e", null, "Admin", "ADMIN" },
                    { "aabfb326-067a-4a73-87cd-efa4f21b9bdb", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42cb12e6-2add-4061-a185-1a1f090e996e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aabfb326-067a-4a73-87cd-efa4f21b9bdb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cb196bd-d834-47be-a646-e62110b93bfb", null, "Manager", "MANAGER" },
                    { "5d235cd4-8a18-4c59-ad31-c71d5da70711", null, "Admin", "ADMIN" }
                });
        }
    }
}
