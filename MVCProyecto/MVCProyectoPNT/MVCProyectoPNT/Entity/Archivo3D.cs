using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProyectoPNT.Entity;

public class Archivo3D
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Nombre { get; set; }
    [MaxLength(150)]
    public string Descripcion { get; set; }
    public string Formato { get; set; }
    public double Tamano { get; set; }
    public string Ruta { get; set; }

    // FK para Usuario
    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    // FK para RepositorioArchivos
    public int RepositorioArchivosId { get; set; }
    public RepositorioArchivos RepositorioArchivos { get; set; }

    // FK para RepositorioArchivosBorrados
    public int? RepositorioArchivosBorradosId { get; set; }
    public RepositorioArchivos? RepositorioArchivosBorrados { get; set; }
}