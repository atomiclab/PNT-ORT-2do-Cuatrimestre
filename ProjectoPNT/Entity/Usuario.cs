using System.ComponentModel.DataAnnotations;

namespace ProyectoPNT.Entity;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    //public int UsuarioID toma [KEY] como identity 
    //Ponerle el nombre de prefijo y sufijoID
    
    //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)] Hace que el campo no sea autoincrementable
    [MaxLength(50)]
    public String Nombre { get; set; } //con ? despues del tipo de dato se puede aceptar null
    
    [MaxLength(50)]
    public String Apellido { get; set;}


    [MaxLength(50)]
    [DataType(DataType.EmailAddress)] // para emails 
    public String Email { get; set; }
    public String Password { get; set; }
    
    // One-to-Many
    public ICollection<Archivo3D> Archivos3D { get; set; }
}