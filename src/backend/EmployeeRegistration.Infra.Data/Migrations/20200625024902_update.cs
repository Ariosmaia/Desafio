using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegistration.Infra.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("177ebcd1-e5a7-418d-bb5c-b3b762b7cca5"),
                column: "SkillName",
                value: "ASP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("177ebcd1-e5a7-418d-bb5c-b3b762b7cca5"),
                column: "SkillName",
                value: "ASP) ");
        }
    }
}
