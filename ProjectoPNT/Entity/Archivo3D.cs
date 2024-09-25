namespace ProjectoPNT.Entity;

public class Archivo3D
{
    public int id { get; set; }
    public String Nombre { get; set;} 
    public String Descripcion { get; set; }
    public String Formato { get; set; }
    public Double Tamano { get; set; }
    public String Ruta { get; set; }
    //public DateTime FechaCreacion { get; set; }
    public Usuario Autor { get; set;  }
}