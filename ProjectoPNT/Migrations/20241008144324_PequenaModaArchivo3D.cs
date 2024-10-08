using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class PequenaModaArchivo3D : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_Usuarios_AutorId",
                table: "Archivos3D");

            migrationBuilder.DropIndex(
                name: "IX_Archivos3D_AutorId",
                table: "Archivos3D");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Archivos3D",
                newName: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Archivos3D",
                newName: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos3D_AutorId",
                table: "Archivos3D",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_Usuarios_AutorId",
                table: "Archivos3D",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
