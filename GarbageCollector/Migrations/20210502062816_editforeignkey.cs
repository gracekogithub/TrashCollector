using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Migrations
{
    public partial class editforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17200893-04f8-4ef3-9ca7-fcded6b9f612");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77888e00-b2c3-4bde-b560-586a3fd52318");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe47d39d-9f9a-4076-bb3b-2868ce304950", "e895fd18-66a9-4041-9682-474c7c62d832", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfd74602-2935-4ce1-9d9f-77271c5180fc", "09d4530c-f27f-4110-9dd7-3029413efb86", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfd74602-2935-4ce1-9d9f-77271c5180fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe47d39d-9f9a-4076-bb3b-2868ce304950");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17200893-04f8-4ef3-9ca7-fcded6b9f612", "2631e359-b06b-4232-ae7b-5add01f36320", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77888e00-b2c3-4bde-b560-586a3fd52318", "e9362a6a-d0b1-43a5-8894-3ed6ed9df27a", "Employee", "EMPLOYEE" });
        }
    }
}
