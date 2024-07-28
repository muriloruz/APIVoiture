using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVoiture.Migrations
{
    public partial class PV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Enderecos_EnderecoId",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_EnderecoId",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Pagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_EnderecoId",
                table: "Pagamento",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Enderecos_EnderecoId",
                table: "Pagamento",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
