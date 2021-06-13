using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamedRashnoCrudTest.Data.Migrations.SqlServerMigrations
{
    public partial class InitialCreate0003232 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SmallDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                type: "SmallDateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
