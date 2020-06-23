using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegistration.Infra.Data.Migrations
{
    public partial class softDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0766d29d-da03-49ca-acd5-aaaf72de5390"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("25cf5a44-2277-4ce4-be89-3b676115a29a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9bef7c53-6e10-4bae-b415-19e78576c9a1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9e7f6965-8d8b-42e1-85f5-ab3d80956417"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("cb4600de-1117-4419-99c5-eee9f06e89c5"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[,]
                {
                    { new Guid("3f1d528b-0dee-482d-8bc1-1cbcebb90e4f"), "C#" },
                    { new Guid("da6b3203-3868-4a08-b9c7-a850e0286b5f"), "Java" },
                    { new Guid("6603c5d1-738d-441f-85d3-d4757f48607d"), "Angular" },
                    { new Guid("c0c2be94-2972-480d-beb9-4d85d141ffc4"), "SQL" },
                    { new Guid("177ebcd1-e5a7-418d-bb5c-b3b762b7cca5"), "ASP) " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("177ebcd1-e5a7-418d-bb5c-b3b762b7cca5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3f1d528b-0dee-482d-8bc1-1cbcebb90e4f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("6603c5d1-738d-441f-85d3-d4757f48607d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c0c2be94-2972-480d-beb9-4d85d141ffc4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("da6b3203-3868-4a08-b9c7-a850e0286b5f"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[,]
                {
                    { new Guid("9e7f6965-8d8b-42e1-85f5-ab3d80956417"), "C#" },
                    { new Guid("cb4600de-1117-4419-99c5-eee9f06e89c5"), "Java" },
                    { new Guid("25cf5a44-2277-4ce4-be89-3b676115a29a"), "Angular" },
                    { new Guid("9bef7c53-6e10-4bae-b415-19e78576c9a1"), "SQL" },
                    { new Guid("0766d29d-da03-49ca-acd5-aaaf72de5390"), "ASP) " }
                });
        }
    }
}
