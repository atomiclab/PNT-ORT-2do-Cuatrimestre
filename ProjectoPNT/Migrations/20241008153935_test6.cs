using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class test6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId1",
                table: "Archivos3D");

            migrationBuilder.RenameColumn(
                name: "RepositorioArchivosId1",
                table: "Archivos3D",
                newName: "RepositorioArchivosBorradosId");

            migrationBuilder.RenameIndex(
                name: "IX_Archivos3D_RepositorioArchivosId1",
                table: "Archivos3D",
                newName: "IX_Archivos3D_RepositorioArchivosBorradosId");

            migrationBuilder.AlterColumn<int>(
                name: "RepositorioArchivosId",
                table: "Archivos3D",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosBorradosId",
                table: "Archivos3D",
                column: "RepositorioArchivosBorradosId",
                principalTable: "RepositorioArchivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosBorradosId",
                table: "Archivos3D");

            migrationBuilder.RenameColumn(
                name: "RepositorioArchivosBorradosId",
                table: "Archivos3D",
                newName: "RepositorioArchivosId1");

            migrationBuilder.RenameIndex(
                name: "IX_Archivos3D_RepositorioArchivosBorradosId",
                table: "Archivos3D",
                newName: "IX_Archivos3D_RepositorioArchivosId1");

            migrationBuilder.AlterColumn<int>(
                name: "RepositorioArchivosId",
                table: "Archivos3D",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId1",
                table: "Archivos3D",
                column: "RepositorioArchivosId1",
                principalTable: "RepositorioArchivos",
                principalColumn: "Id");
        }
    }
}
