using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class onetomanyUsuariosArchivos3d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Archivos3D_UsuarioId",
                table: "Archivos3D",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_Usuarios_UsuarioId",
                table: "Archivos3D",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_Usuarios_UsuarioId",
                table: "Archivos3D");

            migrationBuilder.DropIndex(
                name: "IX_Archivos3D_UsuarioId",
                table: "Archivos3D");
        }
    }
}
