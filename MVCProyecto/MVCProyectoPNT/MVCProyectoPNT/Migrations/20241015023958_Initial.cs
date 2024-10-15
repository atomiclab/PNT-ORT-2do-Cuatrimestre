using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProyectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepositorioArchivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositorioArchivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archivos3D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamano = table.Column<double>(type: "float", nullable: false),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RepositorioArchivosId = table.Column<int>(type: "int", nullable: true),
                    RepositorioArchivosBorradosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos3D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosBorradosId",
                        column: x => x.RepositorioArchivosBorradosId,
                        principalTable: "RepositorioArchivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId",
                        column: x => x.RepositorioArchivosId,
                        principalTable: "RepositorioArchivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Archivos3D_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos3D_RepositorioArchivosBorradosId",
                table: "Archivos3D",
                column: "RepositorioArchivosBorradosId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos3D_RepositorioArchivosId",
                table: "Archivos3D",
                column: "RepositorioArchivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos3D_UsuarioId",
                table: "Archivos3D",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos3D");

            migrationBuilder.DropTable(
                name: "RepositorioArchivos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
