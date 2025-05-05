using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVoiture.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_ModeloCarros_ModeloCarroid",
                table: "Pecas");

            migrationBuilder.DropTable(
                name: "ModeloCarros");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_ModeloCarroid",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "ModeloCarroid",
                table: "Pecas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModeloCarroid",
                table: "Pecas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ModeloCarros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ano = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    cambio = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    carroceria = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codProdOriginal = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modelo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    produto = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valvulas = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloCarros", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_ModeloCarroid",
                table: "Pecas",
                column: "ModeloCarroid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_ModeloCarros_ModeloCarroid",
                table: "Pecas",
                column: "ModeloCarroid",
                principalTable: "ModeloCarros",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
