using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_Usuarios_UsuarioId",
                table: "Archivos3D");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_Usuarios_UsuarioId",
                table: "Archivos3D",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_Usuarios_UsuarioId",
                table: "Archivos3D");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_Usuarios_UsuarioId",
                table: "Archivos3D",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
