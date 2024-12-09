using MVCProyectoPNT.Context;
using MVCProyectoPNT.Entity;

namespace MVCProyectoPNT.Service.Implementation;

public class Archivo3DService
{
    private readonly AppDbContext context;
    private readonly ILogger<Archivo3DService> logger;

    public Archivo3DService(AppDbContext context, ILogger<Archivo3DService> logger)
    {
        this.context = context;
        this.logger = logger;
    }
    
    public bool save(Archivo3D archivo3D)
    {
        bool estado = false;
        try
        {
            if (archivo3D != null)
            {   
                // Registro de información en el log que llega
                logger.LogInformation("Creating Archivo3D with the following data:");
                logger.LogInformation($"Id: {archivo3D.Id}");
                logger.LogInformation($"Nombre: {archivo3D.Nombre}");
                logger.LogInformation($"Descripcion: {archivo3D.Descripcion}");
                logger.LogInformation($"Formato: {archivo3D.Formato}");
                logger.LogInformation($"Tamano: {archivo3D.Tamano}");
                logger.LogInformation($"Ruta: {archivo3D.Ruta}");
                logger.LogInformation($"UsuarioId: {archivo3D.UsuarioId}");
                logger.LogInformation($"RepositorioArchivosId: {archivo3D.RepositorioArchivosId}");
                logger.LogInformation($"RepositorioArchivosBorradosId: {archivo3D.RepositorioArchivosBorradosId}");

                context.Archivos3D.Add(archivo3D);
                context.SaveChanges();
                estado = true;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Un error ocurrio al guardar un Archivo3D.");
        }
        return estado;
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    public bool update(Archivo3D archivo3d)
    {
        bool estado = false;
        if (archivo3d!=null)
        {
            context.Archivos3D.Update(archivo3d);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
    public bool deleteById(int id)
    {
        bool estado = false;
        try
        {
            Archivo3D archivo3D = context.Archivos3D.FirstOrDefault(x => x.Id == id);
            if (archivo3D != null)
            {
                context.Archivos3D.Remove(archivo3D);
                context.SaveChanges();
                estado = true;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al borrar por ID un Archivo3D.");
        }
        return estado;
    }
        
        
    
    public bool delete(Archivo3D archivo3D)
    {
        bool estado = false;
        if (archivo3D!=null)
        {
            context.Archivos3D.Remove(archivo3D);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
    public List<Archivo3D> GetByUsuarioId(int usuarioId) //obtiene los archivos de un usuario
    {
        return context.Archivos3D.Where(a => a.UsuarioId == usuarioId).ToList(); // Where: Filtra una secuencia de valores basada en archivo
    }

    public bool Delete(Archivo3D archivo)
    {
        context.Archivos3D.Remove(archivo);
        context.SaveChanges();
        return true;
    }
    
    public List<Archivo3D> GetAll()
    {
        return context.Archivos3D.ToList();
    }
    public Archivo3D GetById(int id)
    {
        return context.Archivos3D.FirstOrDefault(a => a.Id == id);
    }
    public List<Usuario> GetUsuarios()
    {
        return context.Usuarios.ToList();
    }
    public Usuario GetUsuarioById(int usuarioId)
    {
        return context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
    }

    public RepositorioArchivos GetRepositorioArchivosById(int repositorioArchivosId)
    {
        return context.RepositorioArchivos.FirstOrDefault(r => r.Id == repositorioArchivosId);
    }
    public List<RepositorioArchivos> GetAllRepositorios()
    {
        return context.RepositorioArchivos.ToList();
    }
    public List<Archivo3D> SearchByName(string name)
    {
        return context.Archivos3D
            .Where(a => a.Nombre.Contains(name))
            .ToList();
    }
}