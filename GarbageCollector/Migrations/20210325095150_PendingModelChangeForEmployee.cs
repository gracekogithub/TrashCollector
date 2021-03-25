using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Migrations
{
    public partial class PendingModelChangeForEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad6baba-d9fd-4deb-84ba-485b7e36d66b");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f8d4721-893c-4565-95db-039bb02140ae", "21fc9b93-77b9-4ca3-a610-1ede3cb41444", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8d4721-893c-4565-95db-039bb02140ae");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ad6baba-d9fd-4deb-84ba-485b7e36d66b", "e1de1ee1-8ce2-417d-8387-acd30ca0b7c7", "Admin", "ADMIN" });
        }
    }
}
