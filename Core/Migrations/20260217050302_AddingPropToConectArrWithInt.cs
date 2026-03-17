using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingPropToConectArrWithInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArrendatarioId",
                table: "interior",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_interior_ArrendatarioId",
                table: "interior",
                column: "ArrendatarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_interior_arrendatario_ArrendatarioId",
                table: "interior",
                column: "ArrendatarioId",
                principalTable: "arrendatario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_arrendatario_ArrendatarioId",
                table: "interior");

            migrationBuilder.DropIndex(
                name: "IX_interior_ArrendatarioId",
                table: "interior");

            migrationBuilder.DropColumn(
                name: "ArrendatarioId",
                table: "interior");
        }
    }
}
