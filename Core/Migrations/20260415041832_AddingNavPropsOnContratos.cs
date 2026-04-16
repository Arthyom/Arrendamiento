using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingNavPropsOnContratos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_contrato_ArrendadorId",
                table: "contrato",
                column: "ArrendadorId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_FiadorId",
                table: "contrato",
                column: "FiadorId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_InteriorId",
                table: "contrato",
                column: "InteriorId");

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_arrendador_ArrendadorId",
                table: "contrato",
                column: "ArrendadorId",
                principalTable: "arrendador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_fiador_FiadorId",
                table: "contrato",
                column: "FiadorId",
                principalTable: "fiador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_interior_InteriorId",
                table: "contrato",
                column: "InteriorId",
                principalTable: "interior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrato_arrendador_ArrendadorId",
                table: "contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_contrato_fiador_FiadorId",
                table: "contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_contrato_interior_InteriorId",
                table: "contrato");

            migrationBuilder.DropIndex(
                name: "IX_contrato_ArrendadorId",
                table: "contrato");

            migrationBuilder.DropIndex(
                name: "IX_contrato_FiadorId",
                table: "contrato");

            migrationBuilder.DropIndex(
                name: "IX_contrato_InteriorId",
                table: "contrato");
        }
    }
}
