using System.ComponentModel.DataAnnotations;

namespace MVCProyectoPNT.Entity;

public class RepositorioArchivos
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    // Colección para almacenar objetos Archivo3D asociados con este repositorio.
    // Inicializada a una lista vacía para evitar problemas de referencia nula.
    public ICollection<Archivo3D> Archivos { get; set; } = new List<Archivo3D>();

    public List<Archivo3D> ArchivosBorrados { get; set; } = new List<Archivo3D>();

}