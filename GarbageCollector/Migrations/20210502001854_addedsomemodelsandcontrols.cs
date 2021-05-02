using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Migrations
{
    public partial class addedsomemodelsandcontrols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e1d118-e94e-43f0-9680-b2efe7df5a63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2e2d8f9-ef9b-4501-be6f-8580de0cb708");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e4f9540-d05b-4538-860f-464c1785a948", "e39c6853-cd91-4e9e-8668-ff8b057c5089", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31d2d74a-7304-4e56-9c50-21d310ac4749", "53762280-0773-4ff8-9702-053cd328c2f7", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e4f9540-d05b-4538-860f-464c1785a948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31d2d74a-7304-4e56-9c50-21d310ac4749");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2e2d8f9-ef9b-4501-be6f-8580de0cb708", "31454f77-f813-439f-ba77-86356cf6cda4", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64e1d118-e94e-43f0-9680-b2efe7df5a63", "f5275062-2b0e-4c01-aade-5dee2d65be31", "Employee", "EMPLOYEE" });
        }
    }
}
