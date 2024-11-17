using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddPropiedadIdToArrendatario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropiedadId",
                table: "arrendatario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_arrendatario_PropiedadId",
                table: "arrendatario",
                column: "PropiedadId");

            migrationBuilder.AddForeignKey(
                name: "FK_arrendatario_propiedad_PropiedadId",
                table: "arrendatario",
                column: "PropiedadId",
                principalTable: "propiedad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_arrendatario_propiedad_PropiedadId",
                table: "arrendatario");

            migrationBuilder.DropIndex(
                name: "IX_arrendatario_PropiedadId",
                table: "arrendatario");

            migrationBuilder.DropColumn(
                name: "PropiedadId",
                table: "arrendatario");
        }
    }
}
