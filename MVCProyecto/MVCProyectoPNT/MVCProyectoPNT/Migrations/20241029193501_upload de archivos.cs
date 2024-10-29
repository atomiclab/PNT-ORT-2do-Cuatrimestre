using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProyectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class uploaddearchivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RepositorioArchivosId",
                table: "Archivos3D",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentoRuta",
                table: "Archivos3D",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FotoRuta",
                table: "Archivos3D",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoRuta",
                table: "Archivos3D");

            migrationBuilder.DropColumn(
                name: "FotoRuta",
                table: "Archivos3D");

            migrationBuilder.AlterColumn<int>(
                name: "RepositorioArchivosId",
                table: "Archivos3D",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
