using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Data.Migrations
{
    public partial class EditedCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "563832ad-98c5-4fc9-800d-59fed3414c58");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e04f3cf-b0d6-4a30-b48b-1e273abba64b", "ea98376d-185b-4172-a960-e76c4c139a2b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e04f3cf-b0d6-4a30-b48b-1e273abba64b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "563832ad-98c5-4fc9-800d-59fed3414c58", "75ff5147-ea9e-40fa-866a-6eedc8b64bd7", "Admin", "ADMIN" });
        }
    }
}
