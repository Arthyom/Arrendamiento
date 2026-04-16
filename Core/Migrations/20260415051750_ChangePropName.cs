using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrato_arrendatario_ArrendadorId",
                table: "contrato");

            migrationBuilder.DropIndex(
                name: "IX_contrato_ArrendadorId",
                table: "contrato");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_ArrendatarioId",
                table: "contrato",
                column: "ArrendatarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_arrendatario_ArrendatarioId",
                table: "contrato",
                column: "ArrendatarioId",
                principalTable: "arrendatario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrato_arrendatario_ArrendatarioId",
                table: "contrato");

            migrationBuilder.DropIndex(
                name: "IX_contrato_ArrendatarioId",
                table: "contrato");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_ArrendadorId",
                table: "contrato",
                column: "ArrendadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_arrendatario_ArrendadorId",
                table: "contrato",
                column: "ArrendadorId",
                principalTable: "arrendatario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
