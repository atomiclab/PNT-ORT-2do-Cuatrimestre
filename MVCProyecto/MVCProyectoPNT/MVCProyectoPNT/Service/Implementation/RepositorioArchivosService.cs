using MVCProyectoPNT.Context;
using MVCProyectoPNT.Entity;

namespace MVCProyectoPNT.Service.Implementation;

public class RepositorioArchivosService
{
    
    private AppDbContext context = new AppDbContext();

    public List<Archivo3D> BuscarArchivo(string nombre)
    {
        return context.Archivos3D.Where(a => a.Nombre.Contains(nombre)).ToList();
    }

    public bool BorrarArchivoDeLista(int id)
    {
        var archivo = context.Archivos3D.FirstOrDefault(a => a.Id == id);
        if (archivo != null)
        {
            context.Archivos3D.Remove(archivo);
            context.SaveChanges();
            return true;
        }
        return false;
    }

    public List<Archivo3D> ListarArchivos(int usuarioId)
    {
        return context.Archivos3D.Where(a => a.UsuarioId == usuarioId).ToList();
    }
}
