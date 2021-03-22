using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Data.Migrations
{
    public partial class AddedEmployeeRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a42c00-366a-4844-9e8d-dd35f504ce46");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99a2d52a-b969-43e3-9615-47b834032fc4", "42e766b5-852b-46f8-8d23-dd0b697a3d6c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99a2d52a-b969-43e3-9615-47b834032fc4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94a42c00-366a-4844-9e8d-dd35f504ce46", "9c583028-227f-4e8d-8760-91c5835f5b79", "Admin", "ADMIN" });
        }
    }
}
