using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoPNT.Entity;

public class Archivo3D
{  
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public String Nombre { get; set;} 
    [MaxLength(150)]
    public String Descripcion { get; set; }
    public String Formato { get; set; }
    public Double Tamano { get; set; }
    public String Ruta { get; set; }
    //public DateTime FechaCreacion { get; set; }
    //public Usuario Autor { get; set;  }
    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }
    
}