using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "AppOrder",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 15, 52, 568, DateTimeKind.Local).AddTicks(9465),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 10, 23, 8, 59, 2, 623, DateTimeKind.Local).AddTicks(2603));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "AppOrder",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 8, 59, 2, 623, DateTimeKind.Local).AddTicks(2603),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 15, 52, 568, DateTimeKind.Local).AddTicks(9465));
        }
    }
}
