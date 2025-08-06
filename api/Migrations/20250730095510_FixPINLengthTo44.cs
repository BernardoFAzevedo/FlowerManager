using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixPINLengthTo44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a97a57a-277f-4bef-b7d1-ba4ae664fcf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca31c24c-d7f9-48ce-abb5-2a3a8cf2ab27");

            migrationBuilder.AlterColumn<string>(
                name: "PIN",
                table: "AspNetUsers",
                type: "nvarchar(44)",
                maxLength: 44,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cb196bd-d834-47be-a646-e62110b93bfb", null, "Manager", "MANAGER" },
                    { "5d235cd4-8a18-4c59-ad31-c71d5da70711", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cb196bd-d834-47be-a646-e62110b93bfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d235cd4-8a18-4c59-ad31-c71d5da70711");

            migrationBuilder.AlterColumn<string>(
                name: "PIN",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(44)",
                oldMaxLength: 44);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a97a57a-277f-4bef-b7d1-ba4ae664fcf8", null, "Manager", "MANAGER" },
                    { "ca31c24c-d7f9-48ce-abb5-2a3a8cf2ab27", null, "Admin", "ADMIN" }
                });
        }
    }
}
