using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPNT.Entity
{
    public class RepositorioArchivos
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Archivo3D> Archivos { get; set; } = new List<Archivo3D>();

        public List<Archivo3D> ArchivosBorrados { get; set; } = new List<Archivo3D>();
   
       
        
    }
}