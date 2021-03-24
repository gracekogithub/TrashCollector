using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Data.Migrations
{
    public partial class AddedRoleInApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e04f3cf-b0d6-4a30-b48b-1e273abba64b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b5ea0c1-3b8b-48db-8570-4cc5e1beb10b", "7b5aeefe-7343-4d6f-8771-45b066df06ce", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b5ea0c1-3b8b-48db-8570-4cc5e1beb10b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e04f3cf-b0d6-4a30-b48b-1e273abba64b", "ea98376d-185b-4172-a960-e76c4c139a2b", "Admin", "ADMIN" });
        }
    }
}
