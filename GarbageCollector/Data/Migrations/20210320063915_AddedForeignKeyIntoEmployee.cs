using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Data.Migrations
{
    public partial class AddedForeignKeyIntoEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b65e50de-7930-4aa0-87cc-c8646b4c94ef");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Employee",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94a42c00-366a-4844-9e8d-dd35f504ce46", "9c583028-227f-4e8d-8760-91c5835f5b79", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a42c00-366a-4844-9e8d-dd35f504ce46");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Employee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b65e50de-7930-4aa0-87cc-c8646b4c94ef", "15ae4051-c231-4da4-a910-f97a78930a1d", "Admin", "ADMIN" });
        }
    }
}
