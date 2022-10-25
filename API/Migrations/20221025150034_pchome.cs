using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class pchome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "AppOrder",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 22, 0, 34, 357, DateTimeKind.Local).AddTicks(2130),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 15, 52, 568, DateTimeKind.Local).AddTicks(9465));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "AppOrder",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 15, 52, 568, DateTimeKind.Local).AddTicks(9465),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 10, 25, 22, 0, 34, 357, DateTimeKind.Local).AddTicks(2130));
        }
    }
}
