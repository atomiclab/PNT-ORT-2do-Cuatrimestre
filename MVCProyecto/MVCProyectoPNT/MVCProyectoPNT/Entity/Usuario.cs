using System.ComponentModel.DataAnnotations;

namespace MVCProyectoPNT.Entity;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    //public int UsuarioID toma [KEY] como identity 
    //Ponerle el nombre de prefijo y sufijoID
    
    //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)] Hace que el campo no sea autoincrementable
    [MaxLength(50)]
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public String Nombre { get; set; } //con ? despues del tipo de dato se puede aceptar null
    
    [MaxLength(50)]
    [Required(ErrorMessage = "El apellido es obligatorio.")]
    //TODO: validation attribute
    public String Apellido { get; set;}


    [MaxLength(50)]
    [DataType(DataType.EmailAddress)] // para emails
    [Required(ErrorMessage = "El email es obligatorio.")]
    public String Email { get; set; }
    
    [MaxLength(50)]
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public String Password { get; set; }
    
    // One-to-Many // Ademas la tuve que inicializar en vacia xq sino pinchaba al crear un usuario
    // (el usuario no se crea con archivos 3d)
    public ICollection<Archivo3D> Archivos3D { get; set; } = new List<Archivo3D>();

}