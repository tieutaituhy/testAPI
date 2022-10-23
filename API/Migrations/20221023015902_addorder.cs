using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppProduct",
                newName: "ProductId");

            migrationBuilder.CreateTable(
                name: "AppOrder",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 10, 23, 8, 59, 2, 623, DateTimeKind.Local).AddTicks(2603)),
                    DeliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusOrder = table.Column<int>(type: "int", nullable: false),
                    Recipient = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrder", x => x.OrderId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppDetailOrder",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    SaleOf = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDetailOrder", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_DetailOrder_Order",
                        column: x => x.OrderId,
                        principalTable: "AppOrder",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOrder_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProduct",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AppDetailOrder_ProductId",
                table: "AppDetailOrder",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDetailOrder");

            migrationBuilder.DropTable(
                name: "AppOrder");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "AppProduct",
                newName: "Id");
        }
    }
}
