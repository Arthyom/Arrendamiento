using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class ImprovContratoProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrato_arrendador_ArrendadorId",
                table: "contrato");

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_arrendatario_ArrendadorId",
                table: "contrato",
                column: "ArrendadorId",
                principalTable: "arrendatario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrato_arrendatario_ArrendadorId",
                table: "contrato");

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_arrendador_ArrendadorId",
                table: "contrato",
                column: "ArrendadorId",
                principalTable: "arrendador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
