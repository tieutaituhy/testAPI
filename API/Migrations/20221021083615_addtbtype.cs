using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addtbtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "AppProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppTypeProduct",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTypeProduct", x => x.TypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AppProduct_TypeId",
                table: "AppProduct",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppProduct_AppTypeProduct_TypeId",
                table: "AppProduct",
                column: "TypeId",
                principalTable: "AppTypeProduct",
                principalColumn: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppProduct_AppTypeProduct_TypeId",
                table: "AppProduct");

            migrationBuilder.DropTable(
                name: "AppTypeProduct");

            migrationBuilder.DropIndex(
                name: "IX_AppProduct_TypeId",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "AppProduct");
        }
    }
}
