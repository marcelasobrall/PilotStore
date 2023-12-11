using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PilotStore_.data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoProdutoMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarcaId",
                table: "Products",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marca_MarcaId",
                table: "Products",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marca_MarcaId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarcaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Products");
        }
    }
}
