using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageCollector.Migrations
{
    public partial class ChangedEmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "680039cb-ff51-4667-a92c-7f60a6ae55c0");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BillPay",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OneTimePickupDay",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RegularPickupDay",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "Charge",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmPickUpDate",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PickUpAreaZipCode",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ad6baba-d9fd-4deb-84ba-485b7e36d66b", "e1de1ee1-8ce2-417d-8387-acd30ca0b7c7", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad6baba-d9fd-4deb-84ba-485b7e36d66b");

            migrationBuilder.DropColumn(
                name: "Charge",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ConfirmPickUpDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PickUpAreaZipCode",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BillPay",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OneTimePickupDay",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegularPickupDay",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "680039cb-ff51-4667-a92c-7f60a6ae55c0", "6524d143-f2f1-4b2b-87ae-de897deb3788", "Admin", "ADMIN" });
        }
    }
}
