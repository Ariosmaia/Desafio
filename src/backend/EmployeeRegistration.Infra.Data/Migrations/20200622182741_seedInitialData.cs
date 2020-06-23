using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegistration.Infra.Data.Migrations
{
    public partial class seedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[,]
                {
                    { new Guid("9e7f6965-8d8b-42e1-85f5-ab3d80956417"), "C#" },
                    { new Guid("cb4600de-1117-4419-99c5-eee9f06e89c5"), "Java" },
                    { new Guid("25cf5a44-2277-4ce4-be89-3b676115a29a"), "Angular" },
                    { new Guid("9bef7c53-6e10-4bae-b415-19e78576c9a1"), "SQL" },
                    { new Guid("0766d29d-da03-49ca-acd5-aaaf72de5390"), "ASP " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
