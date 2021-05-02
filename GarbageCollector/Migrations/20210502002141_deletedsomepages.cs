using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Migrations
{
    public partial class deletedsomepages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "12ef4fee-499f-491a-bb40-f0d6d237e253", "7868bc88-db98-44f6-8205-7df3f781e1c3", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7da86e7c-dcb6-4fbb-aab2-f6143a434e9c", "14d9fcaa-d3ca-4f82-9e26-a8dc5315aabc", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12ef4fee-499f-491a-bb40-f0d6d237e253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7da86e7c-dcb6-4fbb-aab2-f6143a434e9c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e4f9540-d05b-4538-860f-464c1785a948", "e39c6853-cd91-4e9e-8668-ff8b057c5089", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31d2d74a-7304-4e56-9c50-21d310ac4749", "53762280-0773-4ff8-9702-053cd328c2f7", "Employee", "EMPLOYEE" });
        }
    }
}
