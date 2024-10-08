using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId",
                table: "Archivos3D");

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
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId",
                table: "Archivos3D",
                column: "RepositorioArchivosId",
                principalTable: "RepositorioArchivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId",
                table: "Archivos3D");

            migrationBuilder.AlterColumn<int>(
                name: "RepositorioArchivosId",
                table: "Archivos3D",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId",
                table: "Archivos3D",
                column: "RepositorioArchivosId",
                principalTable: "RepositorioArchivos",
                principalColumn: "Id");
        }
    }
}
