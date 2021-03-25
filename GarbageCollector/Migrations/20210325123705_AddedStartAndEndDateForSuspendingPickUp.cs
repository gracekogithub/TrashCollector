using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Migrations
{
    public partial class AddedStartAndEndDateForSuspendingPickUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8d4721-893c-4565-95db-039bb02140ae");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Customer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e49f0703-f329-4e1e-849d-92f9c3942fa6", "f0ba9970-807a-4994-81f5-0787347ef17a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e49f0703-f329-4e1e-849d-92f9c3942fa6");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f8d4721-893c-4565-95db-039bb02140ae", "21fc9b93-77b9-4ca3-a610-1ede3cb41444", "Admin", "ADMIN" });
        }
    }
}
